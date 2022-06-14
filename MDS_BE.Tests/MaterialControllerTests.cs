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
    public class MaterialControllerTests
    {
        private IMaterialManager mockManager;
        private MaterialController mockController;
        public MaterialControllerTests()
        {
            // Arrange
            this.mockManager = A.Fake<IMaterialManager>();
            this.mockController = new MaterialController(mockManager);
        }
        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            // Arrange
            A.CallTo(() => mockManager.GetMaterials())
                .Returns(new List<Material>());

            //Act
            IActionResult result = mockController.Get().Result;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
