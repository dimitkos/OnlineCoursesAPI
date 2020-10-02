using OnlineCourses.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace OnlineCourses.Controllers
{
    public class CsvController : ApiController
    {
        private readonly ICsv _service;

        public CsvController(ICsv service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("getCsvUsers")]
        public HttpResponseMessage GetCsvUsers()
        {
            var response = _service.GetUsersCsv();

            return response;
        }

        [HttpGet]
        [ActionName("getCsvInstructors")]
        public HttpResponseMessage GetCsvInstructors()
        {
            var response = _service.GetInctructorsCsv();

            return response;
        }

        [HttpGet]
        [ActionName("getCsvCourses")]
        public HttpResponseMessage GetCsvCourses()
        {
            var response = _service.GetCoursesCsv();

            return response;
        }
    }
}
