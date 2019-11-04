using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Types.DbTypes
{
    [DataContract]
    public class EnrollCourse
    {
        [DataMember(Name = "userId")]
        public int UserId { get; set; }

        [DataMember(Name = "courseId")]
        public int CourseId { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }
}
