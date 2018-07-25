namespace MaterialsCalculator.Interfaces.MaterialModels
{
    public interface IPaintCoverageInfo
    {
        double Volume { get; set; }

        double TinsRequired { get; set; }
        double Area { get; set; }
        double CoverageM2PerTin { get; set; }
    }
}