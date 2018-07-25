using System;
using System.Collections.Generic;
using System.Text;
using MaterialsCalculator.Interfaces.MaterialModels;

namespace MaterialsCalculator.Core.MaterialModels
{
    internal class PaintInfo : IPaintInfo
    {
        public int PaintId { get; set; }
        public string PaintName { get; set; }
        public double CoverageM2PerTin { get; set; }
    }
}
