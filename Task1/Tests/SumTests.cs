using System;
using System.Collections.Generic;
using FirstHW.Model.Shape;
using FirstHW.Service;
using Xunit;

namespace FirstHW.Tests
{
    public class SumTests
    {
        private ShapeService _shapeService;

        public SumTests()
        {
            _shapeService = new ShapeService();
        }

        //Doesn't work because I didn't recalculate the area for expected
        [Fact]
        public void CalculateSummaryArea()
        {
            var rectangle = new Rectangle(5, 6);
            var circle = new Circle(3 / Math.Sqrt(Math.PI));
            var rectangle1 = new Rectangle(5, 6);
            var circle1 = new Circle(3 / Math.Sqrt(Math.PI));
            var square = new Square(2);
            var square1 = new Square(2);
            var trapezium = new Trapezium(3, 2, 3, 3);
            var trapezium1 = new Trapezium(2, 2, 2, 2);
            var triangle = new Triangle(17, 17, 30);
            var triangle1 = new Triangle(17, 17, 30);
            var shapes = new HashSet<IShape>()
            {
                circle, circle1,
                rectangle, rectangle1,
                square, square1,
                trapezium, trapezium1,
                triangle,triangle1
            };
            
            //Expected result calculated by me
            Assert.Equal(78, _shapeService.CalculateSummaryArea(shapes));
        }

        //Doesn't work because I didn't recalculate the perimeter for expected
        [Fact]
        public void CalculateSummaryPerimeter()
        {
            var rectangle = new Rectangle(6, 6);
            var circle = new Circle(3 / Math.PI);
            var rectangle1 = new Rectangle(6, 6);
            var circle1 = new Circle(3 / Math.PI);
            var square = new Square(2);
            var square1 = new Square(2);
            var trapezium = new Trapezium(2, 2, 2, 2);
            var trapezium1 = new Trapezium(2, 2, 2, 2);
            var triangle = new Triangle(17, 17, 30);
            var triangle1 = new Triangle(17, 17, 30);
            var shapes = new HashSet<IShape>()
            {
                circle, circle1,
                rectangle, rectangle1,
                square, square1,
                trapezium, trapezium1,
                triangle,triangle1
            };

            //Expected result calculated by me
            Assert.Equal(60, _shapeService.CalculateSummaryPerimeter(shapes));
        }
        
        [Fact]
        public void CalculateSummaryArea_InputEmptyCollection_Expected0()
        {
            Assert.Equal(0, _shapeService.CalculateSummaryArea(new HashSet<IShape>()));
        }
        
        [Fact]
        public void CalculateSummaryPerimeter_InputEmptyCollection_Expected0()
        {
            Assert.Equal(0, _shapeService.CalculateSummaryPerimeter(new HashSet<IShape>()));
        }

        [Fact]
        public void CalculateSummaryPerimeter_InputNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _shapeService.CalculateSummaryPerimeter(null));
        }

        [Fact]
        public void CalculateSummaryArea_InputNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _shapeService.CalculateSummaryArea(null));
        }
    }
}