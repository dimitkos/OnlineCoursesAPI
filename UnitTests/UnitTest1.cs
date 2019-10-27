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

            Xunit.Assert.True(res.Users.ToList().Count == 3);//prosthesa enan arra prepei na to allaksw kapws na ginetai aytomata
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

        [TestMethod]
        public void GetCategories()
        {
            var service = new OnCoursesImplementation();

            var res = service.GetCategories();

            Xunit.Assert.True(res.Categories.ToList().Count == 6);
        }

        [TestMethod]
        public void GetInstructorById()
        {
            var service = new OnCoursesImplementation();

            var request = new GetInstructorByIdRequest()
            {
                InstructorId = 1
            };

            var res = service.GetInstructorById(request);

            Xunit.Assert.NotNull(res.Instructor);
            Xunit.Assert.True(res.Instructor.Id == 1 && res.Instructor.FullName.Equals("Juan Gonzalo") && res.Instructor.Email.Equals("ju.gonzalo@gmail.com"));
        }


        [TestMethod]
        public void GetInstructorByIdUnhappy()
        {
            var service = new OnCoursesImplementation();
            var request = new GetInstructorByIdRequest()
            {
                InstructorId = 100
            };
            var res = service.GetInstructorById(request);

            Xunit.Assert.Null(res.Instructor);

        }

        [TestMethod]
        public void AddNewUser()
        {
            var service = new OnCoursesImplementation();
            var request = new AddNewUserRequest()
            {
                Id = 1000,
                FullName="Dimitris Kwstas",
                Email ="asdf@yahoo.gr",
                Gender = true,
                Job = "Devops"
            };

            var res = service.AddNewUser(request);

            Xunit.Assert.True(res);
            //efoson prosthesa enan twra ayton prepei na ton svinw
        }

        [TestMethod]
        public void AddNewUserUnHappy()
        {
            var service = new OnCoursesImplementation();
            var request = new AddNewUserRequest()
            {
                Id = 1,
                FullName = "Dimitris Kwstas",
                Email = "asdf@yahoo.gr",
                Gender = true,
                Job = "Devops"
            };

            //Xunit.Assert.Throws<Exception>(()=> service.AddNewUser(request));
            var ex = Xunit.Assert.Throws<Exception>(() => service.AddNewUser(request));
            Xunit.Assert.Equal("The user id is existing", ex.Message);
        }

        [TestMethod]
        public void UpdateUserData()
        {
            var service = new OnCoursesImplementation();
            var request = new UpdateUserDataRequest()
            {
                Id = 111,
                FullName = "Nikolaos Nikou",
                Email = "testUpdate@yahoo.gr",
                Job = "IT"
            };

            var res = service.UpdateUserData(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        public void UpdateUserDataWithoutExistingId()
        {
            var service = new OnCoursesImplementation();
            var request = new UpdateUserDataRequest()
            {
                Id = 11,
                FullName = "Nikolaos Nikou",
                Email = "testUpdate@yahoo.gr",
                Job = "Devops"
            };

            var ex = Xunit.Assert.Throws<Exception>(() => service.UpdateUserData(request));
            Xunit.Assert.Equal("User does not exist", ex.Message);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var service = new OnCoursesImplementation();
            var request = new DeleteUserAccountRequest
            {
                Id = 1000
            };

            var res = service.DeleteUserAccount(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        public void CreateInstructorAccount()
        {
            var service = new OnCoursesImplementation();
            var request = new CreateInstructorAccountRequest
            {
                Id =12,
                FullName = "Tommy Leins",
                Email = "tommy.Leins@gmail.com",
                Bio = "Senior Andoid Developer",
                Language = "Kotlin"
            };

            var res = service.CreateInstructorAccount(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        public void CreateInstructorAccountUnHappy()
        {
            var service = new OnCoursesImplementation();
            var request = new CreateInstructorAccountRequest
            {
                Id = 12,
                FullName = "Tommy Leins",
                Email = "tommy.Leins@gmail.com",
                Bio = "Senior Andoid Developer",
                Language = "Kotlin"
            };

            var ex = Xunit.Assert.Throws<Exception>(() => service.CreateInstructorAccount(request));
            Xunit.Assert.Equal("The instructor id is existing", ex.Message);
        }

        [TestMethod]
        public void UpdateInstructorData()
        {
            var service = new OnCoursesImplementation();
            var request = new UpdateInstructorDataRequest()
            {
                Id = 12,
                FullName = "Tommy Leins",
                Email = "tommy.Leins@gmail.com",
                Bio = "Senior Andoid Developer/Java Developer",
                Language = "Kotlin"
            };

            var res = service.UpdateInstructorData(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        public void UpdateInstructorDataUnHappy()
        {
            var service = new OnCoursesImplementation();
            var request = new UpdateInstructorDataRequest
            {
                Id = 1112,
                FullName = "Tommy Leins",
                Email = "tommy.Leins@gmail.com",
                Bio = "Senior Andoid Developer",
                Language = "Kotlin"
            };

            var ex = Xunit.Assert.Throws<Exception>(() => service.UpdateInstructorData(request));
            Xunit.Assert.Equal("Instructor does not exist", ex.Message);
        }

        [TestMethod]
        public void GetAllCourses()
        {
            var service = new OnCoursesImplementation();

            var res = service.GetAllCourses();

            Xunit.Assert.NotEmpty(res.Courses);
            Xunit.Assert.True(res.Courses.ToList().Count == 2);
        }

        [TestMethod]
        public void AddNewCourse()
        {
            var service = new OnCoursesImplementation();

            var request = new AddNewCourseRequest
            {
                Id = 444,
                Title ="Python and Machine Learning",
                Description ="A basic course with most famous machine learning libraries in Python",
                Rating =4.1M,
                Price = 10,
                CategoryId = "ML",
                FrameworkId = "DJ",
                InstructorId = 3
            };
            var res = service.AddNewCourse(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        public void AddNewCourseWithExistingId()
        {
            var service = new OnCoursesImplementation();

            var request = new AddNewCourseRequest
            {
                Id = 444,
                Title = "Python and Machine Learning",
                Description = "A basic course with most famous machine learning libraries in Python",
                Rating = 4.1M,
                Price = 10,
                CategoryId = "ML",
                FrameworkId = "DJ",
                InstructorId = 3
            };

            var ex = Xunit.Assert.Throws<Exception>(() => service.AddNewCourse(request));
            Xunit.Assert.Equal("The Course id is existing", ex.Message);
        }
    }
}
