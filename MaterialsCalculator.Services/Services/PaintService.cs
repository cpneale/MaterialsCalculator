using System;
using System.Collections.Generic;
using System.Linq;
using MaterialsCalculator.Core.MaterialModels;
using MaterialsCalculator.Core.Queries;
using MaterialsCalculator.Interfaces.Dimensions;
using MaterialsCalculator.Interfaces.Services;
using MaterialsCalculator.Interfaces.MaterialModels;
using MaterialsCalculator.Interfaces.Providers;

namespace MaterialsCalculator.Core.Services
{
    public class PaintService : IPaintService
    {
        private IPaintDetailsQueryHandler<IPaintDetailsQuery> _paintDetailsQueryHandler;

        public PaintService(IPaintDetailsQueryHandler<IPaintDetailsQuery> paintDetailsQueryHandler)
        {
            if (paintDetailsQueryHandler == null)
                throw new ArgumentNullException(nameof(paintDetailsQueryHandler));

            _paintDetailsQueryHandler = paintDetailsQueryHandler;
        }

        public IEnumerable<IPaintInfo> GetPaints()
        {
            return _paintDetailsQueryHandler.Handle(new PaintDetailsQuery());
        }

        public IPaintCoverageInfo CalculateCoverage(IRoom room, int paintId)
        {
            var paintQuery = new PaintDetailsQuery() {PaintId = paintId};
            var paint = _paintDetailsQueryHandler.Handle(paintQuery).First();

            var area = room.CalculateArea();
            var volume = room.CalculateVolume();
            var tinsRequired = CalculateTinsRequired(room, paint.CoverageM2PerTin);

            return new PaintCoverageInfo
            {
                Volume = volume,
                TinsRequired = tinsRequired,
                CoverageM2PerTin = paint.CoverageM2PerTin,
                Area = area
            };
        }

        private double CalculateTinsRequired(IRoom room, double coverage)
        {
           return room.CalculateArea() / coverage;
        }
    }
}
