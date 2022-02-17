using System;
using System.IO;

namespace EntregaRelacion2AlumnoGrupo
{
    class Program
    {
        static void Main(string[] args)
        {
            Grupo grupo = new Grupo();
            int option;

            ShowMenu();

            option = int.Parse(Console.ReadLine());

            while (option > 0 && option < 9)
            {
                switch (option)
                {
                    case 1:
                        {
                            LeeAlumnoConsola(grupo);
                        }
                        break;
                    case 2:
                        {
                            ImprimeAlumnos(grupo);
                        }
                        break;
                    case 3:
                        {
                            grupo.EscribeFicheroBinario("fichero/registroalumnosbinario.bin");
                        }
                        break;
                    case 4:
                        {
                            grupo.LeeFicheroBinario("fichero/registroalumnosbinario.bin");
                        }
                        break;
                    case 5:
                        {
                            grupo.EscribeFicheroTexto("fichero/registroalumnostexto.txt");
                        }
                        break;
                    case 6:
                        {
                            grupo.LeeFicheroTexto("fichero/registroalumnostexto.txt");
                        }
                        break;
                    case 7:
                        {
                            grupo.EscribeFicheroCSV("fichero/registroalumnos.csv");
                        }
                        break;
                    case 8:
                        {
                            grupo.LeeFicheroCSV("fichero/registroalumnos.csv");
                        }
                        break;
                    default:
                        break;
                }

                Console.Write("Introduzca otra opción o 0 para terminar: ");
                option = int.Parse(Console.ReadLine());
            }
        }
        #region utils
        static void ShowMenu()
        {
            Console.WriteLine("MENU:");

            Console.WriteLine("1 - LeeAlumnoConsola");
            Console.WriteLine("2 - ImprimeAlumnos");
            Console.WriteLine("3 - EscribeFicheroBinario");
            Console.WriteLine("4 - LeeFicheroBinario");
            Console.WriteLine("5 - EscribeFicheroTexto");
            Console.WriteLine("6 - LeeFicheroTexto");
            Console.WriteLine("7 - EscribeFicheroCSV");
            Console.WriteLine("8 - LeeFicheroCSV");

            Console.Write("Introduce una opción: ");
        }
        static void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        static void PrintRow(int tableWidth, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }
        static string AlignCentre(string text, int width)
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
        #endregion
        static void LeeAlumnoConsola (Grupo grupo)
        {
            string nombre;
            int edad;
            double calificacion;

            Console.WriteLine("Introduce la información del nuevo alumno:");

            Console.Write("Nombre del alumno: ");
            nombre = Console.ReadLine();

            Console.Write("Edad del alumno: ");
            edad = int.Parse(Console.ReadLine());

            Console.Write("Calificación del alumno: ");
            calificacion = double.Parse(Console.ReadLine());

            grupo.InsertaAlumnoLista(nombre, edad, calificacion);
        }
        static void ImprimeAlumnos (Grupo grupo)
        {
            int tableWidth = 100;

            PrintLine(tableWidth);
            PrintRow(tableWidth, "Nombre", "Edad", "Calificación");

            grupo.ForEach(alumno => 
            {
                PrintLine(tableWidth);
                PrintRow(tableWidth, alumno.Nombre, alumno.Edad.ToString(), String.Format("{0:0.00}", alumno.Calificacion));
            });
        }
    }
}
