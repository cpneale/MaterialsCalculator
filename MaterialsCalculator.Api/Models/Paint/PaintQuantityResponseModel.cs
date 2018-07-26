using System.ComponentModel.DataAnnotations;

namespace MaterialsCalculator.Api.Models.Paint
{
    public class PaintQuantityResponseModel
    {
        [Required]
        public PaintRequestModelSquareRoom PaintInfo { get; set; }

        [Required]
        public double Area { get; set; }

        [Required]
        public double Volume { get; set; }

        [Required]
        public double CoverageM2PerTin { get; set; }

        [Required]
        public double TinsRequired { get; set; }

    }
}