using System;
using System.Collections.Generic;
using System.Text;
using MaterialsCalculator.Core.MaterialModels;
using MaterialsCalculator.Interfaces.Dimensions;
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

        public IPaintCoverageInfo CalculateCoverage(IRoom room, int paintId)
        {
            //simulate getting paint from provider for now
            var paint =
                new PaintInfo {PaintId = 1, PaintName = "Magnolia", CoverageM2PerTin = 10.00};

            var area = room.CalculateArea();
            var volume = room.CalculateVolume();
            var tinsRequired = CalculateTinsRequired();

            return new PaintCoverageInfo
            {
                Volume = volume,
                TinsRequired = tinsRequired,
                CoverageM2PerTin = paint.CoverageM2PerTin,
                Area = area
            };
        }

        private double CalculateTinsRequired()
        {
           return 0.0;
        }
    }
}
