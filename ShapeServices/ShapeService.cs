using CalculatorForShapes.ShapeModel;
using System.Reflection;

namespace CalculatorForShapes.ShapeServices
{
    internal class ShapeService
    {
        private Dictionary<int, Func<double>> shapeMethods = new Dictionary<int, Func<double>>();

        //internal double WriteCalcul(List<double> sideParametrs)
        //{
        //    var circle = new Circle(sideParametrs);
        //    var triangle = new Triangle(sideParametrs);

        //    shapeMethods.Add(1, parametrs => circle.AreaCalculator());
        //    shapeMethods.Add(3, parametrs => triangle.AreaCalculator());

        //    return shapeMethods[sideParametrs.Count](sideParametrs);
        //}

        internal double WriteCalculReflec(List<double> sideParametrs)
        {
            List<Type> derivedTypes = FindDerivedTypes<BasicModel>();

            foreach (Type derivedType in derivedTypes)
            {
                MethodInfo method = derivedType.GetMethod("AreaCalculator");
                FieldInfo property = derivedType.GetField("Count", BindingFlags.Instance | BindingFlags.NonPublic);
                if (method != null && property != null)
                {
                    var calculateDelegate = (Func<double>)Delegate.CreateDelegate(typeof(Func<double>), null, method);
                    var instance = Activator.CreateInstance(derivedType, sideParametrs);
                    var propertyValue = (int)property.GetValue(instance);
                    shapeMethods.Add(propertyValue, calculateDelegate);
                }
            }

            return shapeMethods[sideParametrs.Count]();
        }

        private static List<Type> FindDerivedTypes<TBase>()
        {
            var derivedTypes = new List<Type>();           
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (typeof(TBase).IsAssignableFrom(type) && !type.IsAbstract && type != typeof(TBase))
                {
                    derivedTypes.Add(type);
                }
            }

            return derivedTypes;
        }
    }
}
