using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EntregaPokemon
{
    class Pokedex
    {
        private List<Pokemon> listaPokemon;
        private string path = "./pokedex.prn";

        public Pokedex ()
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                listaPokemon = new List<Pokemon>();

                Console.WriteLine("ok");

                sr.Close();
            }
            else
            {
                throw new Exception($"No se ha encontrado el fichero {path}.");
            }
        }
    }
}
