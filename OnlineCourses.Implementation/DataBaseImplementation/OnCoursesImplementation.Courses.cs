using Dapper;
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
        public GetCoursesResponse GetAllCourses()
        {
            string sql = @"select c.id,c.title,c.description,c.rating,c.price,ins.fullname as instructorName,cat.name as categoryName,fr.name as frameworkName
                        from course as c
                        inner join instructor as ins
                        on c.instructorId = ins.id
                        inner join category as cat
                        on c.categoryId = cat.categoryId
                        inner join framework as fr
                        on c.frameworkId = fr.frameworkId";
            using (var con = GetSqlConnection())
            {
                var response = con.Query<CourseResponse>(sql);
                return new GetCoursesResponse()
                {
                    Courses = response
                };
            }
        }
    }
}
