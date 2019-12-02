using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class CourseCommentsResponse
    {
        [DataMember(Name = "courseId")]
        public List<string> Comments { get; set; }
    }
}
