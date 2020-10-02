using OnlineCourses.Interfaces;
using OnlineCourses.Types.Responses;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineCourses.Controllers
{
    public class BasicinfoController : ApiController
    {
        private readonly IBasicInfo _service;

        public BasicinfoController(IBasicInfo service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("getFrameworks")]
        [ResponseType(typeof(GetFrameworksResponse))]
        public HttpResponseMessage GetFrameworks()
        {
            var response = _service.FetchFrameworks();
            if (response.Frameworks != null)
            {
                return Request.CreateResponse<GetFrameworksResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Frameworks Not Found");
            }
        }

        [HttpGet]
        [ActionName("getCategories")]
        [ResponseType(typeof(GetCategoriesResponse))]
        public HttpResponseMessage GetCategories()
        {
            var response = _service.FetchCategories();
            if (response.Categories != null)
            {
                return Request.CreateResponse<GetCategoriesResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Categories Not Found");
            }
        }
    }
}
