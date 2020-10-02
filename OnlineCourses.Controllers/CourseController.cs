using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineCourses.Controllers
{
    public class CourseController : ApiController
    {
        private readonly ICourse _service;

        public CourseController(ICourse course)
        {
            _service = course;
        }

        [HttpGet]
        [ActionName("getCourses")]
        [ResponseType(typeof(GetCoursesResponse))]
        public HttpResponseMessage GetAllCourses()
        {
            var response = _service.FetchAllCourses();
            if (response.Courses != null)
            {
                return Request.CreateResponse<GetCoursesResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No courses found");
            }
        }

        [HttpPost]
        [ActionName("addNewCourse")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage AddNewCourse([FromBody] AddNewCourseRequest request)
        {
            var response = _service.AddCourse(request);
            if (response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No course added");
            }
        }

        [HttpPut]
        [ActionName("updateCourse")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage UpdateCourse([FromBody] UpdateCourseRequest request)
        {
            var response = _service.UpdateCourse(request);
            if (response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cannot update course");
            }
        }

        [HttpGet]
        [ActionName("searchCourses")]
        [ResponseType(typeof(GetCoursesResponse))]
        public HttpResponseMessage SearchCourses([FromBody] SearchCoursesRequest request)
        {
            var response = _service.SearchCourses(request);

            if (response.Courses.ToList().Count > 0)
            {
                return Request.CreateResponse<GetCoursesResponse>(HttpStatusCode.OK, response);
            }
            else if (response.Courses.ToList().Count == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No courses found");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something went wrong...");
            }
        }

        [HttpGet]
        [ActionName("getCoursesByInstructor")]
        [ResponseType(typeof(GetCoursesByInstructorResponse))]
        public HttpResponseMessage GetCoursesByInstructor([FromBody] GetCoursesByInstructorRequest request)
        {
            var response = _service.FetchCoursesByInstructor(request);
            if (response.Instructor != null && response.Courses != null)
            {
                return Request.CreateResponse<GetCoursesByInstructorResponse>(HttpStatusCode.OK, response);
            }
            else if (response.Instructor != null && response.Courses == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "This instructor has no courses");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something went wrong...");
            }
        }

        [HttpPost]
        [ActionName("enrollCourse")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage EnrollCourse([FromBody] EnrollCourseRequest request)
        {
            var response = _service.EnrollCourse(request);
            if (response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course Not Enrolled");
            }
        }

        [HttpPut]
        [ActionName("addComment")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage AddComment([FromBody] AddCommentRequest request)
        {
            var response = _service.Comment(request);
            if (response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cannot add comment,something went wrong..");
            }
        }

        [HttpGet]
        [ActionName("getComments")]
        [ResponseType(typeof(CourseCommentsResponse))]
        public HttpResponseMessage GetComments([FromBody] CourseCommentsRequest request)
        {
            var response = _service.FetchCommentsByCourse(request);
            if (response.CommentDetails != null)
            {
                return Request.CreateResponse<CourseCommentsResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Comments found");
            }
        }

        [HttpGet]
        [ActionName("getCoursesByUser")]
        [ResponseType(typeof(GetEnrollsByUserResponse))]
        public HttpResponseMessage GetCoursesByUser([FromBody] GetEnrollsByUserRequest request)
        {
            var response = _service.FetchEnrollsByStudent(request);
            if (response.Courses != null && response.User != null)
            {
                return Request.CreateResponse<GetEnrollsByUserResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something went wrong...");
            }
        }
    }
}
