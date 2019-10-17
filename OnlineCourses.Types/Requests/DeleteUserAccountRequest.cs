using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class DeleteUserAccountRequest
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
