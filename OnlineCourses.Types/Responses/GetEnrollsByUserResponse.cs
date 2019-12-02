using OnlineCourses.Types.DbTypes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetEnrollsByUserResponse
    {
        [DataMember(Name = "user")]
        public Users User { get; set; }

        [DataMember(Name = "courses")]
        public List<CourseResponse> Courses { get; set; }
    }
}
