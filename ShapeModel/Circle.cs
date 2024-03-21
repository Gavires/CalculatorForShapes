using CalculatorForShapes.ShapeInterfaces;

namespace CalculatorForShapes.ShapeModel
{
    internal class Circle : BasicModel, IAreaCalculator
    {
        public Circle() { }

        public Circle(IReadOnlyCollection<double> shapeMeasures)
        {
            ShapeMeasures = shapeMeasures;
        }

        /// <summary>
        /// Подсчет площади круга
        /// </summary>
        /// <returns></returns>
        public double Calculate(IReadOnlyCollection<double> sideParameters) => Math.PI * Math.Pow(sideParameters.ElementAt(0), 2);
    }
}
