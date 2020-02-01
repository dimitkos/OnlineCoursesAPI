using OnlineCourses.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace OnlineCourses.Controllers
{
    public class CsvController : ApiController
    {
        private readonly ICsv service;

        public CsvController(ICsv service)
        {
            this.service = service;
        }

        [HttpGet]
        [ActionName("getCsvUsers")]
        public HttpResponseMessage GetCsv()
        {
            var response = service.GetCsv();

            return response;
        }
    }
}
