using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FirstHW.Model.Shape;

namespace FirstHW.Service
{
    public class ShapeService
    {
        public double CalculateSummaryArea([NotNull] IEnumerable<IShape> shapes)
        {
            return shapes.Sum(shape => shape.CalculateArea());
        }
        
        public double CalculateSummaryPerimeter([NotNull] IEnumerable<IShape> shapes)
        {
            return shapes.Sum(shape => shape.CalculatePerimeter());
        }
    }
}