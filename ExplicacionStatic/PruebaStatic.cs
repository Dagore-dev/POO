using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionStatic
{
    class PruebaStatic
    {
        public static string compartida;
        public static string rootDirectory;
        static PruebaStatic ()//No tiene parámetros y se llama él solo, no los ejecutamos nosotros.
        {
            compartida = "una";
            rootDirectory = AppContext.BaseDirectory;
        }
        public void CambiaCompartida (string s)
        {
            lock (compartida)
            {
                compartida += s;
            }
        }
        public static int MCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            return MCD(b % a, a);
        }
    }
}
