using System;

namespace EntregaHora
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prueba 1");
            Hora tiempo1 = new Hora(3600);

            Console.WriteLine(tiempo1);

            tiempo1.SumaHoras(3);
            tiempo1.SumaMinutos(2);
            tiempo1.SumaSegundos(30);

            Console.WriteLine(tiempo1);

            Console.WriteLine("Prueba 2");
            Hora tiempo2 = new Hora(1, 1, 1);

            Console.WriteLine(tiempo2);

            tiempo2.SumaMinutos(120);
            tiempo2.SumaSegundos(120);

            Console.WriteLine(tiempo2);

            Console.WriteLine("Prueba 3");
            Hora tiempo3 = new Hora(3600);
            Hora tiempo4 = new Hora(0, 30, 0);

            Console.WriteLine(tiempo3 - tiempo4);
            Console.WriteLine(tiempo2 + tiempo4);
        }
    }
}
