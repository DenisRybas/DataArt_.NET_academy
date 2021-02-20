using System;
using System.ComponentModel.DataAnnotations;

namespace FirstHW.Model.Shape
{
    public class Triangle : IShape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0) 
                throw new ValidationException("One or more sides are less than or equal to zero");
            if (sideA >= sideB + sideC ||
                sideB >= sideA + sideC ||
                sideC >= sideA + sideB)
                throw new ValidationException("Such a triangle cannot exist");
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea()
        {
            var p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
    }
}