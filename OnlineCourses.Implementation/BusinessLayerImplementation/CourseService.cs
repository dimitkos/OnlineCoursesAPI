using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using OnlineCourses.Types.Types;
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
            ValidateNewCourse(request);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return _dbService.AddNewCourse(request);
        }

        public bool UpdateCourse(UpdateCourseRequest request)
        {
            ValidateUpdatedCourse(request);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return _dbService.UpdateCourse(request);
        }

        public GetCoursesResponse SearchCourses(SearchCoursesRequest request)
        {
            //na kanw elegxo???mallon mono sta oria
            return _dbService.SearchCourses(request);
        }

        public bool Comment(AddCommentRequest request)
        {
            ValidateComment(request);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return _dbService.AddComment(request);
        }

        public bool EnrollCourse(EnrollCourseRequest request)
        {
            ValidateEnrollment(request);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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

        private void ValidateNewCourse(AddNewCourseRequest request)
        {
            _validation.NotValidId(request.Id, $"{nameof(request.Id)}");

            _validation.NotValidId(request.InstructorId, $"{nameof(request.Id)}");

            _validation.NotValidField(request.FrameworkId, 3, $"{nameof(request.FrameworkId)}");//check 3

            _validation.NotValidField(request.CategoryId, 3, $"{nameof(request.CategoryId)}");//check 3

            _validation.NotValidField(request.Title, 20, $"{nameof(request.Title)}");//check 20

            _validation.NotValidField(request.Title, 20, $"{nameof(request.Description)}");//check 20

            //must implement a check also rate and price
        }

        private void ValidateUpdatedCourse(UpdateCourseRequest request)
        {
            _validation.NotValidId(request.Id, $"{nameof(request.Id)}");

            _validation.NotValidField(request.Title, 20, $"{nameof(request.Title)}");//check 20

            _validation.NotValidField(request.Title, 20, $"{nameof(request.Description)}");//check 20

            //must implement also a ckeck decimal price
        }

        private void ValidateComment(AddCommentRequest request)
        {
            _validation.NotValidId(request.UserId, $"{nameof(request.UserId)}");

            _validation.NotValidId(request.CourseId, $"{nameof(request.CourseId)}");

            _validation.NotValidField(request.Comment, 50, $"{nameof(request.Comment)}");//na tsekarw ksana to 50
        }

        private void ValidateEnrollment(EnrollCourseRequest request)
        {
            _validation.NotValidId(request.UserId, $"{nameof(request.UserId)}");

            _validation.NotValidId(request.CourseId, $"{nameof(request.CourseId)}");

            _validation.NotValidField(request.Comment, 50, $"{nameof(request.Comment)}");//na tsekarw ksana to 50
        }

    }
}
