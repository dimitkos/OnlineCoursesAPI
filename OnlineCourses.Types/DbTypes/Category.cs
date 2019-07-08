using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Types.DbTypes
{
    [DataContract]
    public class Category
    {
        [DataMember(Name = "categoryId")]
        public string CategoryId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
