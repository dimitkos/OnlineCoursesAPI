using OnlineCourses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineCourses.Controllers
{
    public class UserController :ApiController
    {
        private readonly IService service;

        public UserController(IService service)
        {
            this.service = service;
        }


        [HttpGet]
        [ActionName("getUsers")]
        public List<string> GetEmployees()
        {
            return service.GetAllUsers();

        }
    }
}
