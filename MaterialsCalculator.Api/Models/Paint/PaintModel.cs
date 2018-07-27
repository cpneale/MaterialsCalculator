using System.ComponentModel.DataAnnotations;

namespace MaterialsCalculator.Api.Models.Paint
{
    public class PaintModel
    {
        [Required]
        public int PaintId { get; set; }

        [Required]
        public string PaintName { get; set; }

        public double CoverageM2PerTin { get; set; }

    }
}