using System.Runtime.Serialization;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class EnrollCourseRequest
    {
        [DataMember(Name = "userId")]
        public int UserId { get; set; }

        [DataMember(Name = "courseId")]
        public int CourseId { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }
}
