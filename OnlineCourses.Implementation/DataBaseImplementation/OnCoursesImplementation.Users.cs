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
    }
}
