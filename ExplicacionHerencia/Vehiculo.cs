using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionHerencia
{
    abstract class Vehiculo
    {
        //Esta clase no se puede instanciar porque es abstracta 
        protected string matricula;
        protected string marca;
        protected string modelo;
        protected int kilometros;

        public Vehiculo(string matricula, string marca, string modelo)
        {
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            Kilometros = 0;
        }
        public Vehiculo(string matricula, string marca, string modelo, int kilometros) : this(matricula, marca, modelo)
        {
            Kilometros = kilometros;
        }

        public int Kilometros 
        { 
            get => kilometros; 
            set 
            {
                if (value >= 0)
                {
                    this.kilometros = value;
                }
                else
                {
                    throw new Exception("Nop");
                }
            } 
        }
        public override string ToString()
        {
            return $"Matrícula {matricula} \n Marca y modelo: {marca} {modelo} \n Kilometros: {kilometros} \n";
        }
        //Obligo a quienes hereden a crear un método con estas características.
        public abstract void CambiaMatricula(string matricula);
    }
}
