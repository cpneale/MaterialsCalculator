﻿using System;
using System.Collections.Generic;
using System.Linq;
using MaterialsCalculator.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MaterialsCalculator.Core.Dimensions;
using MaterialsCalculator.Core.MaterialModels;
using MaterialsCalculator.Interfaces.Dimensions;
using MaterialsCalculator.Interfaces.MaterialModels;
using MaterialsCalculator.Interfaces.Providers;
using MaterialsCalculator.Providers.Entities;
using Moq;

namespace MaterialsCalculator.Services.Tests.Services
{
    [TestClass]
    public class GivenAPaintService
    {
        private PaintService _paintService;
        private Mock<IPaintDetailsQueryHandler<IPaintDetailsQuery>> _mockQueryHandler;
        private List<IPaintInfo> _paints;
        private List<IPaintInfo> _emptyPaints
            ;

        [TestInitialize]
        public void Setup()
        {
            _mockQueryHandler = new Mock<IPaintDetailsQueryHandler<IPaintDetailsQuery>>();

            _paints = new List<IPaintInfo>
            {
                new PaintInfo {PaintId = 1, PaintName = "Magnolia", CoverageM2PerTin = 10.00},
                new PaintInfo {PaintId = 2, PaintName = "White", CoverageM2PerTin = 12.00}
            };

            _emptyPaints = Enumerable.Empty<IPaintInfo>().ToList();

            _paintService = new PaintService(_mockQueryHandler.Object);
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
            _mockQueryHandler.Setup(x => x.Handle(It.IsAny<IPaintDetailsQuery>()))
                .Returns(_paints);
            
            var rslt = _paintService.GetPaints().ToList();

            rslt.Should().NotBeNull();
            rslt.Should().BeAssignableTo<IList<IPaintInfo>>();
        }

        [TestMethod]
        public void WhenICallCalculateCoverage_ThenItDoesNotThrow()
        {
            _mockQueryHandler.Setup(x => x.Handle(It.IsAny<IPaintDetailsQuery>()))
                .Returns(_paints);

            _paintService.Invoking(x => x.CalculateCoverage(Mock.Of<IRoom>(),1))
                .Should().NotThrow();
        }

        [TestMethod]
        public void WhenICallCalculateCoverage_ThenItReturnsTheCorrectType()
        {
            _mockQueryHandler.Setup(x => x.Handle(It.IsAny<IPaintDetailsQuery>()))
                .Returns(_paints);

            var rslt = _paintService.CalculateCoverage(Mock.Of<IRoom>(), 1);

            rslt.Should().NotBeNull();
            rslt.Should().BeAssignableTo<IPaintCoverageInfo>();
        }

        [TestMethod]
        public void WhenICallCalculateCoverage_ThenTinsRequiredIsCalculatedCorrectly()
        {
            _mockQueryHandler.Setup(x => x.Handle(It.IsAny<IPaintDetailsQuery>()))
                .Returns(_paints);

            double H = 1, W = 2, L = 3, coverage = 10.0;
            var room = new SquareRoom() { Height = H, Width = W, Length = L };
            double expectedTinsRequired = room.CalculateArea() / coverage;

            var rslt = _paintService.CalculateCoverage(room, 1);

            rslt.TinsRequired.Should().Be(expectedTinsRequired);
        }


        [TestMethod]
        public void WhenICallCalculateCoverageWithInvalidPaintId_ThenItThrowsArgumentException()
        {
            _mockQueryHandler.Setup(x => x.Handle(It.IsAny<IPaintDetailsQuery>()))
                .Returns(_emptyPaints);

            double H = 1, W = 2, L = 3, coverage = 10.0;
            int paintId = 1;
            var room = new SquareRoom() { Height = H, Width = W, Length = L };
            double expectedTinsRequired = room.CalculateArea() / coverage;

            _paintService.Invoking(p => p.CalculateCoverage(room, paintId))
                .Should().Throw<ArgumentException>();
        }
    }
}
