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
    public class RegisterControllerTests
    {
        private IRegisterManager mockManager;
        private RegisterController mockController;
        public RegisterControllerTests()
        {
            // Arrange
            this.mockManager = A.Fake<IRegisterManager>();
            this.mockController = new RegisterController(mockManager);
        }
        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            // Arrange
            A.CallTo(() => mockManager.GetRegisters())
                .Returns(new List<Register>());

            //Act
            IActionResult result = mockController.Get().Result;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
