using OnlineCourses.Types.Requests;

namespace OnlineCourses.Interfaces
{
    public interface IAuthenticationManager
    {
        string Authenticate(LoginRequest request);
    }
}
