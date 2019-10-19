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
    public class InstructorController : ApiController
    {
        private readonly IService service;

        public InstructorController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ActionName("getInstructors")]
        public HttpResponseMessage GetInstructors()
        {
            var response = service.GetInstructors();
            if (response != null)
            {
                return Request.CreateResponse<GetInstructorsResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Instructors");
            }
        }

        [HttpGet]
        [ActionName("getInstructorById")]
        public HttpResponseMessage getInstructorById([FromBody]GetInstructorByIdRequest request)
        {
            var response = service.GetInstructorById(request);
            if (response.Instructor != null)
            {
                return Request.CreateResponse<GetInstructorByIdResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Instructor Not Found");
            }
        }

        [HttpPost]
        [ActionName("createInstructorAccount")]
        public HttpResponseMessage CreateInstructorAccount([FromBody]CreateInstructorAccountRequest request)
        {
            var response = service.CreateInstructorAccount(request);

            if (response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to create new instructor");
            }
        }
    }
}
