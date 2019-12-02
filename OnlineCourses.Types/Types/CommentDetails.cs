using System.Runtime.Serialization;

namespace OnlineCourses.Types.Types
{
    [DataContract]
    public class CommentDetails
    {
        [DataMember(Name = "commentAuthor")]
        public string FullName { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }
}
