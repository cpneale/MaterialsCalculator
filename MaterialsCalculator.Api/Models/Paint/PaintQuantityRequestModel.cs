using System.ComponentModel.DataAnnotations;

namespace MaterialsCalculator.Api.Models.Paint
{
    public class PaintQuantityRequestModel
    {
        [Required]
        public int PaintId { get; set; }

        [Required]
        public string PaintName { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

    }
}