using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionClases
{
    class PokemonTeam
    {
        private List<Pokemon> list = new List<Pokemon>();
        public void InsertPokemon (Pokemon pokemon)
        {
            list.Add(pokemon);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i].ToString());
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
