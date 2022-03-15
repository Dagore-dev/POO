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
                int horas = value, horasActuales = SegundosTotales / 3600;

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
    }
}
