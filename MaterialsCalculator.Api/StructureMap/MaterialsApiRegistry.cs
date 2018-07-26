using MaterialsCalculator.Core.Services;
using MaterialsCalculator.Interfaces.Services;
using StructureMap;

namespace MaterialsCalculator.Api.StructureMap
{
    public class MaterialsApiRegistry : Registry
    {
        public MaterialsApiRegistry()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            For<IPaintService>()
                .Use<PaintService>();
        }
    }
}