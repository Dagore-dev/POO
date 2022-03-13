using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaAnimales
{
    enum RazaGato
    {
        Comun,
        Siames,
        Persa,
        Angora,
        ScottishFold
    }
    class Gato : Animal
    {
        private RazaGato raza;
        private string microchip;

        public Gato(string nombre, DateTime fechaNacimiento, double peso, RazaGato raza, string microchip) : base(nombre, fechaNacimiento, peso)
        {
            this.raza = raza;
            this.microchip = microchip;
        }

        public Gato(string nombre, DateTime fechaNacimiento, double peso, RazaGato raza, string microchip, string comentarios) : base(nombre, fechaNacimiento, peso, comentarios)
        {
            this.raza = raza;
            this.microchip = microchip;
        }

        public RazaGato Raza => raza;
        public string Microchip => microchip;
        public override string FormatIntoCSV ()
        {
            return $"{typeof(Gato)},{Nombre},{Raza},{FechaNacimiento},{Peso},{Microchip},{Comentarios}";
        }
        private string CatState()
        {
            return $"Ficha de gato\nNombre: {Nombre}\nRaza: {Raza}\nFecha de nacimiento: {FechaNacimiento:dd/MM/yyyy}\nPeso: {Peso} kg\nMicrochip: {Microchip}\nComentarios: {Comentarios}";
        }

        public override string ToString()
        {
            return CatState();
        }
    }
}