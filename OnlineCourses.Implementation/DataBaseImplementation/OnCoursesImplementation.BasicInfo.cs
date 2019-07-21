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
        public GetFrameworksResponse GetFrameworks()
        {
            string sql = @"Select * From framework";
            using (var con = GetSqlConnection())
            {
                var response = con.Query<Framework>(sql);
                return new GetFrameworksResponse()
                {
                    Frameworks = response
                };
            }
        }
    }
}
