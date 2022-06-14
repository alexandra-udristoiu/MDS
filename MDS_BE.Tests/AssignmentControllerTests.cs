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
    public class AssignmentControllerTests
    {
        private IAssignmentManager mockManager;
        private AssignmentController mockController;
        private List<Assignment> CreateMockAssignmentList()
        {
            List<Assignment> aux = new List<Assignment>();
            aux.Add(
                new Assignment
                {
                    AssignmentId = 111,
                    CourseId = 100,
                    CourseName = "Statistics",
                    Text = "This is an example of assignment",
                    Grade = 10
                });
            aux.Add(
                new Assignment
                {
                    AssignmentId = 112,
                    CourseId = 100,
                    CourseName = "Statistics",
                    Text = "This is an example of assignment",
                    Grade = 8
                });

            return aux;
        }
        public AssignmentControllerTests()
        {
            // Arrange
            this.mockManager = A.Fake<IAssignmentManager>();
            this.mockController = new AssignmentController(mockManager);
        }
        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            // Arrange
            A.CallTo(() => mockManager.GetAssignments())
                .Returns(new List<Assignment>());

            //Act
            IActionResult result = mockController.Get().Result;
            
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Get_OkObjectReturnsAssignments()
        {
            //Arrange
            List<Assignment> mockAssignments1 = CreateMockAssignmentList();
            List<Assignment> mockAssignments2 = CreateMockAssignmentList();
            A.CallTo(() => mockManager.GetAssignments())
                .Returns(mockAssignments1);

            //Act
            var result = await mockController.Get();
            var okResult = result as ObjectResult;
            var actualResult = okResult.Value;

            //Assert
            // ensure the HTTP response
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            var actualResultList = (List<Assignment>)actualResult;
            // assert respons object 
            Assert.Equal(mockAssignments2.Count, actualResultList.Count);
            for (int i = 0; i < mockAssignments2.Count; i++)
            {
                Assert.Equal(mockAssignments2[i].AssignmentId, actualResultList[i].AssignmentId);
                Assert.Equal(mockAssignments2[i].CourseId, actualResultList[i].CourseId);
                Assert.Equal(mockAssignments2[i].CourseName, actualResultList[i].CourseName);
                Assert.Equal(mockAssignments2[i].Text, actualResultList[i].Text);
                Assert.Equal(mockAssignments2[i].Grade, actualResultList[i].Grade);
            }
        }
        [Fact]
        public async Task GetCourseAssignments_OkObjectReturnsAssignments()
        {
            //Arrange
            List<Assignment> mockAssignments1 = CreateMockAssignmentList();
            List<Assignment> mockAssignments2 = CreateMockAssignmentList();
            int courseId = 100;
            A.CallTo(() => mockManager.GetCourseAssignments(courseId))
                .Returns(mockAssignments1);

            //Act
            var result = await mockController.GetCourseAssignments(courseId);
            var okResult = result as ObjectResult;
            var actualResult = okResult.Value;

            //Assert
            // ensure the HTTP response
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            // assert respons object
            var actualResultList = (List<Assignment>)actualResult;
            Assert.Equal(mockAssignments2.Count, actualResultList.Count);
            for (int i = 0; i < mockAssignments2.Count; i++)
            {
                Assert.Equal(mockAssignments2[i].AssignmentId, actualResultList[i].AssignmentId);
                Assert.Equal(mockAssignments2[i].CourseId, actualResultList[i].CourseId);
                Assert.Equal(mockAssignments2[i].CourseName, actualResultList[i].CourseName);
                Assert.Equal(mockAssignments2[i].Text, actualResultList[i].Text);
                Assert.Equal(mockAssignments2[i].Grade, actualResultList[i].Grade);
            }
        }
    }
}
