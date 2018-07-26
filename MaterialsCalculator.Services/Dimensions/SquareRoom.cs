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
            var ceilingArea = Width * Length;
            var wallAreaWidth = (Width * Height) * 2; 
            var wallAreaLength = (Length * Height) * 2;
            
            return (ceilingArea + wallAreaLength + wallAreaWidth);
        }

        public double CalculateVolume()
        {
            return (Width * Height * Length);
        }
    }
}