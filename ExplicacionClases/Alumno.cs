using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionClases
{
    class Alumno
    {
        public string name;
        public int age;
        public double score;
        public Alumno (string name, int age, double score)
        {
            this.name = name;
            this.age = age;
            this.score = score;
        }
        public bool Pass ()
        {
            bool result = false;
            
            if (score >= 5)
            {
                result = true;
            }

            return result;
        }
        public void ForcePass ()
        {
            if (score < 5)
            {
                score = 5;
            }
        }
    }
}
