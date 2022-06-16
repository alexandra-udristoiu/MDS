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
    public class CommentControllerTests
    {
        private ICommentManager mockManager;
        private CommentsController mockController;
        public CommentControllerTests()
        {
            // Arrange
            this.mockManager = A.Fake<ICommentManager>();
            this.mockController = new CommentsController(mockManager);
        }
        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            // Arrange
            A.CallTo(() => mockManager.GetComments())
                .Returns(new List<Comment>());

            //Act
            IActionResult result = mockController.Get().Result;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
