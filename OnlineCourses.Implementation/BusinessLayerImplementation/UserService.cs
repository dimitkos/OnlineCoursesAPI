using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using OnlineCourses.Types.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class UserService : IUser
    {
        private readonly IService _dbService;
        private readonly IValidation _validation;

        public UserService(IService dbService, IValidation validation)
        {
            _dbService = dbService;
            _validation = validation;
        }

        public GetUsersResponse FetchUsers()
        {
            var cache  = Cache.Get("users", () => _dbService.GetUsers(), 1);//maybe do paging
            return cache;
        }

        public GetUserByIdResponse FetchUserById(GetUserByIdRequest request)
        {
            _validation.NotValidId(request.UserId);

            var cache = Cache.Get(request.UserId.ToString(), () => _dbService.GetUserById(request));
            return cache;
        }

        public bool CreateNewUser(AddNewUserRequest request)
        {
            ValidateUserData(request.ConvertToUserData());

            return _dbService.AddNewUser(request);
        }

        public bool UpdateUser(UpdateUserDataRequest request)
        {
            ValidateUserData(request.ConvertToUserData());

            return _dbService.UpdateUserData(request);
        }

        public bool DeleteUser(DeleteUserAccountRequest request)
        {
            _validation.NotValidId(request.Id);

            return _dbService.DeleteUserAccount(request);
        }

        private void ValidateUserData(UserData request)
        {
            _validation.NotValidId(request.Id);

            _validation.NotValidField(request.FullName, 50);

            _validation.NotValidField(request.Job, 20);

            _validation.NotValidEmail(request.Email);
        }
        
    }
}
