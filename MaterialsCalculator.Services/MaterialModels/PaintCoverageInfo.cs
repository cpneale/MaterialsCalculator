using MaterialsCalculator.Interfaces.MaterialModels;

namespace MaterialsCalculator.Core.MaterialModels
{
    public class PaintCoverageInfo : IPaintCoverageInfo
    {
        public double Volume { get; set; }
        public double TinsRequired { get; set; }
        public double Area { get; set; }
        public double CoverageM2PerTin { get; set; }
    }
}
