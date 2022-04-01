using System;

namespace Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Temperatura celsius = new Temperatura(0, UnidadTemperatura.Celsius);
            Temperatura kelvin = celsius.ConvierteEn(UnidadTemperatura.Kelvin);
            Temperatura farenheit = kelvin.ConvierteEn(UnidadTemperatura.Farenheit);

            //Console.WriteLine(celsius);
            //Console.WriteLine(kelvin);
            //Console.WriteLine(farenheit);

            Temperatura farenheit2 = new Temperatura(212, UnidadTemperatura.Farenheit);
            Temperatura kelvin2 = farenheit2.ConvierteEn(UnidadTemperatura.Kelvin);
            Temperatura celsius2 = kelvin2.ConvierteEn(UnidadTemperatura.Celsius);

            //Console.WriteLine(farenheit2);
            //Console.WriteLine(kelvin2);
            //Console.WriteLine(celsius2);

            //Console.WriteLine();
            //Console.WriteLine("Operador ==");
            //Console.WriteLine(farenheit2 == celsius2);
            //Console.WriteLine(kelvin2 == celsius2);
            //Console.WriteLine(celsius2 != celsius);

            Console.WriteLine(kelvin2 > farenheit);
            Console.WriteLine(kelvin2 >= farenheit2);
        }
    }
}
