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
            var materials = 
                new PaintQuantityRequestModel { PaintId = 1, PaintName = "Magnolia"};
            return Ok(materials);
        }

        [HttpPost]
        [Route(@"CalculateQuantity")]
        public IHttpActionResult CalculateQuantity(PaintQuantityRequestModel paintInfo)
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

    }
}
