using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCourses.Implementation;
using System.Linq;
using OnlineCourses.Implementation.DataBaseImplementation;
using OnlineCourses.Types.Requests;

namespace UnitTests
{
    [TestClass]
    public class UnitTestDb
    {
        private OnCoursesImplementation service;

        public UnitTestDb()
        {
            service = new OnCoursesImplementation();
        }

        [TestMethod]
        [TestCategory("User")]
        public void GetUsers()
        {
            var res = service.GetUsers();

            Xunit.Assert.True(res.Users.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("User")]
        public void GetUserById()
        {
            var request = new GetUserByIdRequest()
            {
                UserId = 1
            };
            
            var res = service.GetUserById(request);

            Xunit.Assert.NotNull(res.User);
            Xunit.Assert.True(res.User.Id ==1 && res.User.FullName.Equals("Dimitris Kosmas") && res.User.Email.Equals("dimitkos@yahoo.gr"));
        }

        [TestMethod]
        [TestCategory("User")]
        public void GetUserByIdUnhappy()
        {
            var request = new GetUserByIdRequest()
            {
                UserId = 100
            };
            var res = service.GetUserById(request);

            Xunit.Assert.Null(res.User);
            
        }

        [TestMethod]
        [TestCategory("Instructor")]
        public void GetInstructors()
        {
            var res = service.GetInstructors();

            Xunit.Assert.True(res.Instructors.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("BasicInfo")]
        public void GetFrameworks()
        {
            var res = service.GetFrameworks();

            Xunit.Assert.True(res.Frameworks.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("BasicInfo")]
        public void GetCategories()
        {
            var res = service.GetCategories();

            Xunit.Assert.True(res.Categories.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("Instructor")]
        public void GetInstructorById()
        {
            var request = new GetInstructorByIdRequest()
            {
                InstructorId = 1
            };

            var res = service.GetInstructorById(request);

            Xunit.Assert.NotNull(res.Instructor);
            Xunit.Assert.True(res.Instructor.Id == 1 && res.Instructor.FullName.Equals("Juan Gonzalo") && res.Instructor.Email.Equals("ju.gonzalo@gmail.com"));
        }


        [TestMethod]
        [TestCategory("Instructor")]
        public void GetInstructorByIdUnhappy()
        {
            var request = new GetInstructorByIdRequest()
            {
                InstructorId = 100
            };
            var res = service.GetInstructorById(request);

            Xunit.Assert.Null(res.Instructor);

        }

        [TestMethod]
        [TestCategory("User")]
        public void AddNewUser()
        {
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
        }

        [TestMethod]
        [TestCategory("User")]
        public void AddNewUserUnHappy()
        {
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
        [TestCategory("User")]
        public void UpdateUserData()
        {
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
        [TestCategory("User")]
        public void UpdateUserDataWithoutExistingId()
        {
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
        [TestCategory("User")]
        public void DeleteUser()
        {
            var request = new DeleteUserAccountRequest
            {
                Id = 1000
            };

            var res = service.DeleteUserAccount(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        [TestCategory("Instructor")]
        public void CreateInstructorAccount()
        {
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
        [TestCategory("Instructor")]
        public void CreateInstructorAccountUnHappy()
        {
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
        [TestCategory("Instructor")]
        public void UpdateInstructorData()
        {
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
        [TestCategory("Instructor")]
        public void UpdateInstructorDataUnHappy()
        {
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
        [TestCategory("Courses")]
        public void GetAllCourses()
        {
            var res = service.GetAllCourses();

            Xunit.Assert.NotEmpty(res.Courses);
            Xunit.Assert.True(res.Courses.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void AddNewCourse()
        {
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
        [TestCategory("Courses")]
        public void AddNewCourseWithExistingId()
        {
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

        [TestMethod]
        [TestCategory("Courses")]
        public void UpdateCourse()
        {
            var request = new UpdateCourseRequest
            {
                Id = 444,
                Title = "Python and Machine Learning",
                Description = "A basic course with most famous machine learning libraries in Python",
                Price = 11,
            };

            var res = service.UpdateCourse(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void UpdateCourseWithNoExistingId()
        {
            var request = new UpdateCourseRequest
            {
                Id = 1444,
                Title = "Python and Machine Learning",
                Description = "A basic course with most famous machine learning libraries in Python",
                Price = 11,
            };

            var ex = Xunit.Assert.Throws<Exception>(() => service.UpdateCourse(request));
            Xunit.Assert.Equal("The Course is not updated", ex.Message);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void SearchCoursesByTitle()
        {
            var request = new SearchCoursesRequest
            {
                Title = "ch",
            };

            var res = service.SearchCourses(request);

            Xunit.Assert.True(res.Courses.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void SearchCoursesByFrameworkName()
        {
            var request = new SearchCoursesRequest
            {
                FrameworkName = ".NET",
            };

            var res = service.SearchCourses(request);

            Xunit.Assert.True(res.Courses.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void SearchCoursesByCategoryName()
        {
            var request = new SearchCoursesRequest
            {
                CategoryName = "Software Development",
            };

            var res = service.SearchCourses(request);

            Xunit.Assert.True(res.Courses.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void SearchCoursesByInstructorName()
        {
            var request = new SearchCoursesRequest
            {
                InstructorName = "Marc James",
            };

            var res = service.SearchCourses(request);

            Xunit.Assert.True(res.Courses.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void SearchCoursesByPrice()
        {
            var request = new SearchCoursesRequest
            {
                UpPrice =25.0m ,
                DownPrice=12.0m
            };

            var res = service.SearchCourses(request);

            Xunit.Assert.True(res.Courses.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void SearchCoursesByRating()
        {
            var request = new SearchCoursesRequest
            {
                UpRating = 5.0m,
                DownRating = 4.6m
            };

            var res = service.SearchCourses(request);

            Xunit.Assert.True(res.Courses.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("User")]
        public void EnrollCourse()
        {
            var request = new EnrollCourseRequest
            {
                UserId = 1,
                CourseId =1,
                Comment = null
            };

            var res = service.EnrollCourse(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void GetCoursesByInstructor()
        {
            var request = new GetCoursesByInstructorRequest
            {
                InstructorId = 2,
            };

            var res = service.GetCoursesByInstructor(request);

            Xunit.Assert.NotNull(res.Instructor);
            Xunit.Assert.True(res.Courses.ToList().Count > 0);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void AddComment()
        {
            var request = new AddCommentRequest
            {
                UserId = 1,
                CourseId = 1,
                Comment = "Excellent course!!"
            };

            var res = service.AddComment(request);

            Xunit.Assert.True(res);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void GetAllCommentsByCourse()
        {
            var request = new CourseCommentsRequest
            {
                CourseId = 1,
            };

            var res = service.GetCommentsByCourse(request);

            Xunit.Assert.True(res.CommentDetails.Count > 0);
        }

        [TestMethod]
        [TestCategory("Courses")]
        public void GetCoursesByUser()
        {
            var request = new GetEnrollsByUserRequest
            {
                UserId = 1,
            };

            var res = service.GetEnrollsByStudent(request);

            Xunit.Assert.NotNull(res.User);
            Xunit.Assert.NotNull(res.Courses);
        }
    }
}
