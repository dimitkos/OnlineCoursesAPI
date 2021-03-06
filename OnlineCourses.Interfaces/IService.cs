﻿using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;

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

        bool CreateInstructorAccount(CreateInstructorAccountRequest request);

        bool UpdateInstructorData(UpdateInstructorDataRequest request);

        GetCoursesResponse GetAllCourses();

        bool AddNewCourse(AddNewCourseRequest request);

        bool UpdateCourse(UpdateCourseRequest request);

        GetCoursesResponse SearchCourses(SearchCoursesRequest request);

        bool EnrollCourse(EnrollCourseRequest request);

        GetCoursesByInstructorResponse GetCoursesByInstructor(GetCoursesByInstructorRequest request);

        bool AddComment(AddCommentRequest request);

        CourseCommentsResponse GetCommentsByCourse(CourseCommentsRequest request);

        GetEnrollsByUserResponse GetEnrollsByStudent(GetEnrollsByUserRequest request);
    }
}
