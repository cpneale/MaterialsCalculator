using System;
using System.Collections.Generic;
using System.Web.Http;
using MaterialsCalculator.Api.Models;
using MaterialsCalculator.Api.Models.Paint;

namespace MaterialsCalculator.Api.Controllers
{
    [RoutePrefix("api/Materials")]
    public class PaintController : ApiController
    {
        [HttpGet]
        [Route("Paint")]
        public IHttpActionResult Get()
        {
            try
            {
                var materials =
                    new List<PaintQuantityRequestModel>
                    {
                        new PaintQuantityRequestModel { PaintId = 1, PaintName = "Magnolia" }
                    };
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
                var quantityInfo =
                    new PaintQuantityResponseModel
                    {
                        PaintInfo = paintInfo,
                        Area = 0.0,
                        Volume = 0.0,
                        Coverage = 1.2,
                        TinsRequired = 1
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
