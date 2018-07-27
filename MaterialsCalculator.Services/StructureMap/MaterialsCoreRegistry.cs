using MaterialsCalculator.Interfaces.Providers;
using MaterialsCalculator.Providers.QueryHandlers;
using StructureMap;

namespace MaterialsCalculator.Core.StructureMap
{
    public class MaterialsCoreRegistry : Registry
    {
        public MaterialsCoreRegistry()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            For<IPaintDetailsQueryHandler<IPaintDetailsQuery>>()
                .Use<FakePaintDetailsQueryHandler>();
        }
    }
}
