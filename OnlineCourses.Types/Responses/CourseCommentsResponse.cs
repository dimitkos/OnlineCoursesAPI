using OnlineCourses.Types.Types;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class CourseCommentsResponse
    {
        [DataMember(Name = "commentDetails")]
        public List<CommentDetails> CommentDetails { get; set; }
    }
}
