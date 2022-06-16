using FakeItEasy;
using MDS_BE.Controllers;
using MDS_BE.Entities;
using MDS_BE.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Xunit;

namespace MDS_BE.Tests
{
    public class UserControllerTests
    {
        private IUserManager mockManager;
        private UserController mockController;
        public UserControllerTests()
        {
            // Arrange
            this.mockManager = A.Fake<IUserManager>();
            this.mockController = new UserController(mockManager);
        }
        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            // Arrange
            A.CallTo(() => mockManager.GetUsers())
                .Returns(new List<User>());

            //Act
            IActionResult result = mockController.Get().Result;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
