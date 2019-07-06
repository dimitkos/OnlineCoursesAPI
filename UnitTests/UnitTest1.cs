using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCourses.Implementation;
using System.Linq;
using OnlineCourses.Implementation.DataBaseImplementation;

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

            int request = 1;
            var res = service.GetUserById(request);

            Xunit.Assert.NotNull(res.User);
            Xunit.Assert.True(res.User.Id ==1 && res.User.FullName.Equals("Dimitris Kosmas") && res.User.Email.Equals("dimitkos@yahoo.gr"));
        }

        [TestMethod]
        public void GetUserByIdUnhappy()
        {
            var service = new OnCoursesImplementation();

            int request = 1000;
            var res = service.GetUserById(request);

            Xunit.Assert.Null(res);
            
        }

        [TestMethod]
        public void GetInstructors()
        {
            var service = new OnCoursesImplementation();

            var res = service.GetInstructors();

            Xunit.Assert.True(res.Instructors.ToList().Count == 4);
        }
    }
}
