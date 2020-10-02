using OnlineCourses.Types.DbTypes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetUsersResponse
    {
        [DataMember(Name = "users")]
        public IEnumerable<Users> Users { get; set; }
    }
}
