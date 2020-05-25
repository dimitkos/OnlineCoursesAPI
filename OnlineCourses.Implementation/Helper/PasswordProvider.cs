using OnlineCourses.Interfaces;
using System;

namespace OnlineCourses.Implementation.Helper
{
    public class PasswordProvider : IPasswordProvider
    {
#warning must implement the  method
        public string Hash(string password)
        {
            throw new NotImplementedException();
        }
#warning must implement the  method
        public bool VerifyHashedPassword(string password, string hashedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
