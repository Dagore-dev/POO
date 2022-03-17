using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntregaProfesorTribunal
{
    class Tribunal
    {
        private List<Profesor> listaProfesores = new List<Profesor>();

        public Tribunal (string path)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                string nombre, dni;
                int genero;
                Profesor profesor;

                while (fs.Position < fs.Length)
                {
                    nombre = br.ReadString();
                    dni = br.ReadString();
                    genero = br.ReadInt32();

                    profesor = new Profesor(nombre, dni, (TipoGenero)genero);

                    listaProfesores.Add(profesor);
                }

                br.Close();
                fs.Close();
            }
            else
            {
                throw new Exception("No se ha encontrado el fichero");
            }
        }

        public void EligeTribunal ()
        {
            Random rand = new Random();
            Profesor profesor;
            int r = rand.Next(listaProfesores.Count), hombres = 0, mujeres = 0;

            Console.WriteLine("Vocales elegidos para el sorteo: ");

            if (GetNumberMen() < 2 || GetNumberWomen() < 2)
            {
                while (hombres < 2 || mujeres < 2)
                {
                    profesor = listaProfesores[r];

                    if (profesor.Genero == TipoGenero.Hombre && hombres < 2)
                    {
                        Console.WriteLine(profesor);
                        hombres++;
                    }

                    if (profesor.Genero == TipoGenero.Mujer && mujeres < 2)
                    {
                        Console.WriteLine(profesor);
                        mujeres++;
                    }

                    r++;

                    if (r == listaProfesores.Count)
                    {
                        r = 0;
                    }
                }
            }
            else
            {
                throw new Exception("No se puede montar un tribunal paritario.");
            }
            

        }

        private int GetNumberWomen()
        {
            Profesor profesor;
            int women = 0;

            for (int i = 0; i < listaProfesores.Count; i++)
            {
                profesor = listaProfesores[i];

                if (profesor.Genero == TipoGenero.Mujer)
                {
                    women++;
                }
            }

            return women;
        }

        private int GetNumberMen()
        {
            Profesor profesor;
            int men = 0;

            for (int i = 0; i < listaProfesores.Count; i++)
            {
                profesor = listaProfesores[i];

                if (profesor.Genero == TipoGenero.Hombre)
                {
                    men++;
                }
            }

            return men;
        }

        public void EligeTribunalPro ()
        {
            listaProfesores.Sort();
            EligeTribunal();
        }
    }
}
