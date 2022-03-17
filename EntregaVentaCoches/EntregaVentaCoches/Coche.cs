using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EntregaVentaCoches
{
    class Coche
    {
        private string matricula;
        private DateTime fechaMatriculación;
        private string marca;
        private string modelo;
        private double precio;

        public Coche (string matricula, string marca, string modelo, DateTime fechaMatriculacion, double precio)
        {
            this.matricula = TrySetMatricula(matricula);
            this.fechaMatriculación = fechaMatriculacion;
            this.marca = TrySetNotEmpty(marca);
            this.modelo = TrySetNotEmpty(modelo);
            Precio = precio;
        }

        public string Matricula { get => matricula; }
        public DateTime FechaMatriculación { get => fechaMatriculación; }
        public string Marca { get => marca; }
        public string Modelo { get => modelo; }
        public double Precio 
        { 
            get => precio; 
            set
            {
                if (value >= 500)
                {
                    precio = value;
                }
                else
                {
                    throw new Exception("El precio debe ser de al menos 500 euros.");
                }
            }
        }

        private string TrySetMatricula(string matricula)
        {
            string pattern = "^\\d{4}[A-Z]{3}$";
            Regex regex = new Regex(pattern);

            if (!regex.Match(matricula).Success)
            {
                throw new Exception("La matricula no tiene el formato adecuado: 1111AAA.");
            }

            return matricula;
        }
        private string TrySetNotEmpty(string s)
        {
            return s.Length != 0 ? s : throw new Exception("El valor no puede ser una cadena vacía.");
        }
        private string Representation ()
        {
            return $"{Matricula}\n{FechaMatriculación.ToString("dd/MM/yyyy")}\n{Marca}\n{Modelo}\n{Precio}";
        }
        public string FormatIntoCSV ()
        {
            return $"{Matricula};{Marca};{Modelo};{FechaMatriculación.ToString("dd/MM/yyyy")};{Precio}";
        }
        public override string ToString()
        {
            return Representation();
        }
    }
}
