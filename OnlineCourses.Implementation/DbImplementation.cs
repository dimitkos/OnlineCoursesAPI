using OnlineCourses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation
{
    public class DbImplementation : IService
    {
        public List<string> GetAllUsers()
        {
            var response = new List<string>
            {
                "dimitris","Andrew"
            };

            return response;
        }
    }
}
