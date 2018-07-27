namespace MaterialsCalculator.Interfaces.MaterialModels
{ 
    public interface IPaintInfo
    {
        int PaintId { get; set; }

        string PaintName { get; set; }

        double CoverageM2PerTin { get; set; }
    }
}
