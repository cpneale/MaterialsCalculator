using MaterialsCalculator.Interfaces.MaterialModels;

namespace MaterialsCalculator.Providers.Entities
{
    public class PaintInfo : IPaintInfo
    {
        public int PaintId { get; set; }
        public string PaintName { get; set; }
        public double CoverageM2PerTin { get; set; }
    }
}
