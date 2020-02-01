using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;

namespace OnlineCourses.Interfaces
{
    public interface ICourse
    {
        GetCoursesResponse FetchAllCourses();

        bool AddCourse(AddNewCourseRequest request);

        bool UpdateCourse(UpdateCourseRequest request);

        GetCoursesResponse SearchCourses(SearchCoursesRequest request);

        bool EnrollCourse(EnrollCourseRequest request);

        GetCoursesByInstructorResponse FetchCoursesByInstructor(GetCoursesByInstructorRequest request);

        bool Comment(AddCommentRequest request);

        CourseCommentsResponse FetchCommentsByCourse(CourseCommentsRequest request);

        GetEnrollsByUserResponse FetchEnrollsByStudent(GetEnrollsByUserRequest request);
    }
}
