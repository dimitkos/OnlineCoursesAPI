using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCourses.Implementation;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new DbImplementation();

            var res = service.GetUsers();

            Xunit.Assert.True(res.Users.ToList().Count == 3);
        }
    }
}
