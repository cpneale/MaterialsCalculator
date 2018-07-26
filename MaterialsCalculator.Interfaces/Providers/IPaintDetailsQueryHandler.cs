using System.Collections.Generic;
using MaterialsCalculator.Interfaces.MaterialModels;

namespace MaterialsCalculator.Interfaces.Providers
{
    public interface IPaintDetailsQueryHandler<TQuery>
    {
        IEnumerable<IPaintInfo> Handle(TQuery query);
    }
}