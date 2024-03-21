using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForShapes.ShapeInterfaces
{
    internal interface IAreaCalculator
    {
        double Calculate(IReadOnlyCollection<double> sideParameters);
    }
}
