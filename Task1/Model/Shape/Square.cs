using System.ComponentModel.DataAnnotations;

namespace FirstHW.Model.Shape
{
    // Не наследую квадрат от прямоугольника, чтобы не нарушить принцип подстановки Барбары Лисков
    public class Square : IShape
    {
        private double Side { get; }

        public Square(double side)
        {
            if (side <= 0) 
                throw new ValidationException("Side is less than or equal to zero");
            Side = side;
        }

        public double CalculateArea()
        {
            return Side * Side;
        }

        public double CalculatePerimeter()
        {
            return Side * 4;
        }
    }
}