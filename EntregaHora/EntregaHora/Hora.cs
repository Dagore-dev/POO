using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaHora
{
    class Hora
    {
        private int segundos;

        public Hora(int segundos)
        {
            SegundosTotales = segundos;
        }
        public Hora(int horas, int minutos, int segundos)
        {
            Horas = horas;
            Minutos = minutos;
            Segundos = segundos;
        }

        public int SegundosTotales
        {
            get { return segundos; }
            set
            {
                if (value >= 0)
                {
                    segundos = value;
                }
                else
                {
                    throw new Exception("Los segundos deben ser un entero positivo o cero.");
                }
            }
        }
        public int Horas
        {
            get
            {
                return SegundosTotales / 3600;
            }
            set
            {
                SegundosTotales = value * 3600 + Minutos * 60 + Segundos; 
            }
        }
        public int Minutos
        {
            get
            {
                return (SegundosTotales / 60) - Horas * 60;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    SegundosTotales = Horas * 3600 + value * 60 + Segundos;
                }
                else
                {
                    throw new Exception("Los minutos deben estar comprendidos entre 0 y 59.");
                }
            }
        }
        public int Segundos
        {
            get
            {
                return SegundosTotales - Horas * 3600 - Minutos * 60;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    SegundosTotales = Horas * 3600 + Minutos * 60 + value;
                }
                else
                {
                    throw new Exception("Los segundos deben estar comprendidos entre 0 y 59.");
                }
            }
        }

        public void SumaHoras (int horas)
        {
            Horas += horas;
        }
        public void SumaMinutos (int minutos)
        {
            SegundosTotales += minutos * 60;
        }
        public void SumaSegundos (int segundos)
        {
            SegundosTotales += segundos;
        }

        public static Hora operator + (Hora h1, Hora h2)
        {
            return new Hora(h1.SegundosTotales + h2.SegundosTotales);
        }
        public static Hora operator - (Hora h1, Hora h2)
        {
            if (h1.SegundosTotales >= h2.SegundosTotales)
            {
                return new Hora(h1.SegundosTotales - h2.SegundosTotales);
            }
            else 
            {
                throw new Exception("No se pueden guardar horas negativas-");
            }
        }

        private string Representation ()
        {
            return $"{Horas.ToString().PadLeft(2, '0')}:{Minutos.ToString().PadLeft(2, '0')}:{Segundos.ToString().PadLeft(2, '0')}";
        }
        public override string ToString()
        {
            return Representation();
        }
    }
}
