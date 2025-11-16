using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace serverXamarin
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Dictionary<string, object>> GetTableData(string tableName)
        {
            var results = new List<Dictionary<string, object>>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var query = $"SELECT * FROM {tableName}";
                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }
                        results.Add(row);
                    }
                }
            }

            return results;
        }
    }
}
