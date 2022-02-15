using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaRelacion2AlumnoGrupo
{
    class Alumno
    {
        /*ATRIBUTOS*/
        private string _nombre;
        private int _edad;
        private double _calificacion;

        /*CONTRUCTOR*/
        /// <summary>
        /// Crea un nuevo alumno recibiendo su nombre, edad y calificación.
        /// </summary>
        /// <param name="nombre">Nombre, un string que no puede estar vacío.</param>
        /// <param name="edad">Edad, un entero entre 17 y 100.</param>
        /// <param name="calificacion">Calificación, un double entre 1 y 10.</param>
        public Alumno (string nombre, int edad, double calificacion)
        {
            Nombre = nombre;
            Edad = edad;
            Calificacion = calificacion;
        }

        /*PROPIEDADES*/
        /// <summary>
        /// Nombre del alumno, string que no puede estar en blanco.
        /// </summary>
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                if (value != "")
                {
                    _nombre = value;
                }
                else
                {
                    throw new Exception("El nombre no puede estar en blanco.");
                }
            }
        }
        /// <summary>
        /// Edad del alumno, entero entre 17 y 100.
        /// </summary>
        public int Edad
        {
            get
            {
                return _edad;
            }
            set
            {
                if (value >= 17 && value <= 100)
                {
                    _edad = value;
                }
                else
                {
                    throw new Exception("La edad debe estar entre 17 y 100.");
                }
            }
        }
        /// <summary>
        /// Calificación del alumno, double entre 1 y 10.
        /// </summary>
        public double Calificacion
        {
            get
            {
                return _calificacion;
            }
            set
            {
                if (value >= 1 && value <= 10)
                {
                    _calificacion = value;
                }
                else
                {
                    throw new Exception("La calificación debe estar entre 1 y 10.");
                }
            }
        }

        /*OVERRIDE*/
        public override string ToString()
        {
            return $"{Nombre};{Edad};{Calificacion}";
        }

    }
}
