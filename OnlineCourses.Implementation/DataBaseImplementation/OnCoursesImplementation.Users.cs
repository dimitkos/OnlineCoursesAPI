using Dapper;
using OnlineCourses.Implementation.Helper;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public GetUserByIdResponse GetUserById(GetUserByIdRequest request)
        {
            string sql = @"Select * From users Where id=@id";
            var parameters = new {id = request.UserId };

            using (var con = GetSqlConnection())
            {
                var response = con.Query<Users>(sql,parameters).FirstOrDefault();//na to kanw firtstordefault
                return new GetUserByIdResponse
                {
                    User = response
                };
            }
        }

        public bool AddNewUser(AddNewUserRequest request)
        {
            string sql = @"INSERT INTO Users (Id,FullName,Email,Gender,Job,RegisterDate) VALUES (@Id,@FullName,@Email,@Gender,@Job,@RegisterDate)";
            int result;
            var parameters = new {request.Id,request.FullName,request.Email,request.Gender,request.Job,RegisterDate=DateTime.Now};
            using (var con = GetSqlConnection())
            {
                using (var transaction = con.BeginTransaction())
                {
                    if(GetUserById(request.ConvertId()).User == null)
                    {
                        result = con.Execute(sql, parameters, transaction: transaction);
                    }
                    else
                    {
                        throw new Exception("The user id is existing");
                    }
                    transaction.Commit();
                }
            }
            return result==1;
        }

        public bool UpdateUserData(UpdateUserDataRequest request)
        {
            string sql = @"UPDATE Users SET FullName = @FullName, Email = @Email,Job = @Job WHERE Id = @Id ";
            int result;
            var parameters = new {request.Id,request.FullName,request.Email,request.Job };

            using (var con = GetSqlConnection())
            {
                using (var transaction = con.BeginTransaction())
                {
                    if (GetUserById(request.ConvertId()).User != null)
                    {
                        result = con.Execute(sql, parameters, transaction: transaction);
                    }
                    else
                    {
                        throw new Exception("User does not exist");
                    }
                    transaction.Commit();
                }
            }
            return result == 1;
        }
    }
}
