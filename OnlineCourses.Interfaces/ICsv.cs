using System.Net.Http;

namespace OnlineCourses.Interfaces
{
    public interface ICsv
    {
        HttpResponseMessage GetUsersCsv();

        HttpResponseMessage GetInctructorsCsv();

        HttpResponseMessage GetCoursesCsv();
    }
}
