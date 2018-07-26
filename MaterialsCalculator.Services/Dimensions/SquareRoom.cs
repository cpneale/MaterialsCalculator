using MaterialsCalculator.Interfaces.Dimensions;

namespace MaterialsCalculator.Core.Dimensions
{
    public class SquareRoom : IRoom
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

        public double CalculateArea()
        {
            throw new System.NotImplementedException();
        }

        public double CalculateVolume()
        {
            throw new System.NotImplementedException();
        }
    }
}