using MaterialsCalculator.Interfaces.MaterialModels;

namespace MaterialsCalculator.Core.MaterialModels
{
    internal class PaintCoverageInfo : IPaintCoverageInfo
    {
        public double Volume { get; set; }
        public double TinsRequired { get; set; }
    }
}
