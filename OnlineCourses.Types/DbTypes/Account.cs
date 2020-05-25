using System.Runtime.Serialization;

namespace OnlineCourses.Types.DbTypes
{
    public class Account
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "password")]
        public string HashedPassword { get; set; }

    }
}
