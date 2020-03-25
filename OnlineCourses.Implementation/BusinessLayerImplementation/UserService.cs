using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using OnlineCourses.Types.Types;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class UserService : IUser
    {
        private readonly IService _dbService;
        private readonly IValidation _validation;
        private readonly IEmailProvider _emailProvider;

        public UserService(IService dbService, IValidation validation, IEmailProvider emailProvider)
        {
            _dbService = dbService;
            _validation = validation;
            _emailProvider = emailProvider;
        }

        public GetUsersResponse FetchUsers()
        {
            var cache  = Cache.Get("users", () => _dbService.GetUsers(), 1);//maybe do paging
            return cache;
        }

        public GetUserByIdResponse FetchUserById(GetUserByIdRequest request)
        {
            _validation.NotValidId(request.UserId, $"{nameof(request.UserId)}");

            var cache = Cache.Get(request.UserId.ToString(), () => _dbService.GetUserById(request));
            return cache;
        }

        public bool CreateNewUser(AddNewUserRequest request)
        {
            ValidateUserData(request.ConvertToUserData());

            var result =_dbService.AddNewUser(request);

            if(result)
            {
                _emailProvider.Send(request.Email, request.FullName);
            }

            return result;
        }

        public bool UpdateUser(UpdateUserDataRequest request)
        {
            ValidateUserData(request.ConvertToUserData());

            return _dbService.UpdateUserData(request);
        }

        public bool DeleteUser(DeleteUserAccountRequest request)
        {
            _validation.NotValidId(request.Id, $"{nameof(request.Id)}");

            return _dbService.DeleteUserAccount(request);
        }

        private void ValidateUserData(UserData request)
        {
            _validation.NotValidId(request.Id, $"{nameof(request.Id)}");

            _validation.NotValidField(request.FullName, 50, $"{nameof(request.FullName)}");

            _validation.NotValidField(request.Job, 30, $"{nameof(request.Job)}");

            _validation.NotValidEmail(request.Email);
        }
        
    }
}
