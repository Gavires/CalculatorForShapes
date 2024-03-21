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
                var service = new ShapeService();

                Console.WriteLine($"Площадь введенной фигуры {service.Calculate(new[] { 4.25 })}");

                Console.WriteLine($"Площадь введенной фигуры {service.Calculate(new[] { 16.25 })}");

                Console.WriteLine($"Площадь введенной фигуры {service.Calculate(new[] { 4.25, 14, 10 })}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}