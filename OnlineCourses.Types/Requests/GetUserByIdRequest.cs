using System.Runtime.Serialization;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class GetUserByIdRequest
    {
        [DataMember(Name = "userId")]
        public int UserId { get; set; }
    }
}
