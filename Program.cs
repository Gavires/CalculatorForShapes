/*
 * Напишите на C# библиотеку для поставки внешним клиентам, 
 * которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 
 */

using CalculatorForShapes.ShapeServices;

namespace CalculatorForShapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello, World!");

                var cideParametrs = new List<double> { 1, 1, 3 };
                var calculator = new ShapeService();

                //Console.WriteLine($"Площадь введенной фигуры {calculator.WriteCalcul(cideParametrs)}");
                Console.WriteLine($"Площадь введенной фигуры {calculator.WriteCalculReflec(cideParametrs)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}