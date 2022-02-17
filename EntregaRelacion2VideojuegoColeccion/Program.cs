using System;
using System.IO;

namespace VideojuegosDB
{
    public enum Plataforma
    {
        PC, PlayStation_4, Xbox_One, Switch
    }

    public enum TipoJuego
    {
        Accion, Aventura, Puzzle, Rol, Deportes, Estrategia
    }

    class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            Coleccion c = new Coleccion();

            if (File.Exists("videojuegos.db"))
            {
                c.LeeColeccionFichero("videojuegos.db");
            }


            while (opcion != "0")
            {
                Console.WriteLine("Colección de Videojuegos");
                Console.WriteLine("------------------------");
                Console.WriteLine();
                Console.WriteLine("1- Insertar videojuego");
                Console.WriteLine("2- Borrar videojuego");
                Console.WriteLine("3- Listado de la colección");
                Console.WriteLine("0- Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                opcion = Console.ReadLine();
                Console.WriteLine("\n");

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Escribe el nombre:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Escribe el año:");
                        int anno = int.Parse(Console.ReadLine());
                        Console.WriteLine("Elige la plataforma:");
                        Plataforma plat = eligePlataforma();
                        Console.WriteLine("Elige el tipo de juego:");
                        TipoJuego tj = eligeTipoJuego();
                        Console.WriteLine("Escribe la valoración:");
                        int valoracion = int.Parse(Console.ReadLine());

                        Videojuego v = new Videojuego(nombre, anno, plat, tj, valoracion);
                        c.InsertaVideojuego(v);

                        break;
                    case "2":
                        Console.WriteLine("Elige el videojuego a borrar");
                        Console.WriteLine(c.ToStringNum());
                        Console.Write("Opción: ");
                        int op = int.Parse(Console.ReadLine());

                        Console.WriteLine(c.LeeVideojuego(op - 1).Nombre + " eliminado correctamente");
                        c.EliminaVideojuego(op - 1);

                        break;
                    case "3":
                        Console.WriteLine(c.ToString());
                        break;
                    case "0":
                        Console.WriteLine("¡Hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine("\n");
            }

            c.GuardaColeccionFichero("videojuegos.db");
        }

        public static Plataforma eligePlataforma()
        {
            string[] plat = Enum.GetNames(typeof(Plataforma));
            for (int i = 0; i < plat.Length; i++)
            {
                Console.Write(i + 1);
                Console.WriteLine("- " + plat[i].Replace('_', ' '));
            }

            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine());

            return (Plataforma)(op - 1);
        }

        public static TipoJuego eligeTipoJuego()
        {
            string[] tipoj = Enum.GetNames(typeof(TipoJuego));
            for (int i = 0; i < tipoj.Length; i++)
            {
                Console.Write(i + 1);
                Console.WriteLine("- " + tipoj[i]);
            }

            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine());

            return (TipoJuego)(op - 1);         
        }

    }
}
