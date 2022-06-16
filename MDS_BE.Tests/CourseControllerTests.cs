using FakeItEasy;
using MDS_BE.Controllers;
using MDS_BE.Entities;
using MDS_BE.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace MDS_BE.Tests
{
    public class CourseControllerTests
    {
        private ICourseManager mockManager;
        private CourseController mockController;
        private List<Course> CreateMockCourseList()
        {
            List<Course> aux = new List<Course>();
            aux.Add(
                new Course
            {
                CourseId = 100,
                Name = "Statistics",
                Duration = 180,
                Description = "A course for begginers in the field of statistics!"
            });
            aux.Add(
                new Course
            {
                CourseId = 101,
                Name = "Mathematics",
                Duration = 120,
                Description = "A course for begginers in the field of mathematics!"
            });
            
            return aux;
        }
        public CourseControllerTests()
        {
            this.mockManager = A.Fake<ICourseManager>();
            this.mockController = new CourseController(mockManager);
        }

        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            // Arrange
            A.CallTo(() => mockManager.GetCourses())
                .Returns(new List<Course>());

            //Act
            IActionResult result = mockController.Get().Result;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async Task Get_OkObjectReturnsCourses()
        {
            //Arrange
            List<Course> mockCourses1 = CreateMockCourseList();
            List<Course> mockCourses2 = CreateMockCourseList();
            A.CallTo(() => mockManager.GetCourses())
                .Returns(mockCourses1);

            //Act
            var result = await mockController.Get();
            var okResult = result as ObjectResult;
            var actualResult = okResult.Value;

            //Assert
            // ensure the HTTP response
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            // assert respons object 
            var actualResultList = (List<Course>)actualResult;
            Assert.Equal(mockCourses2.Count, actualResultList.Count);
            for (int i = 0; i < mockCourses2.Count; i++)
            {
                Assert.Equal(mockCourses2[i].CourseId, actualResultList[i].CourseId);
                Assert.Equal(mockCourses2[i].Description, actualResultList[i].Description);
                Assert.Equal(mockCourses2[i].Duration, actualResultList[i].Duration);
                Assert.Equal(mockCourses2[i].Name, actualResultList[i].Name);
            }
        }
        [Fact]
        public async Task GetCourseByName_OkObjectReturnsCourse()
        {
            //Arrange
            Course course = new Course()
            {
                CourseId = 100,
                Name = "Statistics",
                Duration = 180,
                Description = "A course for begginers in the field of statistics!"
            };

            A.CallTo(() => mockManager.GetCourseByName(course.Name))
                .Returns(course);

            //Act
            var result = await mockController.GetCourseByName(course.Name);
            var okResult = result as ObjectResult;
            var actualResult = okResult.Value;

            //Assert
            // ensure the HTTP response
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            // assert respons object 
            var actualResultCourse = (Course)actualResult;
            Assert.Equal(course.CourseId, actualResultCourse.CourseId);
            Assert.Equal(course.Description, actualResultCourse.Description);
            Assert.Equal(course.Duration, actualResultCourse.Duration);
            Assert.Equal(course.Name, actualResultCourse.Name);
        }

    }
}
