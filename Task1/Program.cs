using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FirstHW.Model.Shape;
using FirstHW.Service;

namespace FirstHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(5, 6);
            var circle = new Circle(3 / Math.Sqrt(Math.PI));
            var square = new Square(2);
            var trapezium = new Trapezium(3, 7, 5, 4);
            var triangle = new Triangle(17, 17, 30);
            var shapes = new HashSet<IShape>()
            {
                circle, rectangle, square, trapezium, triangle
            };
            var shapeService = new ShapeService();
            Console.WriteLine(shapeService.CalculateSummaryArea(shapes));
            Console.WriteLine(shapeService.CalculateSummaryPerimeter(shapes));
        }
    }
}