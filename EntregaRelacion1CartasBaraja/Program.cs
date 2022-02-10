using System;
using System.Collections.Generic;

namespace EntregaRelacion1CartasBaraja
{
    class Program
    {
        static void Main(string[] args)
        {
            /*7 y medio*/
            Baraja deck = new Baraja(true);
            Carta newCart;
            List<Carta> pool = new List<Carta>();
            string input;
            bool stop = false;
            decimal points = 0;

            Console.WriteLine("7 y medio, pide cartas hasta que llegues a 7.5, te pases de ese valor o decidas plantarte.");

            while (points < 7.5m && !stop)
            {
                newCart = deck.Robar();
                points += newCart.Valor7ymedia;
                pool.Add(newCart);

                for (int i = 0; i < pool.Count; i++)
                {
                    Console.Write($"{pool[i]}, ");
                }
                
                Console.WriteLine($"tienes {points} puntos.");
                
                if (points > 7.5m)
                {
                    Console.WriteLine("Te has pasado!");
                }
                else if (points == 7.5m)
                {
                    Console.WriteLine("Has ganado!");
                }
                else
                {
                    Console.WriteLine("¿Quieres otra carta? (Introduce 0 para terminar y 1 para continuar)");
                    Console.Write("(0 / 1): ");
                    input = Console.ReadLine().Trim();
                    stop = input != "1";
                }
            }

        }
    }
}
