using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntregaRelacion2AlumnoGrupo
{
    class Grupo
    {
        /*ATRIBUTOS*/
        private List<Alumno> listaAlumnos = new List<Alumno>();

        /*PROPIEDADES*/
        public int NumeroAlumnos
        {
            get
            {
                return listaAlumnos.Count;
            }
        }

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
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            Alumno alumno;

            bw.Write(NumeroAlumnos);

            for (int i = 0; i < NumeroAlumnos; i++)
            {
                alumno = listaAlumnos[i];

                bw.Write(alumno.Nombre);
                bw.Write(alumno.Edad);
                bw.Write(alumno.Calificacion);
            }

            bw.Close();
            fs.Close();
        }
        /// <summary>
        /// Limpia la lista y la rellena desde el fichero binario indicado
        /// </summary>
        /// <param name="path">Ruta del fichero</param>
        public void LeeFicheroBinario (string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            Alumno alumno;
            int length = br.ReadInt32();
            listaAlumnos.Clear();

            for (int i = 0; i < length; i++)
            {
                alumno = new Alumno(br.ReadString(), br.ReadInt32(), br.ReadDouble());

                listaAlumnos.Add(alumno);
            }

            br.Close();
            fs.Close();
        }
        /// <summary>
        /// Escribe la lista en el fichero de texto indicado.
        /// </summary>
        /// <param name="path">Ruta del fichero</param>
        public void EscribeFicheroTexto (string path)
        {
            StreamWriter sw = new StreamWriter(path);
            Alumno alumno;

            sw.WriteLine(NumeroAlumnos);

            for (int i = 0; i < NumeroAlumnos; i++)
            {
                alumno = listaAlumnos[i];

                sw.WriteLine(alumno.Nombre);
                sw.WriteLine(alumno.Edad);
                sw.WriteLine(alumno.Calificacion);
            }

            sw.Close();
        }
        /// <summary>
        /// Limpia la lista y la rellena desde el fichero de texto indicado.
        /// </summary>
        /// <param name="path">Ruta del fichero</param>
        public void LeeFicheroTexto (string path)
        {
            StreamReader sr = new StreamReader(path);
            Alumno alumno;
            int length = int.Parse(sr.ReadLine());

            for (int i = 0; i < length; i++)
            {
                alumno = new Alumno(sr.ReadLine(), int.Parse(sr.ReadLine()), double.Parse(sr.ReadLine()));

                listaAlumnos.Add(alumno);
            }

            sr.Close();
        }
        /// <summary>
        /// Escribe la lista en el fichero CSV indicado.
        /// </summary>
        /// <param name="path">Ruta del fichero.</param>
        public void EscribeFicheroCSV(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            Alumno alumno;

            for (int i = 0; i < NumeroAlumnos; i++)
            {
                alumno = listaAlumnos[i];

                sw.WriteLine($"{alumno.Nombre};{alumno.Edad};{alumno.Calificacion}");
            }

            sw.Close();
        }
        /// <summary>
        /// Limpia la lista y la rellena desde el fichero CSV indicado.
        /// </summary>
        /// <param name="path">Ruta del fichero.</param>
        public void LeeFicheroCSV (string path)
        {
            StreamReader sr = new StreamReader(path);
            Alumno alumno;
            string[] record;

            while (!sr.EndOfStream)
            {
                record = sr.ReadLine().Split(";");
                alumno = new Alumno(record[0], int.Parse(record[1]), double.Parse(record[2]));
                listaAlumnos.Add(alumno);
            }

            sr.Close();
        }
        public void ForEach (Action<Alumno> action)
        {
            for (int i = 0; i < NumeroAlumnos; i++)
            {
                action(listaAlumnos[i]);
            }
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
