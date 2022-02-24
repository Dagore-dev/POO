using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionOperadores
{
    class Coordenada
    {
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Coordenada(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        //Operadores
        public static Coordenada operator + (Coordenada c1, Coordenada c2)
        {
            int x = c1.X + c2.X;
            int y = c1.Y + c2.Y;
            
            return new Coordenada(x, y);
        }
        //public static Coordenada operator + (Coordenada c1, int n)
        //{
        //    int x = c1.X + n;
        //    int y = c1.Y + n;

        //    return new Coordenada(x, y);
        //}
        //public static Coordenada operator + (int n, Coordenada c1)
        //{
        //    return c1 + n;
        //}
        
        //OPERADORES IMPLICITOS: Le decimos como transformar un tipo de dato en el nuestro, nos ahorra trabajo.
        public static implicit operator Coordenada(int n)
        {
            return new Coordenada(n, n);
        }
        public static Coordenada operator - (Coordenada c1)
        {
            return new Coordenada(-c1.X, -c1.Y);
        }
        public static bool operator == (Coordenada c1, Coordenada c2)
        {
            return c1.X == c2.X && c1.Y == c2.Y;
        }
        public static bool operator != (Coordenada c1, Coordenada c2)
        {
            return !(c1 == c2);
        }
    }
}
