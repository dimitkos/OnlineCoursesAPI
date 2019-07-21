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
    public class GetFrameworksResponse
    {
        [DataMember(Name = "frameworks")]
        public IEnumerable<Framework> Frameworks { get; set; }
    }
}
