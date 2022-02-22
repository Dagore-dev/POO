using System;

namespace TresEnRaya
{
    class Program
    {
        static void Main(string[] args)
        {
            TresEnRaya tresEnRaya = new TresEnRaya();
            int position;

            tresEnRaya.DibujaTablero();

            Console.WriteLine("Tres en raya");

            while (!tresEnRaya.GanaJugadorUno() && !tresEnRaya.GanaJugadorUno() && tresEnRaya.QuedanMovimientos())
            {

                Console.Write("El jugador 1 introduce su posición: ");
                position = int.Parse(Console.ReadLine());

                while (!tresEnRaya.MovimientoValido(position))
                {
                    Console.Write("Esa posición no es válida, introduce otra:");
                    position = int.Parse(Console.ReadLine());
                }

                tresEnRaya.MueveJugadorUno(position);
                tresEnRaya.DibujaTablero();
                if (tresEnRaya.GanaJugadorUno())
                {
                    break;
                }

                Console.Write("El jugador 2 introduce su posición: ");
                position = int.Parse(Console.ReadLine());

                while (!tresEnRaya.MovimientoValido(position))
                {
                    Console.Write("Esa posición no es válida, introduce otra:");
                    position = int.Parse(Console.ReadLine());
                }

                tresEnRaya.MueveJugadorDos(position);
                tresEnRaya.DibujaTablero();
            }

            Console.WriteLine();

            if (tresEnRaya.GanaJugadorUno())
            {
                Console.WriteLine("Gana el jugador 1!");
            }
            else
            {
                if (tresEnRaya.GanaJugadorDos())
                {
                    Console.WriteLine("Gana el jugador 2!");
                }
                else
                {
                    Console.WriteLine("Empate!");
                }
            }
        }
    }
}
