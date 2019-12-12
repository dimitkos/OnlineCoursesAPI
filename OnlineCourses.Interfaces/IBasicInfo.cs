using OnlineCourses.Types.Responses;

namespace OnlineCourses.Interfaces
{
    public interface IBasicInfo
    {
        GetFrameworksResponse FetchFrameworks();

        GetCategoriesResponse FetchCategories();
    }
}
