using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaAnimales
{
    class Perro : Animal
    {
        public Perro(string nombre, DateTime fechaNacimiento, double peso) : base(nombre, fechaNacimiento, peso)
        {
        }

        public Perro(string nombre, DateTime fechaNacimiento, double peso, string comentarios) : base(nombre, fechaNacimiento, peso, comentarios)
        {
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
