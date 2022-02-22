using System;

namespace TresEnRaya
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Tres en raya");
            int mode;

            Console.WriteLine("Escoge modo de juego:");
            Console.WriteLine("1: Jugador contra jugador.");
            Console.WriteLine("2: Jugador contra IA fácil.");
            Console.WriteLine("Otra opción: Salir.");
            Console.WriteLine();
            Console.Write("Introduce tu opción: ");

            mode = int.Parse(Console.ReadLine());

            switch (mode)
            {
                case 1: Play(false); break;
                case 2: Play(true); break;
                default: Console.WriteLine("Adios!"); break;
            }

        }
        static void Play (bool ia)
        {
            TresEnRaya tresEnRaya = new TresEnRaya();
            Random r = new Random();
            int random = r.Next(0, 2);
            
            Console.WriteLine();
            tresEnRaya.DibujaTablero();
            Console.WriteLine();

            while (!tresEnRaya.GanaJugadorUno() && !tresEnRaya.GanaJugadorDos() && tresEnRaya.QuedanMovimientos())
            {
                if (ia)
                {
                    if (random == 0)
                    {
                        Movimiento(tresEnRaya, 1);
                        if (tresEnRaya.GanaJugadorUno() || !tresEnRaya.QuedanMovimientos())
                        {
                            break;
                        }

                        tresEnRaya.MueveOrdenadorDos();
                        tresEnRaya.DibujaTablero();
                        Console.WriteLine();
                    }
                    else
                    {
                        tresEnRaya.MueveOrdenadorUno();
                        tresEnRaya.DibujaTablero();
                        Console.WriteLine();

                        if (tresEnRaya.GanaJugadorUno() || !tresEnRaya.QuedanMovimientos())
                        {
                            break;
                        }
                        Movimiento(tresEnRaya, 2);
                    }

                }
                else
                {
                    Movimiento(tresEnRaya, 1);
                    if (tresEnRaya.GanaJugadorUno() || !tresEnRaya.QuedanMovimientos())
                    {
                        break;
                    }

                    Movimiento(tresEnRaya, 2);
                }
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
        static void Movimiento (TresEnRaya tresEnRaya, int player)
        {
            int position;

            Console.WriteLine();
            Console.Write($"El jugador {player} introduce su posición: ");
            position = int.Parse(Console.ReadLine());

            while (!tresEnRaya.MovimientoValido(position))
            {
                Console.Write("Esa posición no es válida, introduce otra:");
                position = int.Parse(Console.ReadLine());
            }

            if (player == 1)
            {
                tresEnRaya.MueveJugadorUno(position);
            }
            else
            {
                tresEnRaya.MueveJugadorDos(position);
            }

            tresEnRaya.DibujaTablero();
            Console.WriteLine();
        }
    }
}
