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
    public class BasicinfoController : ApiController
    {
        
        private readonly IBasicInfo service;

        public BasicinfoController(IBasicInfo service)
        {
            this.service = service;
        }

        [HttpGet]
        [ActionName("getFrameworks")]
        public HttpResponseMessage GetFrameworks()
        {
            var response = service.FetchFrameworks();
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
        public HttpResponseMessage GetCategories()
        {
            var response = service.FetchCategories();
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
