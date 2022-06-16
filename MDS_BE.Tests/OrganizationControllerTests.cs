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
    public class OrganizationControllerTests
    {
        private IOrganizationManager mockManager;
        private OrganizationsController mockController;
        public OrganizationControllerTests()
        {
            // Arrange
            this.mockManager = A.Fake<IOrganizationManager>();
            this.mockController = new OrganizationsController(mockManager);
        }
        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            // Arrange
            A.CallTo(() => mockManager.GetOrganisations())
                .Returns(new List<Organization>());

            //Act
            IActionResult result = mockController.Get().Result;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
