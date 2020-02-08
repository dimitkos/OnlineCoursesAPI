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

        public static void Audit(Audit audit)
        {
            string sql = @"INSERT INTO Auditing (Id,Host,Headers,StatusCode,RequestBody,RequestedMethod,UserHostAddress,Useragent,AbsoluteUri,RequestType,Time) VALUES (@Id,@Host,@Headers,@StatusCode,@RequestBody,@RequestedMethod,@UserHostAddress,@Useragent,@AbsoluteUri,@RequestType,@Time)";
            var parameters = new { Id = Guid.NewGuid(), audit.Host, audit.Headers, audit.StatusCode, audit.RequestBody, audit.RequestedMethod, audit.UserHostAddress, audit.Useragent, audit.AbsoluteUri, audit.RequestType, Time = DateTime.Now };

            using (var con = GetSqlConnection())
            {
                con.Execute(sql, parameters);
            }
        }
    }
}
