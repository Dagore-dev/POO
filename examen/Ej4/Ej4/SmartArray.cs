using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3T
{
    public class SmartArray
    {
        private int[] array;

        public SmartArray(int size)
        {
            array = new int[size];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }

            set
            {
                array[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return array.Length;
            }
        }
        //ToString
        private string Representation ()
        {
            string result = "";

            if (array.Length > 0)
            {
                result += "[";

                for (int i = 0; i < array.Length - 1; i++)
                {
                    result += array[i] + ", ";
                }

                result += $"{array[array.Length - 1]}]";
            }
            else
            {
                result += "[]";
            }

            return result;
        }
        public override string ToString()
        {
            return Representation ();
        }
        //Contains
        public bool Contains (int value)
        {
            bool contains = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    contains = true;
                    i = array.Length;
                }
            }

            return contains;
        }
        //IndexOf
        public int IndexOf (int value)
        {
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    index = i;
                    i = array.Length;
                }
            }

            return index;
        }
        //Shuffle
        public void Shuffle ()
        {
            Random r = new Random();
            int position, temp;

            for (int i = 0; i < array.Length; i++)
            {
                position = r.Next(0, array.Length);

                temp = array[i];

                array[i] = array[position];
                array[position] = temp;
            }
        }
        //Sort, en mi caso con ordenación de tipo burbuja.
        public void Sort ()
        {
            int temp;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        //Reverse
        public void Reverse ()
        {
            int i = 0, j = array.Length - 1, temp;

            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;

                i++;
                j--;
            }
        }
        //Operadores == y !=
        public static bool operator == (SmartArray a1, SmartArray a2)
        {
            bool areEqual = true;

            if (a1.Length == a2.Length)
            {
                for (int i = 0; i < a1.Length; i++)
                {
                    if (a1[i] != a2[i])
                    {
                        areEqual = false;
                        i = a1.Length;
                    }
                }
            }
            else
            {
                areEqual = false;
            }

            return areEqual;
        }
        public static bool operator !=(SmartArray a1, SmartArray a2)
        {
            return !(a1 == a2);
        }
        
    }
}
