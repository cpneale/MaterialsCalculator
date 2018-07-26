using MaterialsCalculator.Interfaces.Providers;

namespace MaterialsCalculator.Core.Queries
{
    public class PaintDetailsQuery : IPaintDetailsQuery
    {
        public int PaintId { get; set; }
    }
}
