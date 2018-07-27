using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaterialsCalculator.Api.Controllers;
using FluentAssertions;
using MaterialsCalculator.Api.Models.Paint;
using MaterialsCalculator.Interfaces.MaterialModels;
using MaterialsCalculator.Interfaces.Services;
using Moq;
using MaterialsCalculator.Core.MaterialModels;
using MaterialsCalculator.Interfaces.Dimensions;
using MaterialsCalculator.Providers.Entities;

namespace MaterialsCalculator.Api.Tests.Controllers
{
    [TestClass]
    public class GivenAPaintController
    {
        PaintController _paintController;
        PaintRequestModelSquareRoom _paintRequestModel;
        Mock<IPaintService> _mockPaintService;
        private IEnumerable<IPaintInfo> _paintInfo;
        private IPaintCoverageInfo _coverageInfo;
        private Mock<IPaintService> _mockFaultyPaintService;
        private PaintController _faultyPaintController;
        private int _missingPaintId = 999;
        private int _paintId = 1;
        private PaintRequestModelSquareRoom _missingPaintRequestModel;

        [TestInitialize]
        public void Setup()
        {
            _paintInfo = new List<IPaintInfo>
            {
                new PaintInfo {PaintId = 1, PaintName = "Magnolia", CoverageM2PerTin = 10.00},
                new PaintInfo {PaintId = 2, PaintName = "White", CoverageM2PerTin = 12.00}
            };

            _coverageInfo = new PaintCoverageInfo
            {
                Area = 10,
                CoverageM2PerTin = 1,
                Volume = 9,
                TinsRequired = 2
            };

            _mockPaintService = new Mock<IPaintService>();
            _mockPaintService.Setup(m => m.GetPaints()).Returns(_paintInfo);
            _mockPaintService.Setup(m => m.CalculateCoverage(It.IsAny<IRoom>(), It.IsAny<int>()))
                .Returns(_coverageInfo);
            _paintController = new PaintController(_mockPaintService.Object);

            _mockFaultyPaintService = new Mock<IPaintService>();
            _mockFaultyPaintService.Setup(m => m.GetPaints()).Throws<Exception>();
            _mockFaultyPaintService.Setup(m => m.CalculateCoverage(It.IsAny<IRoom>(), _paintId)).Throws<Exception>();
            _mockFaultyPaintService.Setup(m => m.CalculateCoverage(It.IsAny<IRoom>(), _missingPaintId)).Throws<ArgumentException>();
            _faultyPaintController = new PaintController(_mockFaultyPaintService.Object);

            _paintRequestModel = new PaintRequestModelSquareRoom()
            {
                Height = 0, Length = 0, Width = 0, PaintId = _paintId
            };

            _missingPaintRequestModel = new PaintRequestModelSquareRoom()
            {
                Height = 0, Length = 0, Width = 0, PaintId = _missingPaintId
            };

        }

        [TestMethod]
        public void WhenICallGet_ThenItReturnsTheCorrectType()
        {
            var rslt = _paintController.Get();
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<OkNegotiatedContentResult<List<PaintModel>>>();
        }

        [TestMethod]
        public void WhenICallGetAndAnErrorOccurs_ThenItReturnsBadRequest()
        {
            var rslt = _faultyPaintController.Get();
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void WhenICallGet_ThenGetPaintsIsCalledOnTheService()
        {
            var rslt = _paintController.Get();

            _mockPaintService.Verify(x => x.GetPaints());
        }

        [TestMethod]
        public void WhenICallCalculateQuantity_ThenItReturnsTheCorrectType()
        {
            var rslt = _paintController.CalculateQuantitySquareRoom(_paintRequestModel);
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<OkNegotiatedContentResult<PaintQuantityResponseModel>>();       
        }

        [TestMethod]
        public void WhenICallCalculateQuantityAndAnErrorOccurs_ThenItReturnsBadRequest()
        {
            var rslt = _faultyPaintController.CalculateQuantitySquareRoom(_paintRequestModel);
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void WhenICallCalculateQuantityAndAnArgumentExceptionIsHandled_ThenItReturnsNotFound()
        {
            var rslt = _faultyPaintController.CalculateQuantitySquareRoom(_missingPaintRequestModel);
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void WhenICallCalculateQuantitySquareRoom_ThenCalculateCoverageIsCalledOnTheService()
        {
            var rslt = _paintController.CalculateQuantitySquareRoom(_paintRequestModel);

            _mockPaintService.Verify(x => x.CalculateCoverage(It.IsAny<IRoom>(), It.IsAny<int>()));
        }
    }
}
