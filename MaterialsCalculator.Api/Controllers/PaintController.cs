using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MaterialsCalculator.Api.Models.Paint;
using MaterialsCalculator.Core.Dimensions;
using MaterialsCalculator.Interfaces.MaterialModels;
using MaterialsCalculator.Interfaces.Services;

namespace MaterialsCalculator.Api.Controllers
{
    [RoutePrefix("api/Materials")]
    public class PaintController : ApiController
    {
        private IPaintService _paintService;

        public PaintController(IPaintService paintService)
        {
            if (paintService == null)
                throw new ArgumentNullException(nameof(paintService));
            _paintService = paintService;
        }

        [HttpGet]
        [Route("Paint")]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<IPaintInfo> paints = _paintService.GetPaints().ToList();

                var materials =
                    paints.Select(p => new PaintModel
                    {
                        PaintId = p.PaintId,
                        PaintName = p.PaintName,
                        CoverageM2PerTin = p.CoverageM2PerTin
                    }).ToList();

                return Ok(materials);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route(@"Paint/CalculateQuantity/SquareRoom")]
        public IHttpActionResult CalculateQuantitySquareRoom(PaintRequestModelSquareRoom paintInfo)
        {
            try
            {
                var squareRoom = new SquareRoom
                {
                    Height = paintInfo.Height,
                    Width = paintInfo.Width,
                    Length = paintInfo.Length
                };

                var coverageInfo = _paintService.CalculateCoverage(squareRoom, paintInfo.PaintId);

                var quantityInfo = new PaintQuantityResponseModel
                {
                    PaintInfo = paintInfo,
                    Area = coverageInfo.Area,
                    Volume = coverageInfo.Volume,
                    TinsRequired = coverageInfo.TinsRequired,
                    CoverageM2PerTin = coverageInfo.CoverageM2PerTin
                };

                return Ok(quantityInfo);
            }
            catch (ArgumentException ae)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
