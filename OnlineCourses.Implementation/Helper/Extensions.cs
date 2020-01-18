using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Types;
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

        public static UserData ConvertToUserData(this AddNewUserRequest request)
        {
            return new UserData
            {
                Id = request.Id,
                FullName = request.FullName,
                Email = request.Email,
                Job = request.Job
            };
        }

        public static UserData ConvertToUserData(this UpdateUserDataRequest request)
        {
            return new UserData
            {
                Id = request.Id,
                FullName = request.FullName,
                Email = request.Email,
                Job = request.Job
            };
        }
    }
}
