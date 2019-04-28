using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnTarget.Channel.DataAccess.Data;
using OnTarget.Channel.DataAccess.Repositories;
using OnTarget.Channel.DataAccess.Tests.Extensions;

namespace OnTarget.Channel.DataAccess.Tests.Repositories
{
    [TestClass]
    public class ChannelEventRepositoryTests
    {
        private Mock<IDatabaseContext> _mockDb;
        private ChannelEventRepository _repository;
        private Mock<DbSet<ChannelEvent>> _mockDbSet;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDb = new Mock<IDatabaseContext>();
            _mockDbSet = new Mock<DbSet<ChannelEvent>>();
        }

        [TestMethod]
        public void GetById_OnCall_ShouldReturnObjectWithCorrectType()
        {
            // Arrange
            var ces = new List<ChannelEvent>(){
                new ChannelEvent { ChannelEventId = 1, Title = "test1",  },
                new ChannelEvent { ChannelEventId = 2, Title = "test2",  }
            };
            _mockDbSet.SetSource(ces);
            _mockDb.SetupGet(c => c.ChannelEvents).Returns(_mockDbSet.Object);

            _repository = new ChannelEventRepository(_mockDb.Object);

            // Act
            var result = _repository.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ChannelEvent));
        }
    }
}
