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
                int horas = value, horasActuales = Horas;

                while (horas != horasActuales)
                {
                    if (horas < horasActuales)
                    {
                        SegundosTotales -= 3600;
                        horasActuales -= 1;
                    }
                    else
                    {
                        SegundosTotales += 3600;
                        horasActuales += 1;
                    }
                }
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
                    int minutos = value, minutosActuales = Minutos;

                    while (minutos != minutosActuales)
                    {
                        if (minutos < minutosActuales)
                        {
                            SegundosTotales -= 60;
                            minutosActuales -= 1;
                        }
                        else
                        {
                            SegundosTotales += 60;
                            minutosActuales += 1;
                        }
                    }
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
                    int segundos = value, segundosActuales = Segundos;

                    while (segundos != segundosActuales)
                    {
                        if (segundos < segundosActuales)
                        {
                            SegundosTotales -= 1;
                            segundosActuales -= 1;
                        }
                        else
                        {
                            SegundosTotales += 1;
                            segundosActuales += 1;
                        }
                    }
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
            return $"{Horas}:{Minutos}:{Segundos}";
        }
        public override string ToString()
        {
            return Representation();
        }
    }
}
