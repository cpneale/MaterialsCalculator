using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MaterialsCalculator.Api.Models;
using MaterialsCalculator.Api.Models.Paint;
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
                    paints.Select(p => new PaintQuantityRequestModel
                    {
                        PaintId = p.PaintId,
                        PaintName = p.PaintName
                    }).ToList();

                return Ok(materials);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route(@"CalculateQuantity")]
        public IHttpActionResult CalculateQuantity(PaintQuantityRequestModel paintInfo)
        {
            try
            {
                var coverageInfo = _paintService.CalculateCoverage(
                                        paintInfo.Height, paintInfo.Width, 
                                        paintInfo.Length, paintInfo.PaintId);

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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
