using System;

namespace EntregaPokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokedex pokedex = new Pokedex();

            pokedex.OrdenaTipo();

            Console.WriteLine(pokedex);
        }
    }
}
