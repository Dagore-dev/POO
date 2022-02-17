using System;

namespace VideojuegosDB
{
    class Videojuego
    {
        /*ATRIBUTOS*/
        private string nombre;
        private int anno;
        private Plataforma plataforma;
        private TipoJuego genero;
        private int valoracion;

        /*CONSTRUCTORES*/
        /// <summary>
        /// Genera un nuevo objeto Videojuego con varias característas.
        /// </summary>
        /// <param name="nombre">Nombre del videojuego, no puede estar vacío.</param>
        /// <param name="anno">Año de la lanzamiento, entre 1970 y 2100.</param>
        /// <param name="plataforma">Plataforma en la que salió el juego. PC, PlayStation_4, Xbox_One o Switch.</param>
        /// <param name="genero">Accion, Aventura, Puzzle, Rol, Deportes o Estrategia.</param>
        /// <param name="valoracion">Un entero entre 0 y 100. 0 es la valoración más baja y 100 la más alta.</param>
        public Videojuego(string nombre, int anno, Plataforma plataforma, TipoJuego genero, int valoracion)
        {
            Nombre = nombre;
            Anno = anno;
            Plataforma = plataforma;
            Genero= genero;
            Valoracion = valoracion;
        }

        /*PROPIEDADES*/
        /// <summary>
        /// Nombre del videojuego, no puede estar vacío.
        /// </summary>
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (value != "")
                {
                    nombre = value;
                }
                else
                {
                    throw new Exception("Eñ nombre del videojuego no puede estar vacío.");
                }
            }
        }
        /// <summary>
        /// Año de lanzamiento, entre 1970 y 2100.
        /// </summary>
        public int Anno
        {
            get
            {
                return anno;
            }
            set
            {
                if (value >= 1970 && value <= 2100)
                {
                    anno = value;
                }
                else
                {
                    throw new Exception("El año está comprendido entre 1970 y 2100.");
                }
            }
        }
        /// <summary>
        /// Plataforma: PC, PlayStation_4, Xbox_One, Switch.
        /// </summary>
        public Plataforma Plataforma
        {
            get
            {
                return plataforma;
            }
            set
            {
                plataforma = value;
            }
        }
        /// <summary>
        /// Genero: Accion, Aventura, Puzzle, Rol, Deportes, Estrategia.
        /// </summary>
        public TipoJuego Genero
        {
            get
            {
                return genero;
            }
            set
            {
                genero = value;
            }
        }
        /// <summary>
        /// Entero entre 0 y 100. 0 se corresponde con la peor valoración y 100 la mejor.
        /// </summary>
        public int Valoracion
        {
            get
            {
                return valoracion;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    valoracion = value;
                }
                else
                {
                    throw new Exception("La valoración debe estar entre 0 y 100");
                }
            }
        }

        /*OVERRIDE*/
        public override string ToString()
        {
            
            return $"{Nombre};{Anno};{Plataforma};{Genero};{Valoracion}";
        }
        
        /*REPRESENTACIÓN*/
        public string ToCSVString()
        {
            return $"{Nombre};{Anno};{(int)Plataforma};{(int)Genero};{Valoracion}";
        }
    }
}