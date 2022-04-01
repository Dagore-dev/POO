using System;

namespace Examen3T
{
    public class Program
    {
        static void Main(string[] args)
        {
            SmartArray array = new SmartArray(5);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i+1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            SmartArray array2 = new SmartArray(5);
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = i + 1;
            }

            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }


            Console.WriteLine(array);
            Console.WriteLine(array == array2);
            Console.WriteLine(array.Contains(5));
            Console.WriteLine(array.IndexOf(3));
            array.Shuffle();
            Console.WriteLine(array);
            Console.WriteLine(array == array2);
            array.Sort();
            Console.WriteLine(array);
            array.Reverse();
            Console.WriteLine(array);
        }
    }
}