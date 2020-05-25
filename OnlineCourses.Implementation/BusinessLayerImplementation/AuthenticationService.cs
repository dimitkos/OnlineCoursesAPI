using OnlineCourses.Interfaces;
using OnlineCourses.Types.DbTypes;
using OnlineCourses.Types.Requests;
using System;
using System.Security.Claims;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class AuthenticationService : IAuthenticationManager
    {
        private readonly IService _dbService;
        private readonly IPasswordProvider _passwordProvider;
        private readonly ITokenProvider _tokenProvider;

        public AuthenticationService(IService dbService, IPasswordProvider passwordProvider, ITokenProvider tokenProvider)
        {
            _dbService = dbService;
            _passwordProvider = passwordProvider;
            _tokenProvider = tokenProvider;
        }

        public string Authenticate(LoginRequest request)
        {
            var account = _dbService.GetUserByIdAndEmail(request);

            if (account.HashedPassword == null)
                throw new Exception("Not existing user");

            var verifyPassword = _passwordProvider.VerifyHashedPassword(request.Password , account.HashedPassword);

            if (!verifyPassword)
                throw new Exception("Invalid credentials");

            var token = GenerateToken(account);

            return token;
        }

        private string GenerateToken(Account account)
        {
            var accessTokenClaims = new[]
            {
                new Claim(ClaimTypes.Email, account.Email)
            };
#warning add secret
            var token = _tokenProvider.CreateToken(accessTokenClaims,DateTime.UtcNow.AddMinutes(10) , "my secret");

            return token;
        }
    }
}
