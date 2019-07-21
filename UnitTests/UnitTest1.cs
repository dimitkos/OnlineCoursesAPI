using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCourses.Implementation;
using System.Linq;
using OnlineCourses.Implementation.DataBaseImplementation;
using OnlineCourses.Types.Requests;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetUsers()
        {
            var service = new OnCoursesImplementation();

            var res = service.GetUsers();

            Xunit.Assert.True(res.Users.ToList().Count == 3);
        }

        [TestMethod]
        public void GetUserById()
        {
            var service = new OnCoursesImplementation();

            var request = new GetUserByIdRequest()
            {
                UserId = 1
            };
            
            var res = service.GetUserById(request);

            Xunit.Assert.NotNull(res.User);
            Xunit.Assert.True(res.User.Id ==1 && res.User.FullName.Equals("Dimitris Kosmas") && res.User.Email.Equals("dimitkos@yahoo.gr"));
        }

        [TestMethod]
        public void GetUserByIdUnhappy()
        {
            var service = new OnCoursesImplementation();
            var request = new GetUserByIdRequest()
            {
                UserId = 100
            };
            var res = service.GetUserById(request);

            Xunit.Assert.Null(res.User);
            
        }

        [TestMethod]
        public void GetInstructors()
        {
            var service = new OnCoursesImplementation();

            var res = service.GetInstructors();

            Xunit.Assert.True(res.Instructors.ToList().Count == 4);
        }

        [TestMethod]
        public void GetFrameworks()
        {
            var service = new OnCoursesImplementation();

            var res = service.GetFrameworks();

            Xunit.Assert.True(res.Frameworks.ToList().Count == 8);
        }
    }
}
