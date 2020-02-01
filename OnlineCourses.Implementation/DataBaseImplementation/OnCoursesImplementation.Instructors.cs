using Dapper;
using OnlineCourses.Implementation.Helper;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System;
using System.Linq;

namespace OnlineCourses.Implementation.DataBaseImplementation
{
    public partial class OnCoursesImplementation 
    {
        public GetInstructorsResponse GetInstructors()
        {
            string sql = @"Select * From instructor";
            using (var con = GetSqlConnection())
            {
                var response = con.Query<Instructor>(sql);
                return new GetInstructorsResponse()
                {
                    Instructors = response
                };
            }
        }

        public GetInstructorByIdResponse GetInstructorById(GetInstructorByIdRequest request)
        {
            string sql = @"Select * From instructor Where id=@id";
            var parameters = new { id = request.InstructorId };

            using (var con = GetSqlConnection())
            {
                var response = con.Query<Instructor>(sql, parameters).SingleOrDefault();
                return new GetInstructorByIdResponse
                {
                    Instructor = response
                };
            }
        }

        public bool CreateInstructorAccount(CreateInstructorAccountRequest request)
        {
            string sql = @"INSERT INTO Instructor (Id,FullName,Email,Bio,Language) VALUES (@Id,@FullName,@Email,@Bio,@Language)";
            int result;
            var parameters = new {request.Id,request.FullName,request.Email,request.Bio,request.Language};
            using (var con = GetSqlConnection())
            {
                using (var transaction = con.BeginTransaction())
                {
                    if(GetInstructorById(request.ConvertInstructorId()).Instructor == null)
                    {
                        result = con.Execute(sql, parameters, transaction: transaction);
                    }
                    else
                    {
                        throw new Exception("The instructor id is existing");
                    }
                    transaction.Commit();
                }
            }
            return result == 1;
        }

        public bool UpdateInstructorData(UpdateInstructorDataRequest request)
        {
            string sql = @"UPDATE Instructor SET FullName = @FullName, Email = @Email,Bio = @Bio ,Language = @Language WHERE Id = @Id ";
            int result;
            var parameters = new { request.Id, request.FullName, request.Email, request.Bio ,request.Language };
            using (var con = GetSqlConnection())
            {
                using (var transaction = con.BeginTransaction())
                {
                    if (GetInstructorById(request.ConvertInstructorId()).Instructor != null)
                    {
                        result = con.Execute(sql, parameters, transaction: transaction);
                    }
                    else
                    {
                        throw new Exception("Instructor does not exist");
                    }
                    transaction.Commit();
                }
            }
            return result == 1;
        }

    }
}
