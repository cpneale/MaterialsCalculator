using System.Collections.Generic;
using MaterialsCalculator.Interfaces.MaterialModels;

namespace MaterialsCalculator.Interfaces.Services
{
    public interface IPaintService
    {
        IEnumerable<IPaintInfo> GetPaints();

        IPaintCoverageInfo CalculateCoverage(double roomHeight, double roomWidth,
                                                double roomLength, double coverage);
    }
}