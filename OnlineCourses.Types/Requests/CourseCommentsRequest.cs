using System.Runtime.Serialization;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class CourseCommentsRequest
    {
        [DataMember(Name = "courseId")]
        public int CourseId { get; set; }
    }
}
