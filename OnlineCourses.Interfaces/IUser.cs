using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;

namespace OnlineCourses.Interfaces
{
    public interface IUser
    {
        GetUsersResponse FetchUsers();

        GetUserByIdResponse FetchUserById(GetUserByIdRequest request);

        bool CreateNewUser(AddNewUserRequest request);

        bool UpdateUser(UpdateUserDataRequest request);

        bool DeleteUser(DeleteUserAccountRequest request);
    }
}
