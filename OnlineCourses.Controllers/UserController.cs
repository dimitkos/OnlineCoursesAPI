using OnlineCourses.Interfaces;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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


        //[HttpGet]
        //[ActionName("getUsers")]
        //public HttpResponseMessage GetEmployees()
        //{
        //    var response = service.GetAllUsers();
        //    if (response != null)
        //    {
        //        return Request.CreateResponse<List<string>>(HttpStatusCode.OK, response);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Users");
        //    }

        //}

        [HttpGet]
        [ActionName("getAllUsers")]
        public GetUsersResponse GetAllUsers()
        {
            return service.GetUsers();
        }

        [HttpGet]
        [ActionName("getUserById")]
        public GetUserByIdResponse GetUserById([FromBody]int id)
        {
            return service.GetUserById(id);
        }
    }
}
