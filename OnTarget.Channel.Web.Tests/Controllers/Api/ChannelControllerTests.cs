using System;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnTarget.Channel.Business.Services;
using OnTarget.Channel.Web.Controllers.Api;

namespace OnTarget.Channel.Web.Tests.Controllers.Api
{
    [TestClass]
    public class ChannelControllerTests
    {
        private ChannelController _controller;
        private Mock<IChannelEventService> _mockService;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockService = new Mock<IChannelEventService>();

            _controller = new ChannelController(_mockService.Object);
        }

        [TestMethod]
        public void Delete_NoEventWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
