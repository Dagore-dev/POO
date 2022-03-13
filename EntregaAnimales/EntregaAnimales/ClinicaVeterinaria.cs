using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntregaAnimales
{
    class ClinicaVeterinaria
    {
        private List<Animal> listaAnimales;

        public ClinicaVeterinaria ()
        {
            listaAnimales = new List<Animal> ();
        }

        public void InsertaAnimal (Animal animal)
        {
            listaAnimales.Add (animal);
        }
        public Animal BuscaAnimal (string name)
        {
            Animal animal = null;

            for (int i = 0; i < listaAnimales.Count; i++)
            {
                animal = listaAnimales[i];
                if (animal.Nombre == name)
                {
                    i = listaAnimales.Count;
                }
            }

            if (animal != null)
            {
                return animal;
            }
            else
            {
                throw new Exception("Ningún animal en la clínica recibe tiene nombre");
            }
        }
        public void ModificaComentarioAnimal (string name, string comment)
        {
            Animal animal = BuscaAnimal(name);

            animal.Comentarios = comment;
        }
        public void FromCSV (string path)
        {
            StreamReader sr = new StreamReader (path);
            Animal animal;
            int count = int.Parse(sr.ReadLine());
            string[] record;

            for (int i = 0; i < count; i++)
            {
                record = sr.ReadLine().Split(',');

                //Thinking in a solution like this
                switch (record[0])
                {
                    case "EntregaAnimales.Gato":

                        break;
                    case "EntregaAnimales.Perro":

                        break;
                    case "EntregaAnimales.Pajaro":

                        break;
                    case "EntregaAnimales.Reptil":

                        break;
                    default:
                        break;
                }
                //Create instance of the properly subtype of Animal and add to the list.
            }

            sr.Close();
        }
        public void ToCSV (string path)
        {
            StreamWriter sw = new StreamWriter(path);
            Animal animal;

            sw.WriteLine(listaAnimales.Count);
            
            for (int i = 0; i < listaAnimales.Count; i++)
            {
                animal = listaAnimales[i];
                sw.WriteLine(animal.FormatIntoCSV());
            }

            sw.Close();
        }
        private string ListAnimals ()
        {
            StringBuilder sb = new StringBuilder ();
            Animal animal;

            for (int i = 0; i < listaAnimales.Count; i++)
            {
                animal = listaAnimales[i];
                sb.AppendLine(animal.ToString ());
                sb.AppendLine ();
            }

            return sb.ToString ();
        }
        
        public override string ToString ()
        {
            return ListAnimals ();
        }
    }
}
