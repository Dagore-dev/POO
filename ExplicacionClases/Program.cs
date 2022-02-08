using System;

namespace ExplicacionClases
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Programación orientada a objetos (POO) 
             
                Nos ofrece alguna propiedades potentes para crear nuestros programas: HERENCIA, COHESIÓN, ABSTRACCIÓN, POLIMORFISMO, ACOPLAMIENTO, ENCAPSULAMIENTO
             
                Clases y objetos
                    
                    Las clases son planos (esquemas) para la creación de objetos. Um objeto un conjunto de variables (llamadas atributos) y funciones (métodos) relacionados.
                    
                    Normalmente las clases se generan en un fichero distinto, esto se puede hacer en VS2019 facilmente en proyecto > agregar clase.
                    
                    Los atributos y métodos de las clases presentan un modificador de acceso (public, private, protected, ...) con el que se indica si se puede acceder al atributo o método desde una instancia (desde un objeto) de esta.
             */

            //Alumno alumno = new Alumno();

            //alumno.name = "David";
            //alumno.age = 27;
            //alumno.score = 3.5;

            //Console.WriteLine(alumno.Pass());//false
            //alumno.ForcePass();//Le ponemos un 5.
            //Console.WriteLine(alumno.Pass());//true

            /*Lo suyo sería tener un constructor*/
            Alumno alumno = new Alumno("David", 27, 3.5);

            Console.WriteLine(alumno.Pass());
            alumno.ForcePass();
            Console.WriteLine(alumno.Pass());

            Pokemon bulbasaur = new Pokemon("Bulbasaur", 1, PokemonType.Grass, PokemonGender.Macho, 15, 15, 1);
            Pokemon charmander = new Pokemon("Charmander", 5, PokemonType.Fire, PokemonGender.Hembra, 13, 17, 1);
            Console.WriteLine(bulbasaur.CurrentHP);
            bulbasaur.CurrentHP = 10;
            Console.WriteLine(bulbasaur.CurrentHP);
            bulbasaur.DrinkPotion();
            Console.WriteLine(bulbasaur.CurrentHP);
            Console.WriteLine(bulbasaur);
            //Pokemon bad = new Pokemon("", -1, 0, 12, 0);//Esto ahora peta con los checks
            
            PokemonTeam team = new PokemonTeam();
            team.InsertPokemon(bulbasaur);
            team.InsertPokemon(charmander);
            Console.WriteLine(team);
        }
    }
}
