using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace HW16
{
    public class SqlHelper
    {
        private NpgsqlConnection _sqlConnection;

        public SqlHelper(string dbName)
        {
            /*_sqlConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = "localhost:5432",
                InitialCatalog = dbName
            };*/
            
            /*var cs = "Host=localhost;Username=postgres;Password=Mabel123!";

            using var con = new NpgsqlConnection(cs);*/
        }

        public void OpenConnection()
        {
            _sqlConnection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Mabel123!;Database=Shop");
            _sqlConnection.Open();
        }

        public void CloseConnection() => _sqlConnection.Close();

        public void ExecuteNonQuery(string request)
        {
            var command = new NpgsqlCommand(request, _sqlConnection);
            command.ExecuteNonQuery();
        }

        public void Insert(string table, Dictionary<string, string> parameters)
        {
            var columns = string.Empty;
            var values = string.Empty;

            foreach (var (key, value) in parameters)
            {
                columns += $"\"{key}\",";
                values += $"{value},";
            }

            var command = new NpgsqlCommand($"insert into {table} ({columns.TrimEnd(',')}) values ({values.TrimEnd(',')})",
                _sqlConnection);
            command.ExecuteNonQuery();
        }

        public bool IsRowExistedInTable(string table, Dictionary<string, string> parameters)
        {
            var whereParameters = string.Empty;

            foreach (var (key, value) in parameters)
                whereParameters += $" and \"{key}\"={value}";

            var sqlDataAdapter = new NpgsqlDataAdapter(
                $"select * from {table} where {whereParameters.Substring(5)}",
                _sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable.Rows.Count > 0;
        }
    }
}