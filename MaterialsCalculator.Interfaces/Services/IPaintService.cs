using System.Collections.Generic;
using MaterialsCalculator.Interfaces.Dimensions;
using MaterialsCalculator.Interfaces.MaterialModels;

namespace MaterialsCalculator.Interfaces.Services
{
    public interface IPaintService
    {
        IEnumerable<IPaintInfo> GetPaints();

        IPaintCoverageInfo CalculateCoverage(IRoom room, int paintId);
    }
}