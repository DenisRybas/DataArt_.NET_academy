using System.ComponentModel.DataAnnotations;
using FirstHW.Model.Shape;
using Xunit;

namespace TestProject1
{
    public class CreationTests
    {
        [Fact]
        public void CreateRectangle_InputNegativeSide1_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Rectangle(-1, 1));
        }
     
        [Fact]
        public void CreateRectangle_InputNegativeSide2_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Rectangle(1, -1));
        }

        [Fact]
        public void CreateRectangle_InputZeroSide1_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Rectangle(0, 1));
        }
        
        [Fact]
        public void CreateRectangle_InputZeroSide2_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Rectangle(1, 0));
        }
        
        [Fact]
        public void CreateCircle_InputNegativeRadius_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Circle(-1));
        }
        
        [Fact]
        public void CreateCircle_InputZeroRadius_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Circle(0));
        }
        
        [Fact]
        public void CreateTriangle_InputNegativeSide1_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(-1, 1, 1));
        }
        
        [Fact]
        public void CreateTriangle_InputNegativeSide2_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(1, -1, 1));
        }
        
        [Fact]
        public void CreateTriangle_InputNegativeSide3_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(1, 1, -1));
        }
        
        [Fact]
        public void CreateTriangle_InputZeroSide1_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(0, 1, 1));
        }
        
        [Fact]
        public void CreateTriangle_InputZeroSide2_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(1, 0, 1));
        }
        
        [Fact]
        public void CreateTriangle_InputZeroSide3_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(1, 1, 0));
        }
        
        [Fact]
        public void CreateTriangle_InputSizeABiggerThanSumOfOthers_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(5, 1, 1));
        }
        
        [Fact]
        public void CreateTriangle_InputSizeBBiggerThanSumOfOthers_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(1, 5, 1));
        }
        
        [Fact]
        public void CreateTriangle_InputSizeCBiggerThanSumOfOthers_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Triangle(1, 1, 5));
        }
        
        [Fact]
        public void CreateTrapezium_InputNegativeSide1_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(-1, 1, 1, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputNegativeSide2_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(1, -1, 1, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputNegativeSide3_ThrowsValidationException()
        {            
            Assert.Throws<ValidationException>(() => new Trapezium(1, 1, -1, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputNegativeSide4_ThrowsValidationException()
        {            
            Assert.Throws<ValidationException>(() => new Trapezium(1, 1, 1, -1));
        }
        
        [Fact]
        public void CreateTrapezium_InputZeroSide1_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(0, 1, 1, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputZeroSide2_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(1, 0, 1, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputZeroSide3_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(1, 1, 0, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputZeroSide4_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(1, 1, 1, 0));
        }
        
        [Fact]
        public void CreateTrapezium_InputSizeABiggerThanSumOfOthers_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(5, 1, 1, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputSizeBBiggerThanSumOfOthers_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(1, 5, 1, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputSizeCBiggerThanSumOfOthers_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(1, 1, 5, 1));
        }
        
        [Fact]
        public void CreateTrapezium_InputSizeDBiggerThanSumOfOthers_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Trapezium(1, 1, 1, 5));
        }
        
        [Fact]
        public void CreateSquare_InputNegativeSide_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Square(-1));
        }
        
        [Fact]
        public void CreateSquare_InputZeroSide_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => new Square(0));
        }
    }
}