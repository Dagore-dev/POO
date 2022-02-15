using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaRelacion2AlumnoGrupo
{
    class Grupo
    {
        /*ATRIBUTOS*/
        private List<Alumno> listaAlumnos = new List<Alumno>();

        /*MÉTODOS*/
        /// <summary>
        /// Añade un alumno al final de la lista.
        /// </summary>
        /// <param name="alumno">Objeto de tipo Alumno.</param>
        public void InsertaAlumnoLista (Alumno alumno)
        {
            listaAlumnos.Add(alumno);
        }
        /// <summary>
        /// Crea un alumno y lo añade al final de la lista.
        /// </summary>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="edad">Edad del alumno, entre 17 y 100.</param>
        /// <param name="calificacion">Calificación del alumno, entre 1 y 10.</param>
        public void InsertaAlumnoLista (string nombre, int edad, double calificacion)
        {
            listaAlumnos.Add(new Alumno(nombre, edad, calificacion));
        }
        /// <summary>
        /// Escribe la lista en el fichero binario indica.
        /// </summary>
        /// <param name="path">Ruta del fichero.</param>
        public void EscribeFicheroBinario (string path)
        {

        }

        /*OVERRIDE*/
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < listaAlumnos.Count; i++)
            {
                sb.AppendLine(listaAlumnos[i].ToString());
            }

            return sb.ToString();
        }
    }
}
