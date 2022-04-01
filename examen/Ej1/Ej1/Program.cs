using System;

namespace Ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ColeccionOnline coleccionOnline = new ColeccionOnline();
            coleccionOnline.ImprimeLista(TipoPlataforma.Humble);
            Console.WriteLine();
            coleccionOnline.ImprimeLista(TipoPlataforma.Epic);
            Console.WriteLine();
            Console.WriteLine(coleccionOnline);
            Console.WriteLine(coleccionOnline[17]);
        }
    }
}
