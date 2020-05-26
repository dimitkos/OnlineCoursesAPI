using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineCourses.Controllers
{
    public class UserController :ApiController
    {
        private readonly IUser service;

        public UserController(IUser service)
        {
            this.service = service;
        }

        [HttpGet]
        [ActionName("getAllUsers")]
        [ResponseType(typeof(GetUsersResponse))]
        public HttpResponseMessage GetAllUsers()
        {
            var response = service.FetchUsers();
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
        [ResponseType(typeof(GetUserByIdResponse))]
        public HttpResponseMessage GetUserById([FromUri]GetUserByIdRequest request)
        {
            var response = service.FetchUserById(request);
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
        [AllowAnonymous]
        [ActionName("createUser")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage CreateUser([FromBody]AddNewUserRequest request)
        {
            var response = service.CreateNewUser(request);

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
        [ResponseType(typeof(bool))]
        public HttpResponseMessage UpdateUserData([FromBody]UpdateUserDataRequest request)
        {
            var response = service.UpdateUser(request);

            if (response)
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
        [ResponseType(typeof(bool))]
        public HttpResponseMessage DeleteUserAccount([FromBody]DeleteUserAccountRequest request)
        {
            var response = service.DeleteUser(request);

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
