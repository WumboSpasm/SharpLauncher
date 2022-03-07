using Microsoft.Data.Sqlite;

namespace SharpLauncher
{
    public static class DBFunctions
    {
        // The size of block to read from the database.
        // I increased this from 500 because I was getting better performance at 5000.
        public const int BlockSize = 5000;

        #region Database Functions

        /// <summary>
        /// Return game or animation entries from the Flashpoint database.
        /// </summary>
        /// <param name="query">The SQL query string to use. Must select "title,developer,publisher,id,tagsStr" in that order.</param>
        /// <param name="conn">An open connection to the DB. If null, a new one will be created.</param>
        /// <returns>A List of QueryItems representing the results.</returns>
        public static List<QueryItem> DatabaseQueryEntry(string query, SqliteConnection? conn = null)
        {
            // By default, assume that we have a persistent connection.
            bool persistentConn = true;
            // If the connection wasn't persistent,
            if (conn == null)
            {
                // Mark it as such. We'll need this later for the Close().
                persistentConn = false;
                // Create and open a new connection to the db.
                // TODO: check thread-safety on this.
                conn = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
                conn.Open();
            }

            // Create a command from the query and the connection.
            SqliteCommand command = new(query, conn);

            // Create a List to hold the results.
            List<QueryItem> data = new();

            // The using block should handle disposes nicely.
            using (SqliteDataReader dataReader = command.ExecuteReader())
            {
                // Repeat as long as there are lines to read.
                while (dataReader.Read())
                {
                    // Add a QueryItem. Assume that the order is "title,developer,publisher,id,tagsStr"
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

            // Close the connection if we created it ourselves.
            if (!persistentConn)
            {
                conn.Close();
            }

            return data;
        }
        /// <summary>
        /// Return metadata about an entry from the Flashpoint database.
        /// </summary>
        /// <param name="entry">A QueryItem representing the entry in question.</param>
        /// <param name="library">The library of the entry, if known. <i>Might</i> speed up results a bit, but no promises.</param>
        /// <param name="conn">An open connection to the DB. If null, a new one will be created.</param>
        /// <returns>A MetaDataObj representing the entry's metadata, or null if the entry wasn't found.</returns>
        public static MetaDataObj? DatabaseQueryMeta(QueryItem entry, string library = "", SqliteConnection? conn = null)
        {
            // By default, assume that we have a persistent connection.
            bool persistentConn = true;
            // If the connection wasn't persistent,
            if (conn == null)
            {
                // Mark it as such. We'll need this later for the Close().
                persistentConn = false;
                // Create and open a new connection to the db.
                // TODO: check thread-safety on this.
                conn = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
                conn.Open();
            }

            // Yes, I'm hard-coding this. Sue me.
            // This gets many of the metadata fields corresponding to the entry with id=entry.ID.
            // Note: I leave out the fields that are already supplied by the QueryItem.
            SqliteCommand command = new($"SELECT alternateTitles,series,source,releaseDate,platform,version,library,language,playMode,status,activeDataOnDisk,notes,originalDescription " +
                $"FROM game " +
                $"WHERE id='{entry.ID.Replace("'", "''")}' " +
                (library == "" ? "" : $"AND library='{library.Replace("'", "''")}'"), conn);

            // By default, we didn't find anything. Let the result be null.
            MetaDataObj? data = null;

            using (SqliteDataReader dataReader = command.ExecuteReader())
            {
                // As long as there are lines to read (note: id should be unique, so this should run at most once):

                while (dataReader.Read())
                {
                    // No need for a list: this should only run once.
                    data = new MetaDataObj
                    {
                        // Use the QueryItem fields where possible.
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

            // Close the connection if we created it ourselves.
            if (!persistentConn)
            {
                conn.Close();
            }

            return data;
        }
                 
        /// <summary>
        /// Return add-app entries associated with a given parentGameId from the Flashpoint database.
        /// </summary>
        /// <param name="parentGameId">The parentGameId.</param>
        /// <param name="conn">An open connection to the DB. If null, a new one will be created.</param>
        /// <returns>A List of AddApps representing the results.</returns>
        public static List<AddApp> DatabaseQueryAddApp(string parentGameId, SqliteConnection? conn = null)
        {
            // By default, assume that we have a persistent connection.
            bool persistentConn = true;
            // If the connection wasn't persistent,
            if (conn == null)
            {
                // Mark it as such. We'll need this later for the Close().
                persistentConn = false;
                // Create and open a new connection to the db.
                // TODO: check thread-safety on this.
                conn = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
                conn.Open();
            }

            // These are the fields that AddApp has. We won't get more fields than we can populate.
            // ParentGameId is supplied by the arguments, no need to fetch that from the db.
            SqliteCommand command = new($"SELECT id,name,applicationPath FROM additional_app WHERE parentGameId is '{parentGameId.Replace("'","''")}'", conn);

            // Make a List to hold the results.
            List<AddApp> data = new();

            using (SqliteDataReader dataReader = command.ExecuteReader())
            {
                // As long as there are results to read,
                while (dataReader.Read())
                {
                    // Read a row in and convert it to an AddApp object.
                    data.Add(new AddApp
                    {
                        ID = dataReader.IsDBNull(0) ? "" : dataReader.GetString(0),
                        ParentGameId = parentGameId,
                        Name = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1),
                        ApplicationPath = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2)
                    });
                }
            }

            // Close the connection if we created it ourselves.
            if (!persistentConn)
            {
                conn.Close();
            }

            return data;
        }

        /// <summary>
        /// Get the number of add-apps associated with a given parentGameId.
        /// </summary>
        /// <param name="parentGameId">The parentGameId in question.</param>
        /// <param name="conn">An open connection to the DB. If null, a new one will be created.</param>
        /// <returns>The number of add-apps found in the DB that have the given parentGameId.</returns>
        public static int DatabaseGetAddAppCount(string parentGameId, SqliteConnection? conn = null)
        {
            // By default, assume that we have a persistent connection.
            bool persistentConn = true;
            // If the connection wasn't persistent,
            if (conn == null)
            {
                // Mark it as such. We'll need this later for the Close().
                persistentConn = false;
                // Create and open a new connection to the db.
                // TODO: check thread-safety on this.
                conn = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
                conn.Open();
            }

            // Using SQL's built-in COUNT function, because I think that its performance detriments are outweighed by
            // the potential detriments of making a new list, etc.
            SqliteCommand command = new($"SELECT COUNT(parentGameId) FROM additional_app WHERE parentGameId is '{parentGameId.Replace("'", "''")}'", conn);

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

            // Close the connection if we created it ourselves.
            if (!persistentConn)
            {
                conn.Close();
            }

            return count;
        }

        #endregion

        #region Query-Builder Functions

        /// <summary>
        /// Query template to make things easier. Builds a query from parameters.
        /// </summary>
        /// <param name="extraOperations">An array of strings, each of which is a condition to restrict the results. May be empty.</param>
        /// <param name="search">A string that the titles of results must contain.</param>
        /// <param name="library">The library in which the results must be.</param>
        /// <param name="offset"></param>
        /// <returns></returns>
        // TODO: optimize this. Two lists created and messed with, all for one query string?
        public static string GetQuery(List<string> extraOperations, string search = "", string library = "arcade")
        {
            // We create a new List to hold the fragments of the query as we build it.
            // Select the correct columns from the table.
            List<string> queryFragments = new() { $"SELECT title,developer,publisher,id,tagsStr FROM game" };

            // If any of the conditions are active,
            if (library != "" || search != "" || extraOperations.Count != 0)
            {
                // Add a WHERE statement.
                queryFragments.Add("WHERE");

                // Create a List to hold the conditions that will follow.
                List<string> queryConditions = new();

                // If the library is set,
                if (library != "")
                {
                    // Add a condition: the library must be library.
                    // Don't rely on an unsynchronized global, instead use an argument.
                    queryConditions.Add($"library = '{library.Replace("'", "''")}'");
                }

                // If the search string is set,
                if (search != "")
                {
                    // Add a condition: the title must contain search.
                    queryConditions.Add($"title LIKE '%{search.Replace("'", "''")}%'");
                }

                // Add all conditions from extraOperations.
                queryConditions.AddRange(extraOperations);

                // Join all the conditions together with ADD statments.
                queryFragments.Add(String.Join(" AND ", queryConditions));
            }

            // We order by the title. 
            queryFragments.Add("ORDER BY title");

            // Join all the fragments with spaces.
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
        /// <param name="search">The string to search titles for.</param>
        /// <param name="library">The library to search in.</param>
        /// <returns>A query string representing the block query.</returns>
        public static string GetQueryBlock(List<string> extraOperations, string lastElem = "", string lastId = "", string sortByColumn = "title", bool sortDirection = true, int blockSize = BlockSize, string search = "", string library = "arcade")
        {
            // Depending on the sortDirection, we should have different comparison operators and terms.
            // This one is used for comparison to the last item for keyset pagination.
            char sortOperator = sortDirection ? '>' : '<';
            // This one is used to ensure that the results are sorted correctly - an incorrect sort
            // would invalidate the next block, and the one after that.
            string sortTerm = sortDirection ? "ASC" : "DESC";

            // We create a new List to hold the fragments of the query as we build it.
            // Select the correct columns from the table.
            List<string> queryFragments = new() { $"SELECT title,developer,publisher,id,tagsStr FROM game" };

            // If any of the conditions are active,
            if (lastElem != "" || lastId != "" || library != "" || search != "" || extraOperations.Count != 0)
            {
                // Add a WHERE statement.
                queryFragments.Add("WHERE");

                // Create a List to hold the conditions that will follow.
                List<string> queryConditions = new();

                // If the lastElem or lastId is unset (that is, we have been passed a last element)
                if (lastElem != "" || lastId != "")
                {
                    // Use keyset pagination to skip the old elements.
                    queryConditions.Add($"({sortByColumn}, id) {sortOperator} ('{lastElem.Replace("'","''")}', '{lastId.Replace("'", "''")}')");
                }

                // If the library is set,
                if (library != "")
                {
                    // Add a condition: the library must be library.
                    // Don't rely on an unsynchronized global, instead use an argument.
                    queryConditions.Add($"library = '{library.Replace("'", "''")}'");
                }

                // If the search string is set,
                if (search != "")
                {
                    // Add a condition: the title must contain search.
                    queryConditions.Add($"title LIKE '%{search.Replace("'", "''")}%'");
                }

                // Add all conditions from extraOperations.
                queryConditions.AddRange(extraOperations);

                // Join all the conditions together with ADD statments.
                queryFragments.Add(String.Join(" AND ", queryConditions));
            }

            // Order by the sortByColumn primarily, in the direction sortTerm, and id secondarily, also in the direction sortTerm.
            queryFragments.Add($"ORDER BY {sortByColumn} {sortTerm}, id {sortTerm}");

            // Limit our number of results to blockSize.
            queryFragments.Add($"LIMIT {blockSize}");

            // Join all the fragments with spaces.
            return String.Join(' ', queryFragments);
        }

        #endregion

        #region Filter Functions
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

        // Alternate query template for retrieving entries via *.fp files.
        public static string GetAltQuery(string gameID, string search, List<string> extraOperations)
        {
            return $"SELECT title,developer,publisher,id,tagsStr FROM game WHERE id = '{gameID}'" +
            (search != "" ? $" AND title LIKE '%{search}%'" : "") +
            (extraOperations.Count != 0 ? " AND " + String.Join(" AND ", extraOperations) : "");
        }
#endregion
    }
}
