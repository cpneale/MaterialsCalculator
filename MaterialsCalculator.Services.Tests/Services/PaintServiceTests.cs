using System.Collections.Generic;
using System.Linq;
using MaterialsCalculator.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MaterialsCalculator.Core.Dimensions;
using MaterialsCalculator.Interfaces.Dimensions;
using MaterialsCalculator.Interfaces.MaterialModels;
using Moq;

namespace MaterialsCalculator.Services.Tests.Services
{
    [TestClass]
    public class GivenAPaintService
    {
        private PaintService _paintService;

        [TestInitialize]
        public void Setup()
        {
            _paintService = new PaintService();
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
            _paintService.Invoking(x => x.CalculateCoverage(Mock.Of<IRoom>(),1))
                .Should().NotThrow();
        }

        [TestMethod]
        public void WhenICallCalculateCoverage_ThenItReturnsTheCorrectType()
        {
            var rslt = _paintService.CalculateCoverage(Mock.Of<IRoom>(), 1);

            rslt.Should().NotBeNull();
            rslt.Should().BeAssignableTo<IPaintCoverageInfo>();
        }

        [TestMethod]
        public void WhenICallCalculateCoverage_ThenTinsRequiredIsCalculatedCorrectly()
        {
            double H = 1, W = 2, L = 3, coverage = 10.0;
            var room = new SquareRoom() { Height = H, Width = W, Length = L };
            double expectedTinsRequired = room.CalculateArea() / coverage;

            var rslt = _paintService.CalculateTinsRequired(room, coverage);

            rslt.Should().Be(expectedTinsRequired);
        }
    }
}
