using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VideojuegosDB
{
    class Coleccion
    {
        /*ATRIBUTOS*/
        List<Videojuego> lista = new List<Videojuego>();
        
        /*PROPIEDADES*/
        /// <summary>
        /// Número de videojuegos en la colección.
        /// </summary>
        public int NumeroVideojuegos
        {
            get
            {
                return lista.Count;
            }
        }
        
        /*MÉTODOS*/
        
        /*MANIPULACIÓN DE LA LISTA*/
        /// <summary>
        /// Inserta un objeto Videojuego en la colección.
        /// </summary>
        /// <param name="v">Instancia de videojuego.</param>
        public void InsertaVideojuego(Videojuego v)
        {
            lista.Add(v);
        }
        /// <summary>
        /// Elimina un videojuego de la colección usando su posición.
        /// </summary>
        /// <param name="position">Posición en la lista del videojuego que se quiere eliminar.</param>
        public void EliminaVideojuego(int position)
        {
            if (position >= 0 && position < NumeroVideojuegos)
            {
                lista.RemoveAt(position);
            }
            else
            {
                throw new Exception("Esa posición no existe en la colección.");
            }
        }
        /// <summary>
        /// Obtiene un videojuego de la lista a través de su posición.
        /// </summary>
        /// <param name="position">Posición en la lista para el videojuego.</param>
        /// <returns>Instancia de Videjuego</returns>
        public Videojuego LeeVideojuego(int position)
        {
            if (position >= 0 && position < NumeroVideojuegos)
            {
                return lista[position];
            }
            else
            {
                throw new Exception("Esa posición no existe en la colección.");
            }
        }
       
        /*GESTIÓN DE FICHEROS*/
        /// <summary>
        /// Vuelca la lista en un fichero de texto, machacándolo.
        /// </summary>
        /// <param name="path"></param>
        public void GuardaColeccionFichero(string path)
        {
            Videojuego videojuego;
            StreamWriter sw = new StreamWriter(path);

            for (int i = 0; i < NumeroVideojuegos; i++)
            {
                videojuego = lista[i];
                sw.WriteLine(videojuego.ToCSVString());
            }

            sw.Close();
        }
        /// <summary>
        /// Obtiene la lista de videojuegos de un fichero.
        /// </summary>
        /// <param name="path">Ruta del fichero.</param>
        public void LeeColeccionFichero(string path)
        {
            Videojuego videojuego;
            StreamReader sr;
            Plataforma plataforma;
            TipoJuego genero;
            string nombre;
            int anno, valoracion;
            string[] record;

            sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                record = sr.ReadLine().Split(';');

                nombre = record[0];
                anno = int.Parse(record[1]);
                plataforma = (Plataforma)int.Parse(record[2]);
                genero = (TipoJuego)int.Parse(record[3]);
                valoracion = int.Parse(record[4]);

                videojuego = new Videojuego(nombre, anno, plataforma, genero, valoracion);
                lista.Add(videojuego);
            }

            sr.Close();
        }

        /*OVERRRIDE*/
        public override string ToString()
        {
            int tableWidth = 115;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(NewLine(tableWidth));
            sb.AppendLine(NewRow(tableWidth, "Videojuego", "Año", "Plataforma", "Tipo de juego", "Val."));
            
            for (int i = 0; i < NumeroVideojuegos; i++)
            {
                sb.AppendLine(NewLine(tableWidth));
                sb.AppendLine(NewRow(tableWidth, lista[i].ToString().Split(';')));
            }

            return sb.ToString();
        }

        /*REPRESENTACIONES*/
        /// <summary>
        /// Escribe una lista ordenada de los videojuegos en la lista.
        /// </summary>
        /// <returns>Un string con cada videojuego en una línea y una viñeta numérica.</returns>
        public string ToStringNum()
        {
            StringBuilder sb = new StringBuilder();
            int mark = 1;

            for (int i = 0; i < NumeroVideojuegos; i++)
            {
                sb.AppendLine($"{mark}- {lista[i].Nombre}");
                mark++;
            }

            return sb.ToString();
        }

        /*HELPERS*/
        /// <summary>
        /// Genera una nueva linea separadora del ancho especificada.
        /// </summary>
        /// <param name="tableWidth">Un entero que indica el número de caracteres del separador.</param>
        /// <returns>String con el separador generado</returns>
        private string NewLine(int tableWidth)
        {
            return new string('-', tableWidth);
        }
        /// <summary>
        /// Genera una nueva fila de la tabla con un ancho especificado y tantas columnas como argurmentos.
        /// </summary>
        /// <param name="tableWidth">Un entero que indica el ancho de la fila.</param>
        /// <param name="columns">Una serie de strings, cada uno se sitúa centrado en una columna de la fila</param>
        /// <returns>Un string con la nueva línea generada.</returns>
        private string NewRow(int tableWidth, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            StringBuilder row = new StringBuilder("|");

            foreach (string column in columns)
            {
                row.Append(AlignCentre(column, width)).Append("|");
            }

            return row.ToString();
        }
        /// <summary>
        /// Centra una cadena de texto con espacios a los lados para un ancho especifico.
        /// </summary>
        /// <param name="text">Un string con el texto que se quiere centrar.</param>
        /// <param name="width">Ancho de referencia para centrar el texto</param>
        /// <returns>Un string con el nuevo texto centrado.</returns>
        private string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

    }
}