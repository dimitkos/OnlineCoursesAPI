using System.Runtime.Serialization;

namespace OnlineCourses.Types.Types
{
    [DataContract]
    public class InstructorData
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "bio")]
        public string Bio { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }
    }
}
