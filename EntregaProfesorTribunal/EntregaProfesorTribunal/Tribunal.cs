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
        public void EligeTribunalPro ()
        {
            listaProfesores.Sort();
            EligeTribunal();
        }
    }
}
