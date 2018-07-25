using System;
using System.Collections.Generic;
using System.Linq;
using MaterialsCalculator.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MaterialsCalculator.Interfaces.MaterialModels;

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
            _paintService.Invoking(x => x.CalculateCoverage(1,2,3,4))
                .Should().NotThrow();
        }

        [TestMethod]
        public void WhenICallCalculateCoverage_ThenItReturnsTheCorrectType()
        {
            var rslt = _paintService.CalculateCoverage(1,2,3,4);

            rslt.Should().NotBeNull();
            rslt.Should().BeAssignableTo<IPaintCoverageInfo>();
        }
    }
}
