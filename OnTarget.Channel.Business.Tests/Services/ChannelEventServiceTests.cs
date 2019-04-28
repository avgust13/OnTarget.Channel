using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnTarget.Channel.Business.Data;
using OnTarget.Channel.Business.Mapping;
using OnTarget.Channel.Business.Services;
using OnTarget.Channel.DataAccess;
using OnTarget.Channel.DataAccess.Data;
using OnTarget.Channel.DataAccess.Repositories;

namespace OnTarget.Channel.Business.Tests.Services
{
    [TestClass]
    public class ChannelEventServiceTests
    {
        private Mock<IUnitOfWork> _mockUoW;
        private Mock<IChannelEventRepository> _mockRepository;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Mapper.Initialize(x => x.AddProfile<BusinessMappingProfile>());
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IChannelEventRepository>();

            _mockUoW = new Mock<IUnitOfWork>();
            _mockUoW.SetupGet(u => u.ChannelEvent).Returns(_mockRepository.Object);
        }


        [TestMethod]
        public void GetById_OnCall_ShouldReturnCorrectRecord()
        {
            // Arrange
            var ce = new ChannelEvent { ChannelEventId = 1, Title = "test" };

            _mockRepository.Setup(r => r.GetById(1)).Returns(ce);
            var service = new ChannelEventService(_mockUoW.Object);

            // Act
            var result = service.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ChannelEventData));
        }

        [TestMethod]
        public void GetAll_OnCall_ShouldReturnMany()
        {
            // Arrange
            var ces = new List<ChannelEvent>(){
                new ChannelEvent { ChannelEventId = 1, Title = "test1",  },
                new ChannelEvent { ChannelEventId = 2, Title = "test2",  }
            };

            _mockRepository.Setup(r => r.GetAll()).Returns(ces);
            var service = new ChannelEventService(_mockUoW.Object);

            // Act
            var result = service.GetChannelEvents();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue((result as List<ChannelEventData>).Count > 1);
        }
    }
}
