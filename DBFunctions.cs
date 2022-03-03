using Microsoft.Data.Sqlite;

namespace SharpLauncher
{
    // TODO: write all the documentation for this, and comment it.
    public static class DBFunctions
    {
        // The size of block to read from the database.
        public const int BlockSize = 5000;

        // Return game or animation entries from the Flashpoint database.
        public static List<QueryItem> DatabaseQueryEntry(string query)
        {
            // TODO: make this persistent.
            SqliteConnection connection = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
            connection.Open();

            SqliteCommand command = new(query, connection);

            List<QueryItem> data = new();

            using (SqliteDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    data.Add(new QueryItem
                    {
                        Title = dataReader.IsDBNull(0) ? "" : dataReader.GetString(0),
                        Developer = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1),
                        Publisher = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2),
                        ID = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3),
                        tagsStr = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4)
                    });
                }
            }

            connection.Close();

            return data;
        }

        // Return metadata about an entry from the Flashpoint database.
        public static MetaDataObj DatabaseQueryMeta(QueryItem entry, string library = "")
        {
            // TODO: make this persistent.
            SqliteConnection connection = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
            connection.Open();
            // Yes, I'm hard-coding this. Sue me.
            SqliteCommand command = new($"SELECT alternateTitles,series,source,releaseDate,platform,version,library,language,playMode,status,activeDataOnDisk,notes,originalDescription " +
                $"FROM game " +
                $"WHERE id='{entry.ID.Replace("'", "''")}' " +
                (library == "" ? "" : $"AND library='{library.Replace("'", "''")}'"), connection);
            // TODO: memory leak?
            MetaDataObj data = new();

            using (SqliteDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    // No need for a list: this should only run once.
                    data = new MetaDataObj
                    {
                        Title = entry.Title,
                        AlternateTitles = dataReader.IsDBNull(0) ? "" : dataReader.GetString(0),
                        Series = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1),
                        Developer = entry.Developer,
                        Publisher = entry.Publisher,
                        Source = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2),
                        ReleaseDate = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3),
                        Platform = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4),
                        Version = dataReader.IsDBNull(5) ? "" : dataReader.GetString(5),
                        Library = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6),
                        Tags = entry.tagsStr,
                        Language = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7),
                        PlayMode = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8),
                        Status = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9),
                        Format = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10),
                        Notes = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11),
                        OriginalDescription = dataReader.IsDBNull(12) ? "" : dataReader.GetString(12)
                    };
                }
            }

            connection.Close();

            return data;
        }

        // Return add-app entries associated with a given parentGameId from the Flashpoint database.
        public static List<AddApp> DatabaseQueryAddApp(string parentGameId)
        {
            // TODO: make this persistent.
            SqliteConnection connection = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
            connection.Open();

            SqliteCommand command = new($"SELECT id,name,applicationPath FROM additional_app WHERE parentGameId is '{parentGameId.Replace("'","''")}'", connection);

            List<AddApp> data = new();

            using (SqliteDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    data.Add(new AddApp
                    {
                        ID = dataReader.IsDBNull(0) ? "" : dataReader.GetString(0),
                        ParentGameId = parentGameId,
                        Name = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1),
                        ApplicationPath = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2)
                    });
                }
            }

            connection.Close();

            return data;
        }

        // Get the number of add-apps associated with a given gameId.
        public static int DatabaseGetAddAppCount(string id)
        {
            // TODO: make this persistent.
            SqliteConnection connection = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
            connection.Open();

            // Using SQL's built-in COUNT function, because I think that its performance detriments are outweighed by
            // the potential detriments of making a new list, etc.
            SqliteCommand command = new($"SELECT COUNT(parentGameId) FROM additional_app WHERE parentGameId is '{id.Replace("'", "''")}'", connection);

            int count = 0;

            using (SqliteDataReader dataReader = command.ExecuteReader())
            {
                // This loop should run exactly once.
                while (dataReader.Read())
                {
                    // The count should be in the first column.
                    count = dataReader.GetInt32(0);
                }
            }

            connection.Close();

            return count;
        }

        // Query template to make things easier
        // TODO: optimize this. Two lists created and messed with, all for one query string?
        public static string GetQuery(List<string> extraOperations, string search = "", string library = "arcade", int offset = -1)
        {
            List<string> queryFragments = new() { $"SELECT title,developer,publisher,id,tagsStr FROM game" };

            if (library != "" || search != "" || extraOperations.Count != 0)
            {
                queryFragments.Add("WHERE");

                List<string> queryConditions = new();

                if (library != "")
                {
                    // Don't rely on an unsynchronized global, instead use an argument.
                    queryConditions.Add($"library = '{library.Replace("'", "''")}'");
                }

                if (search != "")
                {
                    queryConditions.Add($"title LIKE '%{search.Replace("'", "''")}%'");
                }

                foreach (string operation in extraOperations)
                {
                    queryConditions.Add(operation);
                }

                queryFragments.Add(String.Join(" AND ", queryConditions));
            }

            queryFragments.Add("ORDER BY title");

            if (offset != -1)
            {
                queryFragments.Add($"LIMIT {offset}, 1");
            }

            return String.Join(' ', queryFragments);
        }

        /// <summary>
        /// Gets the proper query string for a block of data, using keyset pagination to avaoid the bad performance of OFFSET.
        /// Sorts by sortyByColumn, using Id as a secondary sort for when sortByColumn is non-unique.
        /// </summary>
        /// <param name="extraOperations">The extra conditions to put on the data.</param>
        /// <param name="lastElem">The last element of the last block, in the column sortByColumn.</param>
        /// <param name="lastId">The last element of the last block, in the column Id.</param>
        /// <param name="sortByColumn">The column on which the keyset pagination will be performed. This column must contain only unique values.</param>
        /// <param name="sortDirection">The direction to sort. If true, sort ascending (a-z). If false, sort descending (z-a)</param>
        /// <param name="blockSize">The size of the block to query.</param>
        /// <param name="search">The string to search for.</param>
        /// <param name="library">The library to search in.</param>
        /// <returns>A query string representing the block query.</returns>
        public static string GetQueryBlock(List<string> extraOperations, string lastElem = "", string lastId = "", string sortByColumn = "title", bool sortDirection = true, int blockSize = BlockSize, string search = "", string library = "arcade")
        {
            char sortOperator = sortDirection ? '>' : '<';
            string sortTerm = sortDirection ? "ASC" : "DESC";
            List<string> queryFragments = new() { $"SELECT title,developer,publisher,id,tagsStr FROM game" };

            if (lastElem != "" || lastId != "" || library != "" || search != "" || extraOperations.Count != 0)
            {
                queryFragments.Add("WHERE");

                List<string> queryConditions = new();
                if (lastElem != "" || lastId != "")
                {
                    queryConditions.Add($"({sortByColumn}, id) {sortOperator} ('{lastElem.Replace("'","''")}', '{lastId.Replace("'", "''")}')");
                }

                if (library != "")
                {
                    // Don't rely on an unsynchronized global, instead use an argument.
                    queryConditions.Add($"library = '{library.Replace("'", "''")}'");
                }

                if (search != "")
                {
                    queryConditions.Add($"title LIKE '%{search.Replace("'", "''")}%'");
                }

                foreach (string operation in extraOperations)
                {
                    queryConditions.Add(operation);
                }

                queryFragments.Add(String.Join(" AND ", queryConditions));
            }

            queryFragments.Add($"ORDER BY {sortByColumn} {sortTerm}, id {sortTerm}");

            queryFragments.Add($"LIMIT {blockSize}");

            return String.Join(' ', queryFragments);
        }

        /// <summary>
        /// Filter data according to filteredTags and set lastElem to the last element of data. Also set blockSize to the size of data.
        /// </summary>
        /// <param name="data">The data to be filtered.</param>
        /// <param name="filteredTags">The tags to filter out.</param>
        /// <param name="lastElem">The last element of data (unfiltered) will be placed here.</param>
        /// <param name="blockSize">The size of data will be placed here.</param>
        /// <returns>The filtered data.</returns>
        public static List<QueryItem> FilterDataBlock(List<QueryItem> data, List<string> filteredTags, out QueryItem lastElem, out int blockSize)
        {
            // Set blockSize to the size of data.
            blockSize = data.Count;
            // Set lastElem to the last element of data, or a new element if data is empty.
            lastElem = blockSize > 0 ? data[^1] : new();
            // Return the filtered data.
            return data.FindAll((QueryItem elem) => !filteredTags.Intersect(elem.tagsStr.Split("; ")).Any());
        }

        /// <summary>
        /// Filter data according to filteredTags.
        /// </summary>
        /// <param name="data">The data to be filtered.</param>
        /// <param name="filteredTags">The tags to filter out.</param>
        /// <returns>The filtered data.</returns>
        public static List<QueryItem> FilterData(List<QueryItem> data, List<string> filteredTags)
        {
            // Return the filtered data.
            return data.FindAll((QueryItem elem) => !filteredTags.Intersect(elem.tagsStr.Split("; ")).Any());
        }

        // Alternate query template for favorites, play history
        public static string GetAltQuery(string gameID, string search, List<string> extraOperations)
        {
            return $"SELECT title,developer,publisher,id,tagsStr FROM game WHERE id = '{gameID}'" +
            (search != "" ? $" AND title LIKE '%{search}%'" : "") +
            (extraOperations.Count != 0 ? " AND " + String.Join(" AND ", extraOperations) : "");
        }
    }
}
