using OnlineCourses.Interfaces;
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
    }
}
