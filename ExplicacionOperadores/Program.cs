using System;

namespace ExplicacionOperadores
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordenada c1 = new Coordenada(0,2);
            Coordenada c2 = new Coordenada(5,5);
            
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c1 + c2);
            Console.WriteLine(c1 + 10);
            Console.WriteLine(10 + c1);//La propiedad conmutativa no se presupone.
            Console.WriteLine(-c2);

            if (c1 == c2)
            {
                Console.WriteLine("Son iguales");
            }
            else
            {
                Console.WriteLine("Son distintos");
            }
        }
    }
}
