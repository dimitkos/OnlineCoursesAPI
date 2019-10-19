using OnlineCourses.Types.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation.Helper
{
    public static class Extensions
    {
        public static GetUserByIdRequest ConvertId(this AddNewUserRequest request)
        {
            return new GetUserByIdRequest
            {
                UserId = request.Id
            };
        }

        public static GetUserByIdRequest ConvertId(this UpdateUserDataRequest request)
        {
            return new GetUserByIdRequest
            {
                UserId = request.Id
            };
        }

        public static GetInstructorByIdRequest ConvertInstructorId(this CreateInstructorAccountRequest request)
        {
            return new GetInstructorByIdRequest
            {
                InstructorId = request.Id
            };
        }

        public static GetInstructorByIdRequest ConvertInstructorId(this UpdateInstructorDataRequest request)
        {
            return new GetInstructorByIdRequest
            {
                InstructorId = request.Id
            };
        }
    }
}
