using OnlineCourses.Types.DbTypes;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetUserByIdResponse
    {
        [DataMember(Name = "user")]
        public Users User { get; set; }
    }
}
