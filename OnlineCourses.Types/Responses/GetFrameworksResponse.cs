using OnlineCourses.Types.DbTypes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetFrameworksResponse
    {
        [DataMember(Name = "frameworks")]
        public IEnumerable<Framework> Frameworks { get; set; }
    }
}
