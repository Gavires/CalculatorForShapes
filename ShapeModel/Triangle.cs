using CalculatorForShapes.ShapeInterfaces;

namespace CalculatorForShapes.ShapeModel
{
    internal class Triangle : BasicModel, IAreaCalculator
    {
        private readonly bool isRightTriangle;
        private readonly bool isTriangle;

        /// <summary>
        /// Признак прямоугольного треугольника
        /// </summary>
        internal bool IsRightTriangle
        {
            get => isRightTriangle;
        }

        /// <summary>
        /// Признак соответствия вводных данных правилу построения треугольника
        /// </summary>
        internal bool IsTriangle
        {
            get => isTriangle;
        }

        public Triangle() { }

        public Triangle(IReadOnlyCollection<double> shapeMeasures)
        {
            ShapeMeasures = shapeMeasures;
            isTriangle = CheckTriangleValid(shapeMeasures);
            isRightTriangle = CheckRightTriangleCondition();
        }

        /// <summary>
        /// Проверка условия прямоугольности треугольника
        /// </summary>
        /// <returns></returns>
        private bool CheckRightTriangleCondition()
        {
            double longestSide = Math.Max(Math.Max(ShapeMeasures.ElementAt(0), ShapeMeasures.ElementAt(1)), ShapeMeasures.ElementAt(2));
            double sumOfSquares = Math.Pow(ShapeMeasures.ElementAt(0), 2)
                + Math.Pow(ShapeMeasures.ElementAt(1), 2)
                + Math.Pow(ShapeMeasures.ElementAt(2), 2);
            return Math.Pow(longestSide, 2) * 2 == sumOfSquares;
        }

        /// <summary>
        /// Проверка правилам построения треугольника
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        private bool CheckTriangleValid(IReadOnlyCollection<double> sides) => (sides.ElementAt(0) + sides.ElementAt(1) > sides.ElementAt(2))
            && (sides.ElementAt(0) + sides.ElementAt(2) > sides.ElementAt(1))
            && (sides.ElementAt(1) + sides.ElementAt(2) > sides.ElementAt(0));

        /// <summary>
        /// Вычичисление площади треугольника
        /// </summary>
        /// <param name="shapeMeasure"></param>
        /// <returns></returns>
        public double Calculate(IReadOnlyCollection<double> sideParameters)
        {
            if (!CheckTriangleValid(sideParameters))
            {
                throw new InvalidOperationException("Введенные три значения сторон не могут образовать треугольник");
            }
            // Вычисляем полупериметр треугольника
            var square = (sideParameters.ElementAt(0) + sideParameters.ElementAt(1) + sideParameters.ElementAt(2)) / 2;

            // Вычисляем площадь треугольника по формуле Герона
            return Math.Sqrt(square * (square - sideParameters.ElementAt(0)) 
                                    * (square - sideParameters.ElementAt(1)) 
                                    * (square - sideParameters.ElementAt(2)));
        }
    }
}
