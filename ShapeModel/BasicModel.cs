namespace CalculatorForShapes.ShapeModel
{
    internal abstract class BasicModel 
    {
        internal List<double> ShapeMeasures { get; set; } = new List<double>();
        //internal double Square { get; set; }

        internal int CountParametrs { get; set; }

        public abstract double AreaCalculator();
    }
}
