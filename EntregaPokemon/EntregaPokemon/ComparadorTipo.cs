using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EntregaPokemon
{
    class ComparadorTipo : IComparer<Pokemon>
    {
        public int Compare([AllowNull] Pokemon x, [AllowNull] Pokemon y)
        {
            int comparison = x.Type1.CompareTo(y.Type1);

            if (comparison > 0)
            {
                return 1;
            }
            else
            {
                if (comparison < 0)
                {
                    return -1;
                }
                else
                {
                    return x.Type2.CompareTo(y.Type2);
                }
            }
        }
    }
}
