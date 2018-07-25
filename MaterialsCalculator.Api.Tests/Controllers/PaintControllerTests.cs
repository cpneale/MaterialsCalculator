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

namespace MaterialsCalculator.Api.Tests.Controllers
{
    [TestClass]
    public class GivenAPaintController
    {
        PaintController _paintController;
        PaintQuantityRequestModel _paintRequestModel;
        Mock<IPaintService> _mockPaintService;
        private IEnumerable<IPaintInfo> _paintInfo;
        private IPaintCoverageInfo _coverageInfo;

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
            _mockPaintService.Setup(m => m.CalculateCoverage(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>()))
                .Returns(_coverageInfo);

            _paintController = new PaintController(_mockPaintService.Object);
            _paintRequestModel = new PaintQuantityRequestModel();
        }

        [TestMethod]
        public void WhenICallGet_ThenItReturnsTheCorrectType()
        {
            var rslt = _paintController.Get();
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<OkNegotiatedContentResult<List<PaintQuantityRequestModel>>>();
        }

        [TestMethod]
        public void WhenICallGetAndAnErrorOccurs_ThenItReturnsBadRequest()
        {
            //some set up required here
            var rslt = _paintController.Get();
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void WhenICallCalculateQuantity_ThenItReturnsTheCorrectType()
        {
            var rslt = _paintController.CalculateQuantity(_paintRequestModel);
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<OkNegotiatedContentResult<PaintQuantityResponseModel>>();       
        }

        [TestMethod]
        public void WhenICallCalculateQuantityAndAnErrorOccurs_ThenItReturnsBadRequest()
        {
            //some set up required here
            var rslt = _paintController.CalculateQuantity(_paintRequestModel);
            rslt.Should().NotBeNull();
            rslt.Should().BeOfType<BadRequestResult>();
        }
    }
}
