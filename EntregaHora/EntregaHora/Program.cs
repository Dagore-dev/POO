using System;

namespace EntregaHora
{
    class Program
    {
        static void Main(string[] args)
        {
            Hora tiempo = new Hora(3600);

            Console.WriteLine(tiempo.SegundosTotales);

            tiempo.Horas = 3;
            tiempo.SegundosTotales += 3600;

            Console.WriteLine(tiempo.SegundosTotales);
            Console.WriteLine(tiempo.Horas);

            tiempo.Horas = 1;
            Console.WriteLine(tiempo.SegundosTotales);
            Console.WriteLine(tiempo.Horas);
        }
    }
}
