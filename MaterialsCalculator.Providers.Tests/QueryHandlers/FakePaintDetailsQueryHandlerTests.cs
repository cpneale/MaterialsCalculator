using System.Collections.Generic;
using MaterialsCalculator.Providers.QueryHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using MaterialsCalculator.Interfaces.MaterialModels;
using MaterialsCalculator.Interfaces.Providers;

namespace MaterialsCalculator.Providers.Tests.QueryHandlers
{
    [TestClass]
    public class GivenAFakePaintDetailsQueryHandler
    {
        private FakePaintDetailsQueryHandler _paintDetailsQueryHandler;

        [TestInitialize]
        public void Setup()
        {
            _paintDetailsQueryHandler = new FakePaintDetailsQueryHandler();
        }
        [TestMethod]
        public void WhenICallHandle_ThenItDoesNotThrow()
        {
            Mock<IPaintDetailsQuery> mockPaintDetailsQuery = new Mock<IPaintDetailsQuery>();
            mockPaintDetailsQuery.Setup(x => x.PaintId).Returns(1);

            _paintDetailsQueryHandler.Invoking(x => x.Handle(mockPaintDetailsQuery.Object))
                .Should().NotThrow();
        }

        [TestMethod]
        public void WhenICallHandle_ThenItReturnsTheCorrectType()
        {
            Mock<IPaintDetailsQuery> mockPaintDetailsQuery = new Mock<IPaintDetailsQuery>();
            mockPaintDetailsQuery.Setup(x => x.PaintId).Returns(1);

            var rslt = _paintDetailsQueryHandler.Handle(mockPaintDetailsQuery.Object);

            rslt.Should().BeAssignableTo<IEnumerable<IPaintInfo>>();
        }

        [TestMethod]
        public void WhenICallHandleWithAPaintId_ThenItReturnsOnlyOneElement()
        {
            Mock<IPaintDetailsQuery> mockPaintDetailsQuery = new Mock<IPaintDetailsQuery>();
            mockPaintDetailsQuery.Setup(x => x.PaintId).Returns(1);

            var rslt = _paintDetailsQueryHandler.Handle(mockPaintDetailsQuery.Object);

            rslt.Should().HaveCount(1);
        }

        [TestMethod]
        public void WhenICallHandleWithAZeroPaintId_ThenItReturnsMoreThanOneElement()
        {
            Mock<IPaintDetailsQuery> mockPaintDetailsQuery = new Mock<IPaintDetailsQuery>();
            mockPaintDetailsQuery.Setup(x => x.PaintId).Returns(0);

            var rslt = _paintDetailsQueryHandler.Handle(mockPaintDetailsQuery.Object);

            rslt.Should().HaveCountGreaterThan(1);
        }
    }
}
