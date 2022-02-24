using System;

namespace EntregaFracciones
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = 2.25;
            Fraccion f1 = new Fraccion(d);
            Fraccion f2 = new Fraccion(3, -2);
            
            Console.WriteLine(f1);
            Console.WriteLine(f1.Simplificar());
            Console.WriteLine(-f1);
            Console.WriteLine(f2);
            Console.WriteLine(-f2);

            Fraccion f3 = new Fraccion(2, 4);
            Fraccion f4 = new Fraccion(1, 4);
            Fraccion f5 = new Fraccion(1, -4);
            
            Console.WriteLine($"2/4 + 1/4 = {f3 + f4}");
            Console.WriteLine($"2/4 - 1/4 = {f3 - f4}");
            Console.WriteLine($"2/4 * 1/4 = {f3 * f4}");
            Console.WriteLine($"2/4 / 1/4 = {f3 / f4}");

            Console.WriteLine();

            Console.WriteLine($"2/4 + 1/-4 = {f3 + f5}");
            Console.WriteLine($"2/4 - 1/-4 = {f3 - f5}");
            Console.WriteLine($"2/4 * 1/-4 = {f3 * f5}");
            Console.WriteLine($"2/4 / 1/-4 = {f3 / f5}");

            Console.WriteLine();

            Fraccion f6 = new Fraccion(2, 3);
            Fraccion f7 = new Fraccion(3, 2);
            Fraccion f8 = new Fraccion(10, 2);
            Fraccion f9 = new Fraccion(5, 3);
            Console.WriteLine($"2/3 == 3/2 = {f6 == f7}");
            Console.WriteLine($"2/3 != 3/2 = {f6 != f7}");
            Console.WriteLine($"2/3 > 3/2 = {f6 > f7}");
            Console.WriteLine($"2/3 < 3/2 = {f6 < f7}");
            Console.WriteLine($"2/3 >= 3/2 = {f6 >= f7}");
            Console.WriteLine($"2/3 <= 3/2 = {f6 <= f7}");
            Console.WriteLine($"10/2 > 5/3 = {f8 > f9}");
            Console.WriteLine($"10/2 < 5/3 = {f8 < f9}");

            Console.WriteLine();

            Console.WriteLine($"2/4 + 2 = {f3 + 2}");

        }
    }
}
