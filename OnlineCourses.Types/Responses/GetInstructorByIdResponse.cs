using OnlineCourses.Types.DbTypes;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetInstructorByIdResponse
    {
        [DataMember(Name = "instructor")]
        public Instructor Instructor { get; set; }
    }
}
