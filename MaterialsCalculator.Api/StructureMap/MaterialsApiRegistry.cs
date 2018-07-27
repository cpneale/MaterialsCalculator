using MaterialsCalculator.Core.Services;
using MaterialsCalculator.Core.StructureMap;
using MaterialsCalculator.Interfaces.Services;
using StructureMap;

namespace MaterialsCalculator.Api.StructureMap
{
    public class MaterialsApiRegistry : Registry
    {
        public MaterialsApiRegistry()
        {
            IncludeRegistries();
            CreateMappings();
        }

        private void IncludeRegistries()
        {
            IncludeRegistry(new MaterialsCoreRegistry());
        }

        private void CreateMappings()
        {
            For<IPaintService>()
                .Use<PaintService>();
        }
    }
}