using Dapper;
using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.DbTypes;
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
                    Instructors = response
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
                    if(GetInstructorById(request.ConvertInstructorId()).Instructors == null)
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

    }
}
