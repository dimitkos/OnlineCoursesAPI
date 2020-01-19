using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
