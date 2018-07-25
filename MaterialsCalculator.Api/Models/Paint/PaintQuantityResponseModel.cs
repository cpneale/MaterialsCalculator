﻿using System.ComponentModel.DataAnnotations;

namespace MaterialsCalculator.Api.Models.Paint
{
    public class PaintQuantityResponseModel
    {
        [Required]
        public PaintQuantityRequestModel PaintInfo { get; set; }

        [Required]
        public double Area { get; set; }

        [Required]
        public double Volume { get; set; }

        [Required]
        public double Coverage { get; set; }

        [Required]
        public double TinsRequired { get; set; }

    }
}