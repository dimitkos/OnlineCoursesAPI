using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class AddNewUserRequest
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "gender")]
        public bool Gender { get; set; }

        [DataMember(Name = "job")]
        public string Job { get; set; }

        [DataMember(Name = "registerDate")]
        public DateTime RegisterDate { get; set; }

    }
}
