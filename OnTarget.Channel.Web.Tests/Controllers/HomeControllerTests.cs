using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnTarget.Channel.Business.Services;
using OnTarget.Channel.Web;
using OnTarget.Channel.Web.Controllers;

namespace OnTarget.Channel.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private Mock<IChannelEventService> _mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IChannelEventService>();
        }

        [TestMethod]
        public void Index_UserOpensIndexPage_ShouldNotBeNull()
        {
            // Arrange
            HomeController controller = new HomeController(_mockRepository.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
