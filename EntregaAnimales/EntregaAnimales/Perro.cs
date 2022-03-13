using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaAnimales
{
    public enum RazaPerro
    {
        PastorAleman,
        Husky,
        FoxTerrier,
        Dalmata,
        SanBernardo
    }
    class Perro : Animal
    {
        private RazaPerro raza;
        private string microchip;

        public Perro(string nombre, DateTime fechaNacimiento, double peso, RazaPerro raza, string microchip) : base(nombre, fechaNacimiento, peso)
        {
            this.raza = raza;
            this.microchip = microchip;
        }

        public Perro(string nombre, DateTime fechaNacimiento, double peso, RazaPerro raza, string microchip, string comentarios) : base(nombre, fechaNacimiento, peso, comentarios)
        {
            this.raza = raza;
            this.microchip = microchip;
        }

        public RazaPerro Raza => raza;
        public string Microchip => microchip;
        private string DogState ()
        {
            return $"Ficha de perro\nNombre: {Nombre}\nRaza: {Raza}\nFecha de nacimiento: {FechaNacimiento:dd/MM/yyyy}\nPeso: {Peso} kg\nMicrochip: {Microchip}\nComentarios: {Comentarios}";
        }

        public override string ToString()
        {
            return DogState();
        }
    }
}
