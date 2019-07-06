using OnlineCourses.Types.DbTypes;
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

        GetUserByIdResponse GetUserById(int userId);

        GetInstructorsResponse GetInstructors();
    }
}
