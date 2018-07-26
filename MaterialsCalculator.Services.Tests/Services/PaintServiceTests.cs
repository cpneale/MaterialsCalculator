using System.Collections.Generic;
using System.Linq;
using MaterialsCalculator.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MaterialsCalculator.Interfaces.Dimensions;
using MaterialsCalculator.Interfaces.MaterialModels;
using Moq;

namespace MaterialsCalculator.Services.Tests.Services
{
    [TestClass]
    public class GivenAPaintService
    {
        private PaintService _paintService;
        private Mock<IRoom> _mockRoom;

        [TestInitialize]
        public void Setup()
        {
            _paintService = new PaintService();
            _mockRoom = new Mock<IRoom>();
        }

        [TestMethod]
        public void WhenICallGetPaints_ThenItDoesNotThrow()
        {
            _paintService.Invoking(x => x.GetPaints())
                .Should().NotThrow();
        }

        [TestMethod]
        public void WhenICallGetPaints_ThenItReturnsTheCorrectType()
        {
            var rslt = _paintService.GetPaints().ToList();

            rslt.Should().NotBeNull();
            rslt.Should().BeAssignableTo<IList<IPaintInfo>>();
        }

        [TestMethod]
        public void WhenICallCalculateCoverage_ThenItDoesNotThrow()
        {
            _paintService.Invoking(x => x.CalculateCoverage(_mockRoom.Object,1))
                .Should().NotThrow();
        }

        [TestMethod]
        public void WhenICallCalculateCoverage_ThenItReturnsTheCorrectType()
        {
            var rslt = _paintService.CalculateCoverage(_mockRoom.Object,1);

            rslt.Should().NotBeNull();
            rslt.Should().BeAssignableTo<IPaintCoverageInfo>();
        }
    }
}
