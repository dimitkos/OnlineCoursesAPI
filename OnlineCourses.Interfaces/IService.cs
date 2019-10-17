using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Interfaces
{
    public interface IService
    {
        GetUsersResponse GetUsers();

        GetUserByIdResponse GetUserById(GetUserByIdRequest request);

        GetInstructorsResponse GetInstructors();

        GetFrameworksResponse GetFrameworks();

        GetCategoriesResponse GetCategories();

        GetInstructorByIdResponse GetInstructorById(GetInstructorByIdRequest request);

        bool AddNewUser(AddNewUserRequest request);

        bool UpdateUserData(UpdateUserDataRequest request);

        bool DeleteUserAccount(DeleteUserAccountRequest request);
    }
}
