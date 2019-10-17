using OnlineCourses.Interfaces;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Requests;
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

        [HttpGet]
        [ActionName("getAllUsers")]
        public HttpResponseMessage GetAllUsers()
        {
            var response = service.GetUsers();
            if(response.Users != null)
            {
                return Request.CreateResponse<GetUsersResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Users Not Found");
            }
        }

        [HttpGet]
        [ActionName("getUserById")]
        public HttpResponseMessage GetUserById([FromBody]GetUserByIdRequest request)
        {
            var response = service.GetUserById(request);
            if (response.User != null)
            {
                return Request.CreateResponse<GetUserByIdResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " User Not Found");
            }
        }

        [HttpPost]
        [ActionName("createUser")]
        public HttpResponseMessage CreateUser([FromBody]AddNewUserRequest request)
        {
            var response = service.AddNewUser(request);

            if(response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to create new user");
            }
        }

        [HttpPut]
        [ActionName("updateUserData")]
        public HttpResponseMessage UpdateUserData([FromBody]UpdateUserDataRequest request)
        {
            var response = service.UpdateUserData(request);

            if(response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to update user data");
            }
        }

        [HttpDelete]
        [ActionName("deleteUserAccount")]
        public HttpResponseMessage DeleteUserAccount([FromBody]DeleteUserAccountRequest request)
        {
            var response = service.DeleteUserAccount(request);

            if (response)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to delete user account");
            }
        }
    }
}
