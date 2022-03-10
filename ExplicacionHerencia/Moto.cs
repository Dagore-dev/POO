using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionHerencia
{
    class Moto : Vehiculo
    {
        private bool tieneSidecar;

        public Moto(string matricula, string marca, string modelo, bool tieneSidecar) : base(matricula, marca, modelo)
        {
            this.tieneSidecar = tieneSidecar;
        }
        public Moto(string matricula, string marca, string modelo, int numeroKilometros, bool tieneSidecar) : base(matricula, marca, modelo, numeroKilometros)
        {
            this.tieneSidecar = tieneSidecar;
        }
        public override string ToString()
        {
            return $"{base.ToString()} Tiene sidecar: {(tieneSidecar ? "Sí" : "No")}";
        }
        //Hacer el override del método no implementado en la clase abstracta vehículo.
        public override void CambiaMatricula(string matricula)
        {
            throw new NotImplementedException();
        }
    }
}
