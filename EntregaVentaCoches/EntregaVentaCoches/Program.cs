using System;

namespace EntregaVentaCoches
{
    class Program
    {
        public static AutoVenta autoVenta = new AutoVenta();
        static void Main(string[] args)
        {
            bool open = true;
            int option;
            autoVenta.CargaCSV("./Coches.csv");

            while (open)
            {
                ShowMenu();
                Console.Write("Introduce una opción: ");
                option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        InsertaCoche();
                        break;
                    case 2:
                        BuscaCoche();
                        break;
                    case 3:
                        Console.WriteLine(autoVenta.ImprimeListado());
                        break;
                    default:
                        Console.WriteLine("Hasta la próxima");
                        open = false;
                        break;
                }
            }

            autoVenta.GuardaCSV("./Coches.csv");
        }

        private static void ShowMenu ()
        {
            Console.WriteLine("Venta de coches");
            Console.WriteLine(" 1 - Inserta un coche en nuestra base de datos.");
            Console.WriteLine(" 2 - Busca un coche en nuestra base de datos.");
            Console.WriteLine(" 3 - Lista los coches en nuestra base de datos.");
            
            Console.WriteLine();

            Console.WriteLine("Cuaquier otra tecla para salir.");
        }
        private static void BuscaCoche()
        {
            string matricula;
            
            Console.Write("Introduce a continuación la matrícula del coche: ");
            matricula = Console.ReadLine();

            Console.WriteLine(autoVenta.BuscaCoche(matricula));
        }
        private static void InsertaCoche()
        {
            string matricula, marca, modelo;
            DateTime fechaMatriculación;
            double precio;
            
            Console.WriteLine("Introduce los datos del coche a continuación: ");
            
            Console.Write("Matrícula: ");
            matricula = Console.ReadLine();
            
            Console.Write("Marca: ");
            marca = Console.ReadLine();
            
            Console.Write("Modelo: ");
            modelo = Console.ReadLine();

            Console.Write("Fecha de matriculación: ");
            fechaMatriculación = DateTime.Parse(Console.ReadLine());
            
            Console.Write("Precio: ");
            precio = double.Parse(Console.ReadLine());

            autoVenta.InsertaCoche(new Coche(matricula, marca, modelo, fechaMatriculación, precio));
        }
    }
}
