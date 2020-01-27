using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;

namespace OnlineCourses.Interfaces
{
    public interface IInstructor
    {
        GetInstructorsResponse FetchInstructors();

        GetInstructorByIdResponse FetchInstructorById(GetInstructorByIdRequest request);

        bool CreateNewInstructor(CreateInstructorAccountRequest request);

        bool UpdateInstructor(UpdateInstructorDataRequest request);
    }
}
