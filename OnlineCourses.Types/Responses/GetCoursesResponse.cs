using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetCoursesResponse
    {
        [DataMember(Name = "courses")]
        public IEnumerable<CourseResponse> Courses { get; set; }
    }
}
