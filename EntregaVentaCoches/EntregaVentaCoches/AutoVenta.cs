using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace EntregaVentaCoches
{
    class AutoVenta
    {
        private List<Coche> listaCoches;

        public AutoVenta ()
        {
            listaCoches = new List<Coche> ();
        }

        public void CargaCSV (string path)
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                List<Coche> temp = new List<Coche> ();
                string[] record;
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    record = sr.ReadLine().Split(';');
                    temp.Add(new Coche(record[0], record[1], record[2], DateTime.Parse(record[3]), double.Parse(record[4])));
                }

                listaCoches.AddRange(temp);

                sr.Close();
            }
            else
            {
                throw new Exception("No existe el fichero de respaldo.");
            }
        }
        public void GuardaCSV (string path)
        {
            StreamWriter sr = new StreamWriter(path);

            sr.WriteLine($"{"Matrícula"};{"Marca"};{"Modelo"};{"fechaMatriculación"};{"Precio"}");

            for (int i = 0; i < listaCoches.Count; i++)
            {
                sr.WriteLine(listaCoches[i].FormatIntoCSV());
            }

            sr.Close();
        }
        public void InsertaCoche (Coche c)
        {
            listaCoches.Add(c);
        }
        public Coche BuscaCoche (string matricula)
        {
            for (int i = 0; i < listaCoches.Count; i++)
            {
                if (listaCoches[i].Matricula == matricula)
                {
                    return listaCoches[i];
                }
            }

            throw new Exception("No existe un coche con esa matrícula en nuestra base de datos.");
        }
        public string ImprimeListado ()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{"Matrícula".PadRight(16)}{"Marca".PadRight(16)}{"Modelo".PadRight(16)}{"Fecha Matr.".PadRight(16)}{"Precio".PadRight(16)}");

            for (int i = 0; i < listaCoches.Count; i++)
            {
                sb.AppendLine(ImprimeFila(listaCoches[i].FormatIntoCSV()));
            }

            return sb.ToString();
        }
        private string ImprimeFila (string s)
        {
            string[] record = s.Split(';');

            return $"{record[0].PadRight(16)}{record[1].PadRight(16)}{record[2].PadRight(16)}{record[3].PadRight(16)}{record[4].PadRight(16)}";
        }
    }
}
