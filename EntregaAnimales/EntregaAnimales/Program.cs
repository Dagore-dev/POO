using System;

namespace EntregaAnimales
{
    class Program
    {
        public static ClinicaVeterinaria clinicaVeterinaria = new ClinicaVeterinaria();
        static void Main(string[] args)
        {
            /*
            Perro perro = new Perro("Lucero", new DateTime(2015, 12, 25), 25, RazaPerro.Dalmata, "5489431564", "Todo correcto");
            Gato gato = new Gato("Karen", new DateTime(2020, 2, 28), 10, RazaGato.ScottishFold, "14896543241", "Uñas cortadas");
            Pajaro pajaro = new Pajaro("Rex", new DateTime(2020, 2, 28), 0.05, EspeciePajaro.Canario, true, "Uñas cortadas");
            Reptil reptil = new Reptil("Jordi", new DateTime(2020, 2, 28), 7.5, EspecieReptil.Tortuga, false, "Uñas cortadas");

            ClinicaVeterinaria cv = new ClinicaVeterinaria();

            cv.InsertaAnimal(perro);
            cv.InsertaAnimal(pajaro);
            cv.InsertaAnimal(reptil);
            cv.InsertaAnimal(gato);

            Console.WriteLine(cv);
             */
            int option;

            Console.WriteLine("Clínica Veterinaria");
            Console.WriteLine("Elija una opción:");
            Console.WriteLine(" 1 - Insertar animal");
            Console.WriteLine(" 2 - Modificar comentario");
            Console.WriteLine(" 3 - Mostrar animal");
            Console.WriteLine(" 4 - Mostrar todos los animales");
            Console.WriteLine("Pulse cualquier otra tecla para salir.");

            Console.Write("Su opción: ");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AnimalFromConsole();
                    break;
                case 2:
                    ModifyCommentFromConsole();
                    break;
                case 3:
                    DisplayAnimal();
                    break;
                case 4:
                    Console.WriteLine(clinicaVeterinaria);
                    break;
                default:
                    Console.WriteLine("¡Hasta la próxima!");
                    break;
            }
        }
        static void AnimalFromConsole ()
        {
            int option;

            Console.Write("¿Se trata de un perro (1), gato (2), pájaro (3), reptil (4) u otro (Cualquier otra tecla)?");
            option = int.Parse (Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateDog();
                    break;
                case 2:
                    CreateCat();
                    break;
                case 3:
                    CreateBird();
                    break;
                case 4:
                    CreateReptile();
                    break;
                default:
                    Console.WriteLine("Lo sentimos, no aceptamos ese tipo de animales.");
                    break;
            }
        }

        private static void CreateReptile ()
        {
            throw new NotImplementedException();
        }

        private static void CreateBird ()
        {
            throw new NotImplementedException();
        }

        private static void CreateCat ()
        {
            throw new NotImplementedException();
        }

        private static void CreateDog ()
        {
            string nombre, fechaNacimiento, raza, microchip;
            double peso;

            Console.Write("Nombre: ");
            nombre = Console.ReadLine ();

            Console.Write("Fecha de Nacimiento: ");
            fechaNacimiento = Console.ReadLine ();

            Console.Write("Raza: ");
            raza = Console.ReadLine ();

            Console.Write("Peso: ");
            peso = double.Parse (Console.ReadLine ());

            Console.Write("Microchip: ");
            microchip = Console.ReadLine();

            clinicaVeterinaria.InsertaAnimal(new Perro(nombre, DateTime.Parse(fechaNacimiento), peso, (RazaPerro) Enum.Parse(typeof(RazaPerro), raza), microchip));
        }

        static void ModifyCommentFromConsole ()
        {

        }
        private static void DisplayAnimal ()
        {
            
        }

    }
}
