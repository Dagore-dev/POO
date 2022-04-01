using System;
using System.Collections.Generic;
using System.Text;

namespace Ej3
{
    class Pixel
    {
        //Atributos
        private int x;
        private int y;
        //Propiedades
        public int X
        {
            get { return x; }
            set 
            {
                if (value >= 0 && value <= 9)
                {
                    x = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value >= 0 && value <= 9)
                {
                    y = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        //Constructor
        public Pixel (int x, int y)
        {
            X = x;
            Y = y;
        }
        //ToString
        private string Representation ()
        {
            return $"[{X} {Y}]";
        }
        public override string ToString()
        {
            return Representation(); 
        }
    }
}
