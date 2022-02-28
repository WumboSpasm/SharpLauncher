using Microsoft.Data.Sqlite;

namespace SharpLauncher
{
    // TODO: write all the documentation for this, and comment it.
    public static class DBFunctions
    {

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
    }
}
