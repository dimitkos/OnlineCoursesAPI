using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineCourses.Controllers
{
    public class CourseController : ApiController
    {
        private readonly IService service;

        public CourseController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ActionName("getCourses")]
        public HttpResponseMessage GetAllCourses()
        {
            var response = service.GetAllCourses();
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
        public HttpResponseMessage AddNewCourse([FromBody] AddNewCourseRequest request)
        {
            var response = service.AddNewCourse(request);
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
        public HttpResponseMessage UpdateCourse([FromBody] UpdateCourseRequest request)
        {
            var response = service.UpdateCourse(request);
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
        public HttpResponseMessage SearchCourses([FromBody]SearchCoursesRequest request)
        {
            var response = service.SearchCourses(request);

            if (response.Courses.ToList().Count > 0 )
            {
                return Request.CreateResponse<GetCoursesResponse>(HttpStatusCode.OK, response);
            }
            else if(response.Courses.ToList().Count == 0)
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
        public HttpResponseMessage GetCoursesByInstructor([FromBody]GetCoursesByInstructorRequest request)
        {
            var response = service.GetCoursesByInstructor(request);
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
        public HttpResponseMessage enrollCourse([FromBody] EnrollCourseRequest request)
        {
            var response = service.EnrollCourse(request);
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
        public HttpResponseMessage AddComment([FromBody] AddCommentRequest request)
        {
            var response = service.AddComment(request);
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
        public HttpResponseMessage GetComments([FromBody]CourseCommentsRequest request)
        {
            var response = service.GetCommentsByCourse(request);
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
        public HttpResponseMessage GetCoursesByUser([FromBody]GetEnrollsByUserRequest request)
        {
            var response = service.GetEnrollsByStudent(request);
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
