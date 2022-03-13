using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaAnimales
{
    enum EspeciePajaro
    {
        Canario,
        Periquito,
        Agapornis
    }
    class Pajaro : Animal
    {
        private EspeciePajaro especie;
        private bool cantor;

        public Pajaro(string nombre, DateTime fechaNacimiento, double peso, EspeciePajaro especie, bool cantor) : base(nombre, fechaNacimiento, peso)
        {
            this.especie = especie;
            this.cantor = cantor;
        }

        public Pajaro(string nombre, DateTime fechaNacimiento, double peso, EspeciePajaro especie, bool cantor, string comentarios) : base(nombre, fechaNacimiento, peso, comentarios)
        {
            this.especie = especie;
            this.cantor= cantor;
        }

        public EspeciePajaro Especie => especie;
        public bool Cantor => cantor;
        public override string FormatIntoCSV()
        {
            return $"{typeof(Pajaro)},{Nombre},{Especie},{FechaNacimiento},{Peso},{Cantor},{Comentarios}";
        }
        private string BirdState()
        {
            return $"Ficha de pájaro\nNombre: {Nombre}\nEspecie: {Especie}\nCantor: {(Cantor ? "Sí" : "No")}\nFecha de nacimiento: {FechaNacimiento:dd/MM/yyyy}\nPeso: {Peso} kg\nComentarios: {Comentarios}";
        }

        public override string ToString()
        {
            return BirdState();
        }
    }
}
