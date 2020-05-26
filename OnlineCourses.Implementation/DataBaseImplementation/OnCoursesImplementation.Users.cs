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
#warning remove this
        private List<Account> accountDb = new List<Account>();

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

        public bool DeleteUserAccount(DeleteUserAccountRequest request)
        {
            string sql = @"Delete from Users  WHERE Id = @Id ";
            int result;
            var parameters = new { request.Id};

            using (var con = GetSqlConnection())
            {
                result = con.Execute(sql, parameters);
            }

            return result == 1;
        }

#warning must create the db
        //better for testing purpose to implement in memory

        public bool AddAccount(AddNewUserRequest request)
        {
            //var accountDb = new List<Account>();

            var account = new Account
            {
                Id = request.Id,
                Email = request.Email,
                HashedPassword = request.Password
            };

            accountDb.Add(account);

            return true;

            //string sql = @"INSERT INTO Account (Id,Email,Password) VALUES (@Id@Email,@Password)";
            //int result;
            //var parameters = new { request.Id,request.Email, request.Password };
            //using (var con = GetSqlConnection())
            //{
            //    result = con.Execute(sql, parameters);
            //}

            //return result == 1;
        }

#warning must change the code
        public Account GetUserByIdAndEmail(LoginRequest request)
        {

            var accountInsert = new Account
            {
                Id = 1250,
                Email = "test@gmail.com",
                HashedPassword = "AMqzaDTQ7Ttmj/7Jnh0cZpa31uLddfgl7eP+IVOnlo7yjUM2oA1ytnXAZiVee0lPbQ=="
            };

            accountDb.Add(accountInsert);

            var account = accountDb.FirstOrDefault( x => x.Id == request.Id && x.Email == request.Email);

            return account;
            //must create account table id,mail,pass and must return an account type
            //string sql = @"Select * From accounts Where id=@id and email=@email";
            //var parameters = new { id = request.Id, email = request.Email };

            //using (var con = GetSqlConnection())
            //{
            //    var account = con.Query<Account>(sql, parameters).FirstOrDefault();

            //    return account;
            //}
        }
    }
}
