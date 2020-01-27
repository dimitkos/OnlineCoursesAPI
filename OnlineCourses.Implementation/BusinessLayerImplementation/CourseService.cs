using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class CourseService : ICourse
    {
        private readonly IService _dbService;
        private readonly IValidation _validation;

        public CourseService(IService dbService, IValidation validation)
        {
            _dbService = dbService;
            _validation = validation;
        }

        public GetCoursesResponse FetchAllCourses()
        {
            var cache = Cache.Get("courses", () => _dbService.GetAllCourses(), 1);
            return cache;
        }

        public bool AddCourse(AddNewCourseRequest request)
        {
            ValidateCourse();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return _dbService.AddNewCourse(request);
        }

        public bool UpdateCourse(UpdateCourseRequest request)
        {
            ValidateCourse();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return _dbService.UpdateCourse(request);
        }

        public GetCoursesResponse SearchCourses(SearchCoursesRequest request)
        {
            return _dbService.SearchCourses(request);
        }

        public bool Comment(AddCommentRequest request)
        {
            ValidateComment();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return _dbService.AddComment(request);
        }

        public bool EnrollCourse(EnrollCourseRequest request)
        {
            ValidateComment();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return _dbService.EnrollCourse(request);
        }

        public CourseCommentsResponse FetchCommentsByCourse(CourseCommentsRequest request)
        {
            _validation.NotValidId(request.CourseId, $"{nameof(request.CourseId)}");

            return _dbService.GetCommentsByCourse(request);
        }

        public GetCoursesByInstructorResponse FetchCoursesByInstructor(GetCoursesByInstructorRequest request)
        {
            _validation.NotValidId(request.InstructorId, $"{nameof(request.InstructorId)}");

            return _dbService.GetCoursesByInstructor(request);
        }

        public GetEnrollsByUserResponse FetchEnrollsByStudent(GetEnrollsByUserRequest request)
        {
            _validation.NotValidId(request.UserId, $"{nameof(request.UserId)}");

            return _dbService.GetEnrollsByStudent(request);
        }

        private void ValidateCourse()
        {
            throw new NotImplementedException();
        }

        private void ValidateComment()
        {
            throw new NotImplementedException();
        }

    }
}
