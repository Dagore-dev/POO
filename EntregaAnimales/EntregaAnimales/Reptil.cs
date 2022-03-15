using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaAnimales
{
    enum EspecieReptil
    {
        Tortuga,
        Iguana,
        DragonDeComodo
    }
    class Reptil : Animal
    {
        private EspecieReptil especie;
        private bool venenoso;

        public Reptil(string nombre, DateTime fechaNacimiento, double peso, EspecieReptil especie, bool venenoso) : base(nombre, fechaNacimiento, peso)
        {
            this.especie = especie;
            this.venenoso = venenoso;
        }

        public Reptil(string nombre, DateTime fechaNacimiento, double peso, EspecieReptil especie, bool venenoso, string comentarios) : base(nombre, fechaNacimiento, peso, comentarios)
        {
            this.especie = especie;
            this.venenoso = venenoso;
        }

        public EspecieReptil Especie => especie;
        public bool Venenoso => venenoso;

        private string ReptileState()
        {
            return $"Ficha de reptil\nNombre: {Nombre}\nEspecie: {Especie}\nFecha de nacimiento: {FechaNacimiento:dd/MM/yyyy}\nPeso: {Peso} kg\nVenenoso: {(Venenoso ? "Sí" : "No")}\nComentarios: {Comentarios}";
        }
        public override string FormatIntoCSV()
        {
            return $"{typeof(Reptil)},{Nombre},{FechaNacimiento},{Peso},{Especie},{Venenoso},{Comentarios},";
        }

        public override string ToString()
        {
            return ReptileState();
        }
    }
}
