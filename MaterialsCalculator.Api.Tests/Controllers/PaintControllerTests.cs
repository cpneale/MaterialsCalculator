using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaterialsCalculator.Api;
using MaterialsCalculator.Api.Controllers;
using FluentAssertions;
using FluentAssertions.Extensions;
using MaterialsCalculator.Api.Models.Paint;
using MaterialsCalculator.Interfaces.Services;
using Moq;

namespace MaterialsCalculator.Api.Tests.Controllers
{
    [TestClass]
    public class GivenAPaintController
    {
        PaintController _paintController;
        PaintQuantityRequestModel _paintRequestModel;
        IPaintService _mockPaintService;

        [TestInitialize]
        public void Setup()
        {
            _mockPaintService = Mock.Of<IPaintService>();
            _paintController = new PaintController(_mockPaintService);
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
        public void WhenICallCalculateQuantity_ThenItReturnsTheCorrecType()
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
