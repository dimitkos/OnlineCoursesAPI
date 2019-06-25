using Dapper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation
{
    public class DbImplementation 
    {
        public List<string> GetAllUsers()
        {
            var response = new List<string>
            {
                "dimitris","Andrew"
            };

            return response;
        }

        public GetUsersResponse GetUsers()
        {
            string sql = @"Select * From users";
            using (var con = GetSqlConnection())
            {
                var response = con.Query<Users>(sql);
                return new GetUsersResponse()
                {
                    Users = response
                };
            }
        }


        private SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.AppSettings["myConnectionString"]);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}
