using System.Runtime.Serialization;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class GetInstructorByIdRequest
    {
        [DataMember(Name = "instructorId")]
        public int InstructorId { get; set; }
    }
}
