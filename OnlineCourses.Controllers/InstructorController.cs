using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineCourses.Controllers
{
    public class InstructorController : ApiController
    {
        private readonly IInstructor service;

        public InstructorController(IInstructor service)
        {
            this.service = service;
        }

        [HttpGet]
        [ActionName("getInstructors")]
        [ResponseType(typeof(GetInstructorsResponse))]
        public HttpResponseMessage GetInstructors()
        {
            var response = service.FetchInstructors();
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
        [ResponseType(typeof(GetInstructorByIdResponse))]
        public HttpResponseMessage GetInstructorById([FromUri]GetInstructorByIdRequest request)
        {
            var response = service.FetchInstructorById(request);
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
        [AllowAnonymous]
        [ActionName("createInstructorAccount")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage CreateInstructorAccount([FromBody]CreateInstructorAccountRequest request)
        {
            var response = service.CreateNewInstructor(request);

            if (response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to create new instructor");
            }
        }

        [HttpPut]
        [ActionName("updateInstructorData")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage UpdateInstructorData([FromBody]UpdateInstructorDataRequest request)
        {
            var response = service.UpdateInstructor(request);
            if (response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to update instructor data");
            }

        }
    }
}
