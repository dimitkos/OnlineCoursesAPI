using Dapper;
using OnlineCourses.Common.Types;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OnlineCourses.Common.DBCommon
{
    public static class DatabaseLogging
    {
        private static SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.AppSettings["myConnectionString"]);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public static void LogError(Error error)
        {
            string sql = @"INSERT INTO Errors (Id,Message,RequestMethod,RequestUri,TimeUtc) VALUES (@Id,@Message,@RequestMethod,@RequestUri,@TimeUtc)";
            var parameters = new { Id = Guid.NewGuid(), error.Message, error.RequestMethod, error.RequestUri, TimeUtc = DateTime.Now };

            using (var con = GetSqlConnection())
            {
                con.Execute(sql, parameters);
            }
        }
    }
}
