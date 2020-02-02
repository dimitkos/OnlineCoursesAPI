using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetCoursesResponse
    {
        [DataMember(Name = "courses")]
        public IEnumerable<CourseResponse> Courses { get; set; }
    }
}
