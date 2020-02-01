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
        public HttpResponseMessage GetCsvUsers()
        {
            var response = service.GetUsersCsv();

            return response;
        }

        [HttpGet]
        [ActionName("getCsvInstructors")]
        public HttpResponseMessage GetCsvInstructors()
        {
            var response = service.GetInctructorsCsv();

            return response;
        }

        [HttpGet]
        [ActionName("getCsvCourses")]
        public HttpResponseMessage GetCsvCourses()
        {
            var response = service.GetCoursesCsv();

            return response;
        }
    }
}
