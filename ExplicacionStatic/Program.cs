using System;

namespace ExplicacionStatic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Métodos estáticos: método que no usa los atributos de la clase, no necesita acceso a los datos de la clase.
            PruebaStatic.MCD(2, 3);

            //Clases estáticas: bibliotecas de funciones como el objeto Math o el Console donde todos sus métodos son estáticos. No se pueden crear instancias de una clase estática.
            Math.Sqrt(4);

            //Atributos estáticos: los atributos estáticos se almacenan en la clase en lugar de en la instancia del objeto. Es un valor compartido con todas las instancias de la clase. Para mi esto es una especie de estado de la aplicación.
            PruebaStatic static1 = new PruebaStatic();
            PruebaStatic static2 = new PruebaStatic();

            Console.WriteLine(PruebaStatic.compartida);
            static1.CambiaCompartida(" cosa");
            Console.WriteLine(PruebaStatic.compartida);

            static2.CambiaCompartida(" diferente");
            Console.WriteLine(PruebaStatic.compartida);

            //Constructor estático: Inicializa atributos de la clase, se suele llamar la primera vez que se crea una instancia del objeto o la primera vez que accede a un valor static. Otro buen ejemplo sería una conexión a una base de datos que se inicie con el primer uso del programa de la misma.
            Console.WriteLine(PruebaStatic.rootDirectory);
        }
    }
}
