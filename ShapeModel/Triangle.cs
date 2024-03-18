namespace CalculatorForShapes.ShapeModel
{
    internal class Triangle : BasicModel
    {
        private readonly bool isRightTriangle;
        private readonly bool isTriangle;
        internal readonly int Count = 3;

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

        public Triangle(List<double> shapeMeasures)
        {
            ShapeMeasures = shapeMeasures;
            isTriangle = CheckTriangleValid(shapeMeasures);
            isRightTriangle = CheckRightTriangleCondition();
            CountParametrs = 3;
        }

        /// <summary>
        /// Проверка условия прямоугольности треугольника
        /// </summary>
        /// <returns></returns>
        private bool CheckRightTriangleCondition()
        {

            double longestSide = Math.Max(Math.Max(ShapeMeasures[0], ShapeMeasures[1]), ShapeMeasures[2]);
            double sumOfSquares = Math.Pow(ShapeMeasures[0], 2)
                + Math.Pow(ShapeMeasures[1], 2)
                + Math.Pow(ShapeMeasures[2], 2);
            return Math.Pow(longestSide, 2) * 2 == sumOfSquares;
        }

        /// <summary>
        /// Проверка правилам построения треугольника
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        private bool CheckTriangleValid(List<double> sides) => (sides[0] + sides[1] > sides[2])
            && (sides[0] + sides[2] > sides[1])
            && (sides[1] + sides[2] > sides[0]);

        /// <summary>
        /// Вычичисление площади треугольника
        /// </summary>
        /// <param name="shapeMeasure"></param>
        /// <returns></returns>
        public override double AreaCalculator()
        {
            if (!IsTriangle)
            {
                throw new InvalidOperationException("Введенные три значения сторон не могут образовать треугольник");
            }
            // Вычисляем полупериметр треугольника
            var square = (ShapeMeasures[0] + ShapeMeasures[1] + ShapeMeasures[2]) / 2;

            // Вычисляем площадь треугольника по формуле Герона
            return Math.Sqrt(square * (square - ShapeMeasures[0]) * (square - ShapeMeasures[1]) * (square - ShapeMeasures[2]));
        }
    }
}
