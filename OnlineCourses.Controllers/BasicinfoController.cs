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
        
        private readonly IService service;

        public BasicinfoController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ActionName("getFrameworks")]
        public HttpResponseMessage GetAllUsers()
        {
            var response = service.GetFrameworks();
            if (response.Frameworks != null)
            {
                return Request.CreateResponse<GetFrameworksResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Frameworks Not Found");
            }
        }
    }
}
