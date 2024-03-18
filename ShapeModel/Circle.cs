namespace CalculatorForShapes.ShapeModel
{
    internal class Circle : BasicModel
    {
        internal readonly int Count = 1;

        public Circle(List<double> shapeMeasures)
        {
            ShapeMeasures = shapeMeasures;
            CountParametrs = 1;
        }

        /// <summary>
        /// Подсчет площади круга
        /// </summary>
        /// <returns></returns>
        public override double AreaCalculator() => Math.PI * Math.Pow(ShapeMeasures[0], 2);
    }
}
