using OnlineCourses.Types.DbTypes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetInstructorsResponse
    {
        [DataMember(Name = "instructors")]
        public IEnumerable<Instructor> Instructors { get; set; }
    }
}
