using OnlineCourses.Types.DbTypes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetCoursesByInstructorResponse
    {
        [DataMember(Name = "instructor")]
        public Instructor Instructor { get; set; }

        [DataMember(Name = "courses")]
        public  List<CourseResponse> Courses { get; set; }
    }
}
