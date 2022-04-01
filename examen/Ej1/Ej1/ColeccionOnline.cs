using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Ej1
{
    class ColeccionOnline
    {
        private List<Videojuego> listaVideojuegos;

        public ColeccionOnline()
        {
            listaVideojuegos = new List<Videojuego>();
            string currentDirectory = Directory.GetCurrentDirectory();
            List<string> allFiles = new List<string>(Directory.GetFiles(currentDirectory));
            List<string> txtFiles = allFiles.FindAll(path => path.EndsWith(".txt"));

            foreach (string path in txtFiles)
            {
                listaVideojuegos.Add(LeeVideojuego(path));
            }
        }

        public Videojuego this[int index]
        {
            get
            {
                return listaVideojuegos[index];
            }
        }

        private Videojuego LeeVideojuego(string path)
        {
            if (File.Exists(path))
            {
                string name, platform, yesOrNo;
                int year;
                string[] firstLine, platformLine;;
                List<TipoPlataforma> l = new List<TipoPlataforma>();
                StreamReader sr = new StreamReader(path);

                //Se obtiene el nombre y el año de la primera línea del fichero.
                firstLine = sr.ReadLine().Split('(');
                name = firstLine[0];
                year = int.Parse(firstLine[1].Substring(0, 4));

                //Se agrega a la lista la plataforma que corresponde si su valor está fijado a Yes.
                while (!sr.EndOfStream)
                {
                    platformLine = sr.ReadLine().Split(' ');
                    platform = platformLine[0].Substring(0, platformLine[0].Length - 1);
                    yesOrNo = platformLine[1];

                    if (yesOrNo == "Yes")
                    {
                        l.Add((TipoPlataforma) Enum.Parse(typeof(TipoPlataforma), platform));
                    }

                }

                sr.Close();
                return new Videojuego(name, l, year);
            }
            else
            {
                throw new Exception($"No existe el archivo {path}");
            }
        }

        public void ImprimeLista(TipoPlataforma tp)
        {
            foreach (Videojuego videojuego in listaVideojuegos)
            {
                if (videojuego.Plataformas.Contains(tp))
                {
                    Console.WriteLine(videojuego);
                }
            }
        }

        private string Representation ()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Videojuego item in listaVideojuegos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        public override string ToString()
        {
            return Representation();
        }
    }
}
