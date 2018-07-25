using System;
using System.Collections.Generic;
using System.Text;
using MaterialsCalculator.Core.MaterialModels;
using MaterialsCalculator.Interfaces.Services;
using MaterialsCalculator.Interfaces.MaterialModels;

namespace MaterialsCalculator.Core.Services
{
    public class PaintService : IPaintService
    {
        public IEnumerable<IPaintInfo> GetPaints()
        {
            return new List<IPaintInfo>
            {
                new PaintInfo {PaintId = 1, PaintName = "Magnolia", CoverageM2PerTin = 10.00},
                new PaintInfo {PaintId = 2, PaintName = "White", CoverageM2PerTin = 12.00}
            };
        }

        public IPaintCoverageInfo CalculateCoverage(double roomHeight, double roomWidth,
                                                     double roomLength, int paintId)
        {
            return new PaintCoverageInfo
            {
                Volume = 10,
                TinsRequired = 1,
                CoverageM2PerTin = 12,
                Area = 100
            };
        }
    }
}
