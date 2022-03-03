using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaFracciones
{
    class Fraccion
    {
        //ATTRIBUTES
        private int numerador;
        private int denominador;

        //CONSTRUCTORS
        public Fraccion(int numerador, int denominador)
        {
            if (denominador > 0)
            {
                Numerador = numerador;
                Denominador = denominador;
            }
            else
            {
                Numerador = -numerador;
                Denominador = -denominador;
            }
        }
        public Fraccion(int n)
        {
            Numerador = n;
            Denominador = 1;
        }
        public Fraccion(double d)
        {
            int i = 1;

            while (Math.Truncate(d) != d)
            {
                d *= 10;
                i *= 10;
            }

            Numerador = (int)d;
            Denominador = i;
        }

        //PROPERTIES
        public int Numerador { get => numerador; set => numerador = value; }
        public int Denominador { get => denominador; set => denominador = value != 0 ? value : throw new Exception("\"Denominador no puede ser igual a 0"); }

        //METHODS
        private static int MCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            return MCD(b % a, a);
        }
        private static int Mcm(int a, int b)
        {
            return (a * b) / MCD(a, b);
        }
        public Fraccion Simplificar()
        {
            int Mcd = MCD(Numerador, Denominador);

            Fraccion f = new Fraccion(Numerador / Mcd, Denominador / Mcd);

            Numerador = f.Numerador;
            Denominador = f.Denominador;

            return f;
        }

        //OPERATORS
        public static Fraccion operator -(Fraccion f)
        {
            return new Fraccion(-f.Numerador, f.Denominador);
        }
        public static Fraccion operator +(Fraccion f1, Fraccion f2)
        {
            Fraccion f, f1S, f2S;
            int mcm, a, b;

            if (f1.Denominador == f2.Denominador)
            {
                f = new Fraccion(f1.Numerador + f2.Numerador, f1.Denominador);
            }
            else
            {
                f1S = f1.Simplificar();
                f2S = f2.Simplificar();
                mcm = Mcm(f1S.Denominador, f2S.Denominador);
                f1S = new Fraccion((f1S.Numerador * mcm) / f1S.Denominador, mcm);
                f2S = new Fraccion((f2S.Numerador * mcm) / f2S.Denominador, mcm);

                f = f1S + f2S;
            }

            return f;
        }
        public static Fraccion operator -(Fraccion f1, Fraccion f2)
        {
            return f1 + (-f2);
        }
        public static Fraccion operator *(Fraccion f1, Fraccion f2)
        {
            int a = f1.Numerador * f2.Numerador;
            int b = f1.Denominador * f2.Denominador;

            return new Fraccion(a, b).Simplificar();
        }
        public static Fraccion operator /(Fraccion f1, Fraccion f2)
        {
            int a = f1.Numerador * f2.Denominador;
            int b = f1.Denominador * f2.Numerador;

            return new Fraccion(a, b).Simplificar();
        }
        public static bool operator ==(Fraccion f1, Fraccion f2)
        {
            return f1.Numerador * f2.Denominador == f2.Numerador * f1.Denominador;
        }
        public static bool operator !=(Fraccion f1, Fraccion f2)
        {
            return !(f1 == f2);
        }
        public static bool operator <(Fraccion f1, Fraccion f2)
        {
            Fraccion f1S = f1.Simplificar();
            Fraccion f2S = f2.Simplificar();
            bool isLessThan;
            int mcm;

            if (f1S == f2S)
            {
                isLessThan = false;
            }
            else
            {
                if (f1S.Denominador == f2S.Denominador)
                {
                    isLessThan = f1S.Numerador < f2S.Numerador;
                }
                else
                {
                    mcm = Mcm(f1S.Denominador, f2S.Denominador);
                    f1S = new Fraccion((f1S.Numerador * mcm) / f1S.Denominador, mcm);
                    f2S = new Fraccion((f2S.Numerador * mcm) / f2S.Denominador, mcm);

                    isLessThan = f1S.Numerador < f2S.Numerador;
                }
            }

            return isLessThan;
        }
        public static bool operator >(Fraccion f1, Fraccion f2)
        {
            Fraccion f1S = f1.Simplificar();
            Fraccion f2S = f2.Simplificar();
            bool isGreaterThan;
            int mcm;

            if (f1S == f2S)
            {
                isGreaterThan = false;
            }
            else
            {
                if (f1S.Denominador == f2S.Denominador)
                {
                    isGreaterThan = f1S.Numerador > f2S.Numerador;
                }
                else
                {
                    mcm = Mcm(f1S.Denominador, f2S.Denominador);
                    f1S = new Fraccion((f1S.Numerador * mcm) / f1S.Denominador, mcm);
                    f2S = new Fraccion((f2S.Numerador * mcm) / f2S.Denominador, mcm);

                    isGreaterThan = f1S.Numerador > f2S.Numerador;
                }
            }

            return isGreaterThan;
        }
        public static bool operator <=(Fraccion f1, Fraccion f2)
        {
            bool lessOrEqual;

            if (f1 == f2)
            {
                lessOrEqual = true;
            }
            else
            {
                lessOrEqual = f1 < f2;
            }

            return lessOrEqual;
        }
        public static bool operator >=(Fraccion f1, Fraccion f2)
        {
            bool greaterOrEqual;

            if (f1 == f2)
            {
                greaterOrEqual = true;
            }
            else
            {
                greaterOrEqual = f1 > f2;
            }

            return greaterOrEqual;
        }
        public static implicit operator Fraccion (int n)
        {
            return new Fraccion(n);
        }
        public static implicit operator Fraccion (double d)
        {
            return new Fraccion(d);
        }

        //OVERRIDES
        public override string ToString()
        {
            return $"{Numerador}/{Denominador}";
        }
    }
}
