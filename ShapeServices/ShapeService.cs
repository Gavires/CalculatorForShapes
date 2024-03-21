using CalculatorForShapes.ShapeInterfaces;
using CalculatorForShapes.ShapeModel;

namespace CalculatorForShapes.ShapeServices
{
    internal class ShapeService
    {
        readonly Dictionary<int, IAreaCalculator> dictionary;

        public ShapeService()
        {
            this.dictionary = new Dictionary<int, IAreaCalculator>()
            {
                {1, new Circle()},
                {3, new Triangle()}
            };
        }

        public double Calculate(IReadOnlyCollection<double> sideParameters)
        {
            if (!this.dictionary.TryGetValue(sideParameters.Count, out IAreaCalculator areaCalculator))
                throw new Exception($"Словарь уже имеет ключ {sideParameters.Count}");

            return areaCalculator.Calculate(sideParameters);
        }
    }
}
