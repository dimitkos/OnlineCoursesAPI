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

        public GetCoursesResponse SearchCourses(SearchCoursesRequest request)
        {
            Dictionary<string, DynamicParameters> searchDictionary = new Dictionary<string, DynamicParameters>();
            var dynamicParameters = new DynamicParameters();

            string sql = @"select c.id,c.title,c.description,c.rating,c.price,ins.fullname as instructorName,cat.name as categoryName,fr.name as frameworkName
                        from course as c
                        inner join instructor as ins
                        on c.instructorId = ins.id
                        inner join category as cat
                        on c.categoryId = cat.categoryId
                        inner join framework as fr
                        on c.frameworkId = fr.frameworkId 
                        Where 1=1";

            if(!string.IsNullOrWhiteSpace(request.Title))
            {
            
                sql += " AND Title = @Title ";
                dynamicParameters.Add("@Title", request.Title);
            
            }

            if(!string.IsNullOrWhiteSpace(request.InstructorName))
            {

                sql += " AND InstructorName = @InstructorName ";
                dynamicParameters.Add("@InstructorName", request.InstructorName);

            }

            if (!string.IsNullOrWhiteSpace(request.CategoryName))
            {

                sql += " AND CategoryName = @CategoryName ";
                dynamicParameters.Add("@CategoryName", request.CategoryName);

            }

            if (!string.IsNullOrWhiteSpace(request.InstructorName))
            {

                sql += " AND InstructorName = @InstructorName ";
                dynamicParameters.Add("@InstructorName", request.InstructorName);

            }

            if (request.UpPrice.HasValue && request.DownPrice.HasValue && request.DownPrice < request.UpPrice)
            {
                sql += " AND Price Between @DownPrice And @UpPrice ";
                dynamicParameters.Add("@DownPrice", request.DownPrice);
                dynamicParameters.Add("@UpPrice", request.UpPrice);
            }

            if (request.UpRating.HasValue && request.DownRating.HasValue && request.DownRating < request.UpRating)
            {
                sql += " AND Rating Between @DownRating And @UpRating ";
                dynamicParameters.Add("@DownRating", request.DownRating);
                dynamicParameters.Add("@UpRating", request.UpRating);
            }

            searchDictionary.Add(sql, dynamicParameters);

            using (var con = GetSqlConnection())
            {
                var response = con.Query<CourseResponse>(searchDictionary.First().Key, searchDictionary.First().Value);

                return new GetCoursesResponse()
                {
                    Courses = response
                };
            }
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
