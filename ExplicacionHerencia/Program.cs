using System;
using System.Collections.Generic;

namespace ExplicacionHerencia
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            La herencia en programación de objetos se define una relación entre distintas clases, donde hay clases que son subtipos de otras clases o las extienden con funcionalidad adicional. Las relaciones por herencia tienen una estructura de árbol.
            Métodos y propiedades de la clase padre existen también en las clases que heredan de esta, estas clases "hijo" tienen su propio tipo y también el tipo de la clase padre.

            Modificadores de acceso y herencia.
            El modificador private impide que los hijos vean la propiedad, para conseguir esto y evitar que el atributo se vea desde fuera se utiliza el modificador protected.

            Reimplementación de métodos (override)
            Modificar métodos del padre en el hijo con la palabra reservada override.

            Abstract
            Un abstract en una clase no se puede usar como tal. Es un molde para las siguientes clases que hereden de ella.
             */

            Coche c = new Coche("8767MBK", "Seat", "Panda", 2);
            Moto m = new Moto("7687PPL", "Yamaha", "YYZF-R3", 0, false);

            List<Vehiculo> l = new List<Vehiculo>();
            l.Add(c);
            l.Add(m);

            for (int i = 0; i < l.Count; i++)
            {
                //Automáticamente decide el toString que va a usar.
                Console.WriteLine(l[i].ToString());
                Console.WriteLine("".PadLeft(35, '-'));
            }

            //Comparando tipos.
            Console.WriteLine(c.GetType() == typeof(Coche));
            Console.WriteLine(m.GetType() == typeof(Coche));

            //INTERFACES
            //A efectos prácticos son como las clases abstractas pero a diferencias de estas una clase puede implementar múltiples interfaces.
            //sealed => una clase sellada es una clase de la que no se puede heredar.

            /*DATETIME*/
            DateTime dt1 = new DateTime(2022, 3, 7);
            DateTime dt2 = new DateTime(1, 1, 1, 13, 24, 30);
            Console.WriteLine(dt1.ToLongDateString());
            Console.WriteLine(dt1.ToString("yyyy-MM-dd"));
            Console.WriteLine(dt2);
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd, hh:mm:ss"));
            dt2.AddHours(-1);
            TimeSpan ts = dt1 - DateTime.Now;
            Console.WriteLine(ts);
        }
    }
}
