using System.Runtime.Serialization;

namespace OnlineCourses.Types.Types
{
    [DataContract]
    public class CourseValidationData
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

        [DataMember(Name = "categoryId")]
        public string CategoryId { get; set; }

        [DataMember(Name = "frameworkId")]
        public string FrameworkId { get; set; }

        [DataMember(Name = "instructorId")]
        public int InstructorId { get; set; }
    }
}
