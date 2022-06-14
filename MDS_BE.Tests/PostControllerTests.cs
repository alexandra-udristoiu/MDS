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
    public class PostControllerTests
    {
        private IPostManager mockPostManager;
        private ICommentManager mockCommentManager;
        private PostsController mockController;
        public PostControllerTests()
        {
            // Arrange
            this.mockPostManager = A.Fake<IPostManager>();
            this.mockCommentManager = A.Fake<ICommentManager>();
            this.mockController = new PostsController(mockPostManager, mockCommentManager);
        }
        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            // Arrange
            A.CallTo(() => mockPostManager.GetPosts())
                .Returns(new List<Post>());

            //Act
            IActionResult result = mockController.Get().Result;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
