using Dapper;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation.DataBaseImplementation
{
    public partial class OnCoursesImplementation
    {
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

        public GetUserByIdResponse GetUserById(int userId)
        {
            string sql = @"Select * From users Where id=@id";
            var parameters = new {id = userId };

            using (var con = GetSqlConnection())
            {
                var response = con.Query<Users>(sql,parameters).SingleOrDefault();
                return new GetUserByIdResponse
                {
                    User = response
                };
            }
        }
    }
}
