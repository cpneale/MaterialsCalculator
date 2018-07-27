using System.Collections.Generic;
using System.Linq;
using MaterialsCalculator.Interfaces.MaterialModels;
using MaterialsCalculator.Interfaces.Providers;
using MaterialsCalculator.Providers.Entities;

namespace MaterialsCalculator.Providers.QueryHandlers
{
    public class FakePaintDetailsQueryHandler : IPaintDetailsQueryHandler<IPaintDetailsQuery>
    {
        private IEnumerable<IPaintInfo> _paintInfo;

        public FakePaintDetailsQueryHandler()
        {
            _paintInfo = new List<IPaintInfo>()
            {
                new PaintInfo {PaintId = 1, PaintName = "Magnolia", CoverageM2PerTin = 10.00},
                new PaintInfo {PaintId = 2, PaintName = "White", CoverageM2PerTin = 12.00},
                new PaintInfo {PaintId = 3, PaintName = "Green", CoverageM2PerTin = 9.50}
            };
        }
        public IEnumerable<IPaintInfo> Handle(IPaintDetailsQuery query)
        {
            if (query.PaintId == 0)
                return _paintInfo;

            return _paintInfo.Where(p => p.PaintId == query.PaintId);
        }
    }
}
