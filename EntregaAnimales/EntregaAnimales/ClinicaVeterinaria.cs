using System;
using System.Collections.Generic;
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
