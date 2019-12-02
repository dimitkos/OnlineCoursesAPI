using System.Runtime.Serialization;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class GetEnrollsByUserRequest
    {
        [DataMember(Name = "userId")]
        public int UserId { get; set; }
    }
}
