using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class GetCoursesByInstructorRequest
    {
        [DataMember(Name = "instructorId")]
        public int InstructorId { get; set; }
    }
}
