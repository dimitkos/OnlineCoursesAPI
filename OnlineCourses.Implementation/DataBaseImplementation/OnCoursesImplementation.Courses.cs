using Dapper;
using OnlineCourses.Types.Requests;
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

        public bool AddNewCourse(AddNewCourseRequest request)
        {
            string sql = @"INSERT INTO Course (Id,Title,Description,Rating,Price,CategoryId,FrameworkId,InstructorId) VALUES (@Id,@Title,@Description,@Rating,@Price,@CategoryId,@FrameworkId,@InstructorId)";
            int result;
            var parameters = new { request.Id, request.Title, request.Description, request.Rating, request.Price, request.CategoryId, request.FrameworkId, request.InstructorId };
            using (var con = GetSqlConnection())
            {
                using (var transaction = con.BeginTransaction())
                {
                    if(CheckIfCourseNotExists(request.Id))
                    {
                        result = con.Execute(sql, parameters, transaction: transaction);

                    }
                    else
                    {
                        throw new Exception("The Course id is existing");
                    }
                    transaction.Commit();
                }
            }
            return result ==1;
        }

        public bool UpdateCourse(UpdateCourseRequest request)
        {
            string sql = @"Update Course SET Title=@Title,Description=@Description,Price=@Price Where Id=@Id";
            int result;
            var parameters = new { request.Id, request.Title, request.Description, request.Price};
            using (var con = GetSqlConnection())
            {
                using (var transaction = con.BeginTransaction())
                {
                    if (!CheckIfCourseNotExists(request.Id))
                    {
                        result = con.Execute(sql, parameters, transaction: transaction);
                    }
                    else
                    {
                        throw new Exception("The Course is not updated");
                    }
                    transaction.Commit();
                }
            }
            return result == 1;
        }

        private bool CheckIfCourseNotExists(int requestId)
        {
            string sql = @"Select * From Course Where Id=@Id";
            var parameters = new { Id = requestId };
            using (var con = GetSqlConnection())
            {
                var response = con.Query<CourseResponse>(sql,parameters).FirstOrDefault();
                return response == null ? true : false;
            }
        }
    }
}
