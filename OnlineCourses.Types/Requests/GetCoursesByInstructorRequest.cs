using System.Runtime.Serialization;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class GetCoursesByInstructorRequest
    {
        [DataMember(Name = "instructorId")]
        public int InstructorId { get; set; }
    }
}
