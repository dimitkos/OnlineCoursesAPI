using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class GetUserByIdRequest
    {
        [DataMember(Name = "userId")]
        public int UserId { get; set; }
    }
}
