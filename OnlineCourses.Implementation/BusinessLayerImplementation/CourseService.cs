using System;
using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;

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
            ValidateNewCourse(request);
            return _dbService.AddNewCourse(request);
        }

        public bool UpdateCourse(UpdateCourseRequest request)
        {
            ValidateUpdatedCourse(request);
            return _dbService.UpdateCourse(request);
        }

        public GetCoursesResponse SearchCourses(SearchCoursesRequest request)
        {
            return _dbService.SearchCourses(request);
        }

        public bool Comment(AddCommentRequest request)
        {
            ValidateComment(request);
            return _dbService.AddComment(request);
        }

        public bool EnrollCourse(EnrollCourseRequest request)
        {
            ValidateEnrollment(request);
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

        #region private validation methods
        private void ValidateNewCourse(AddNewCourseRequest request)
        {
            _validation.NotValidId(request.Id, $"{nameof(request.Id)}");

            _validation.NotValidId(request.InstructorId, $"{nameof(request.Id)}");

            _validation.NotValidField(request.FrameworkId, 5, $"{nameof(request.FrameworkId)}");

            _validation.NotValidField(request.CategoryId, 3, $"{nameof(request.CategoryId)}");

            _validation.NotValidField(request.Title, 100, $"{nameof(request.Title)}");

            _validation.NotValidField(request.Description, 500, $"{nameof(request.Description)}");

            _validation.NotValidRating(request.Rating, $"{nameof(request.Rating)}");

            _validation.NotValidPrice(request.Price, $"{nameof(request.Price)}");
        }

        private void ValidateUpdatedCourse(UpdateCourseRequest request)
        {
            _validation.NotValidId(request.Id, $"{nameof(request.Id)}");

            _validation.NotValidField(request.Title, 100, $"{nameof(request.Title)}");

            _validation.NotValidField(request.Description, 500, $"{nameof(request.Description)}");

            _validation.NotValidPrice(request.Price, $"{nameof(request.Price)}");
        }

        private void ValidateComment(AddCommentRequest request)
        {
            _validation.NotValidId(request.UserId, $"{nameof(request.UserId)}");

            _validation.NotValidId(request.CourseId, $"{nameof(request.CourseId)}");

            _validation.NotValidField(request.Comment, 500, $"{nameof(request.Comment)}");
        }

        private void ValidateEnrollment(EnrollCourseRequest request)
        {
            _validation.NotValidId(request.UserId, $"{nameof(request.UserId)}");

            _validation.NotValidId(request.CourseId, $"{nameof(request.CourseId)}");

            _validation.NotValidField(request.Comment, 500, $"{nameof(request.Comment)}");
        }
        #endregion
    }
}
