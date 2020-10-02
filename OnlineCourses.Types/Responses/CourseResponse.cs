using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class CourseResponse
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "rating")]
        public decimal Rating { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "instructorName")]
        public string InstructorName { get; set; }

        [DataMember(Name = "categoryrName")]
        public string CategoryName { get; set; }

        [DataMember(Name = "frameworkName")]
        public string FrameworkName { get; set; }
    }
}
