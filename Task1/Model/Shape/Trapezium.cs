using System;
using System.ComponentModel.DataAnnotations;

namespace FirstHW.Model.Shape
{
    public class Trapezium : IShape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }
        public double SideD { get; }
        public double Height { get; }

        public Trapezium(double sideA, double sideB, double sideC, double sideD)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0 || sideD <= 0)
                throw new ValidationException("One or more sides are less than or equal to zero");
            if (sideA >= sideB + sideC + sideD ||
                sideB >= sideA + sideC + sideD ||
                sideC >= sideA + sideB + sideD ||
                sideD >= sideA + sideB + sideC)
                throw new ValidationException("Such a trapezium cannot exist");
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            SideD = sideD;
            Height = Math.Sqrt(
                Math.Pow(SideC, 2) - Math.Pow((Math.Pow(SideB - SideA, 2) + Math.Pow(SideC, 2)
                                               - Math.Pow(SideD, 2)) / 2 / (SideB - SideA), 2));
            if (double.IsNaN(Height))
                throw new ValidationException("Such a trapezium cannot exist");
        }

        public double CalculateArea()
        {
            return (SideA + SideB) / 2 * Height;
        }

        public double CalculatePerimeter()
        {
            return SideA + SideB + SideC + SideD;
        }
    }
}