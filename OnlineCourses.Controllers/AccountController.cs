using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineCourses.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AccountController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Login(LoginRequest login)
        {
            var response = _authenticationManager.Authenticate(login);

            if (response != null)
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid credentials, please try again...");
            }
        }
    }
}
