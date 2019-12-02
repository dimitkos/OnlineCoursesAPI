using Dapper;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using OnlineCourses.Types.Types;
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
            var searchDictionary = SetUpSqlQueurySearchCOurses(request);

            using (var con = GetSqlConnection())
            {
                var response = con.Query<CourseResponse>(searchDictionary.First().Key, searchDictionary.First().Value);

                return new GetCoursesResponse()
                {
                    Courses = response
                };
            }
        }

        public bool EnrollCourse(EnrollCourseRequest request)
        {
            string sql = @"Insert Into enrolls (UserId,CourseId,Comment) VALUES (@UserId,@CourseId,@Comment)";

            int result;
            var parameters = new { request.UserId, request.CourseId, request.Comment};

            using (var con = GetSqlConnection())
            {
                result = con.Execute(sql, parameters);
            }
            return result==1;
        }

        public GetCoursesByInstructorResponse GetCoursesByInstructor(GetCoursesByInstructorRequest request)
        {
            string sqlcourse = @"select c.id,c.title,c.description,c.rating,c.price,ins.fullname as instructorName,cat.name as categoryName,fr.name as frameworkName
                        from course as c
                        inner join instructor as ins
                        on c.instructorId = ins.id
                        inner join category as cat
                        on c.categoryId = cat.categoryId
                        inner join framework as fr
                        on c.frameworkId = fr.frameworkId 
                        Where ins.id=@id";
            string sqlins = @"select * from instructor where id=@id";

            var parameters = new { id = request.InstructorId };

            using (var con = GetSqlConnection())
            {
                var courses = con.Query<CourseResponse>(sqlcourse, parameters);
                var instructors = con.Query<Instructor>(sqlins, parameters).FirstOrDefault();


                return new GetCoursesByInstructorResponse
                {
                    Instructor = instructors,
                    Courses = courses.ToList()
                };
            }
        }

        public bool AddComment(AddCommentRequest request)
        {
            string sql = @"UPDATE enrolls SET Comment = @Comment WHERE UserId = @UserId AND CourseId = @CourseId";
            int result;
            var parameters = new { request.Comment, request.UserId, request.CourseId };

            using (var con = GetSqlConnection())
            {
                result = con.Execute(sql, parameters);
            }
            return result == 1;
        }

        public CourseCommentsResponse GetCommentsByCourse(CourseCommentsRequest request)
        {
            string sql = @"Select us.fullname,en.comment From enrolls as en
                        inner join users as us
                        on en.userId = us.id
                        WHERE en.CourseId = @CourseId";
            var parameters = new { request.CourseId };
            using (var con = GetSqlConnection())
            {
                var response = con.Query<CommentDetails>(sql,parameters).ToList();

                return new CourseCommentsResponse
                {
                    CommentDetails = response
                };
            }
            
        }

        #region private methods
        private Dictionary<string, DynamicParameters> SetUpSqlQueurySearchCOurses(SearchCoursesRequest request)
        {
            Dictionary<string, DynamicParameters> searchDictionary = new Dictionary<string, DynamicParameters>();
            var dynamicParameters = new DynamicParameters();

            string sql = SqlQueurySearchCOurses();

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                sql += " AND c.title LIKE '%' + @Title + '%' ";
                dynamicParameters.Add("@Title", request.Title);

            }

            if (!string.IsNullOrWhiteSpace(request.InstructorName))
            {
                sql += " AND ins.fullname = @fullname ";
                dynamicParameters.Add("@fullname", request.InstructorName);
            }

            if (!string.IsNullOrWhiteSpace(request.FrameworkName))
            {
                sql += " AND fr.name = @Framework ";
                dynamicParameters.Add("@Framework", request.FrameworkName);
            }

            if (!string.IsNullOrWhiteSpace(request.CategoryName))
            {
                sql += " AND cat.name = @CategoryName ";
                dynamicParameters.Add("@CategoryName", request.CategoryName);
            }

            if (request.UpPrice.HasValue && request.DownPrice.HasValue && request.DownPrice < request.UpPrice)
            {
                sql += " AND c.price Between @DownPrice And @UpPrice ";
                dynamicParameters.Add("@DownPrice", request.DownPrice);
                dynamicParameters.Add("@UpPrice", request.UpPrice);
            }

            if (request.UpRating.HasValue && request.DownRating.HasValue && request.DownRating < request.UpRating)
            {
                sql += " AND c.rating Between @DownRating And @UpRating ";
                dynamicParameters.Add("@DownRating", request.DownRating);
                dynamicParameters.Add("@UpRating", request.UpRating);
            }

            searchDictionary.Add(sql, dynamicParameters);
            return searchDictionary;
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
        #endregion

        #region Sql Query
        private string SqlQueurySearchCOurses()
        {
            string sql = @"select c.id,c.title,c.description,c.rating,c.price,ins.fullname as instructorName,cat.name as categoryName,fr.name as frameworkName
                        from course as c
                        inner join instructor as ins
                        on c.instructorId = ins.id
                        inner join category as cat
                        on c.categoryId = cat.categoryId
                        inner join framework as fr
                        on c.frameworkId = fr.frameworkId 
                        Where 1=1";
            return sql;
        }
        #endregion
    }
}
