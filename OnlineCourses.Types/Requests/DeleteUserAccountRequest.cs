using System.Runtime.Serialization;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class DeleteUserAccountRequest
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
