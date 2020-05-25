using System;
using System.Security.Claims;

namespace OnlineCourses.Interfaces
{
    public interface ITokenProvider
    {
        string CreateToken(Claim[] claims, DateTime expires, string tokenSecret);
    }
}
