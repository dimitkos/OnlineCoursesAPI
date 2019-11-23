using OnlineCourses.Types.DbTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetCoursesByInstructorResponse
    {
        [DataMember(Name = "instructor")]
        public Instructor Instructor { get; set; }

        [DataMember(Name = "courses")]
        public  List<CourseResponse> Courses { get; set; }
    }
}
