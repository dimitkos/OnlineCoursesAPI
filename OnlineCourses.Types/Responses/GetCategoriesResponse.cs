using OnlineCourses.Types.DbTypes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OnlineCourses.Types.Responses
{
    [DataContract]
    public class GetCategoriesResponse
    {
        [DataMember(Name = "categories")]
        public IEnumerable<Category> Categories { get; set; }
    }
}
