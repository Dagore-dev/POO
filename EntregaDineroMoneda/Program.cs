using System;

namespace EntregaDineroMoneda
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cambiamos el encoding para que pinte los símbolos de las monedas por consola.
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Moneda moneda = new Moneda(TipoMoneda.euro, 2, "€", 1m);
            Console.WriteLine(moneda.Simbolo);
            Dinero dinero = new Dinero(10.756, TipoMoneda.libra);
            Console.WriteLine(dinero.ToString());
            Console.WriteLine(dinero.ToString(TipoMoneda.dolar));
            Console.WriteLine(dinero.ToString(TipoMoneda.euro));

            //Probando operadores aritméticos
            Dinero d1 = new Dinero(1, TipoMoneda.euro);
            Dinero d2 = new Dinero(2, TipoMoneda.euro);
            Dinero d3 = new Dinero(1, TipoMoneda.dolar);

            Console.WriteLine(d1 + d2);
            Console.WriteLine(d1 + d3);
            Console.WriteLine(d2 - d1);
            Console.WriteLine(d1 - d3);
            Console.WriteLine(d1 * 2);
            Console.WriteLine(2 * d1);
            Console.WriteLine(d1 / 2);

            //Probando operadores lógicos
            Dinero d4 = new Dinero(1, TipoMoneda.euro);
            Dinero d5 = d4.ConvierteEn(TipoMoneda.dolar);
            
            Console.WriteLine(d1 == d4);
            Console.WriteLine(d1 != d4);
            Console.WriteLine(d1 == d5);
            Console.WriteLine(d1 != d5);
            Console.WriteLine(d1 < d4);
            Console.WriteLine(d1 <= d4);
            Console.WriteLine(d1 > d3);
        }
    }
}
