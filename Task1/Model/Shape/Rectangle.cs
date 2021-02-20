using System.ComponentModel.DataAnnotations;

namespace FirstHW.Model.Shape
{
    public class Rectangle : IShape
    {
        public double SideA { get; }
        public double SideB { get; }

        public Rectangle(double sideA, double sideB)
        {
            if (sideA <= 0 || sideB <= 0) 
                throw new ValidationException("One or both sides are less than or equal to zero");
            
            SideA = sideA;
            SideB = sideB;
        }

        public double CalculateArea()
        {
            return SideA * SideB;
        }

        public double CalculatePerimeter()
        {
            return (SideA + SideB) * 2;
        }
    }
}