using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaAnimales
{
    abstract class Animal
    {
        private string nombre;
        private DateTime fechaNacimiento;
        private double peso;
        private string comentarios;

        public Animal(string nombre, DateTime fechaNacimiento, double peso)
        {
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.peso = peso;
            this.comentarios = "";
        }
        public Animal(string nombre, DateTime fechaNacimiento, double peso, string comentarios) : this(nombre, fechaNacimiento, peso)
        {
            this.comentarios = comentarios;
        }

        public string Nombre { get => nombre; }
        public DateTime FechaNacimiento { get => fechaNacimiento; }
        public double Peso { get => peso; set => peso = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }

        public abstract override string ToString();
    }
}
