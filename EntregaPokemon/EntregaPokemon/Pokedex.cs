using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EntregaPokemon
{
    class Pokedex
    {
        private List<Pokemon> listaPokemon;
        private readonly string path = "./pokedex.prn";

        public Pokedex ()
        {
            listaPokemon = new List<Pokemon>();
            listaPokemon.AddRange(GetDataFromFile(path));
        }
        
        private List<Pokemon> GetDataFromFile (string path)
        {
            List<Pokemon> temp = new List<Pokemon>();
            Pokemon pokemon;
            string[] record;

            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    record = sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    
                    if (record.Length == 9)
                    {
                        pokemon = new Pokemon(record[1], int.Parse(record[2]), int.Parse(record[3]), int.Parse(record[4]), int.Parse(record[5]), int.Parse(record[6]), int.Parse(record[7]), (PokemonType) Enum.Parse(typeof(PokemonType), record[8]));
                    }
                    else
                    {
                        pokemon = new Pokemon(record[1], int.Parse(record[2]), int.Parse(record[3]), int.Parse(record[4]), int.Parse(record[5]), int.Parse(record[6]), int.Parse(record[7]), (PokemonType)Enum.Parse(typeof(PokemonType), record[8]), (PokemonType)Enum.Parse(typeof(PokemonType), record[9]));
                    }

                    temp.Add(pokemon);
                }

                sr.Close();
            }
            else
            {
                throw new Exception($"No se ha encontrado el fichero {path}.");
            }

            return temp;
        }
        private string Representation ()
        {
            StringBuilder sb = new StringBuilder ();
            int n = 13;
            
            sb.AppendLine($"{"Nombre".PadRight(n)}{"Vida".PadRight(n)}{"Ataque".PadRight(n)}{"Defensa".PadRight(n)}{"Velocidad".PadRight(n)}{"Ataque Sp".PadRight(n)}{"Defensa Sp".PadRight(n)}{"Tipo I".PadRight(n)}{"Tipo II".PadRight(n)}");
            
            foreach (Pokemon pokemon in listaPokemon)
            {
                sb.AppendLine(pokemon.ToString());
            }

            return sb.ToString();
        }
        
        public void OrdenaNombre ()
        {
            //Implementación OrdenaBurbuja
            Pokemon temp;

            for (int i = 0; i < listaPokemon.Count - 1; i++)
            {
                for (int j = 0; j < listaPokemon.Count - 1; j++)
                {
                    if (listaPokemon[j].Name.CompareTo(listaPokemon[j + 1].Name) > 0)
                    {
                        temp = listaPokemon[j + 1];
                        listaPokemon[j + 1] = listaPokemon[j];
                        listaPokemon[j] = temp;
                    }
                }
            }
        }
        public void OrdenaAtaque ()
        {
            listaPokemon.Sort();//Ordena por ataque por el IComparable y el CompareTo definidos en la clase Pokemon.
        }
        public void OrdenaTipo ()
        {
            listaPokemon.Sort(new ComparadorTipo());
        }

        public override string ToString()
        {
            return Representation();
        }
    }
}
