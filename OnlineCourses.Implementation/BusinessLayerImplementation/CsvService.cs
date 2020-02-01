using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Responses;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class CsvService : ICsv
    {
        private readonly IService _dbService;

        public CsvService(IService dbService)
        {
            _dbService = dbService;
        }

        public HttpResponseMessage GetUsersCsv()
        {
            var data = _dbService.GetUsers();

            var result = GenericCsv<Users>.GenerateCsv(data.Users);

            var response = SetResponseMessage(result, "Users.csv");

            return response;
        }

        public HttpResponseMessage GetInctructorsCsv()
        {
            var data = _dbService.GetInstructors();

            var result = GenericCsv<Instructor>.GenerateCsv(data.Instructors);

            var response = SetResponseMessage(result, "Instructors.csv");

            return response;
        }

        public HttpResponseMessage GetCoursesCsv()
        {
            var data = _dbService.GetAllCourses();

            var result = GenericCsv<CourseResponse>.GenerateCsv(data.Courses);

            var response = SetResponseMessage(result, "Courses.csv");

            return response;
        }

        private HttpResponseMessage SetResponseMessage(string result, string fileName)
        {
            HttpResponseMessage csvFile = new HttpResponseMessage(HttpStatusCode.OK);
            csvFile.Content = new StringContent(result);
            csvFile.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            csvFile.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = $"{fileName}" };
            return csvFile;
        }
    }
}
