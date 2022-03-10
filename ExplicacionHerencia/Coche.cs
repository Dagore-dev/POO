using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionHerencia
{
    class Coche : Vehiculo
    {
        private int numeroPuertas;

        public Coche(string matricula, string marca, string modelo, int numeroPuertas) : base(matricula, marca, modelo)
        {
            this.numeroPuertas = numeroPuertas;
        }
        public Coche(string matricula, string marca, string modelo, int numeroKilometros, int numeroPuertas) : base(matricula, marca, modelo, numeroKilometros)
        {
            this.numeroPuertas = numeroPuertas;
        }
        //Este override es muy arcaico porque estamos haciendo a mano el del vehículo.
        public override string ToString()
        {
            return $"Matrícula {matricula} \n Marca y modelo: {marca} {modelo} \n Kilometros: {kilometros} \n Número de puertas {numeroPuertas}";
        }
        //Hacer el override del método no implementado en la clase abstracta vehículo.
        public override void CambiaMatricula(string matricula)
        {
            throw new NotImplementedException();
        }
    }
}
