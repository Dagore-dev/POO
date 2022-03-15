using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EntregaProfesorTribunal
{
    enum TipoGenero
    {
        Hombre,
        Mujer
    }
    class Profesor : IComparable<Profesor>
    {
        private string nombre;
        private string dni;
        private TipoGenero genero;

        public string Nombre 
        { 
            get => nombre; 
            set
            {
                if(value.Length != 0)
                {
                    nombre = value;
                }
                else
                {
                    throw new Exception("Nombre no puede ser una cadena vacía");
                }
            } 
        }
        public string Dni 
        { 
            get => dni;
            set
            {
                if (value.Length == 9)
                {
                    dni = value;
                }
                else
                {
                    throw new Exception("Dni debe ser una cadena de 9 caracteres.");
                }
            }
        }
        public string DniSinLetraInvertido
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                for (int i = Dni.Length - 1; i >= 0 ; i--)
                {
                    sb.Append(Dni[i]);
                }

                sb.Remove(0, 1);

                return sb.ToString();
            }
        }
        public TipoGenero Genero { get => genero; set => genero = value; }

        public Profesor (string nombre, string dni, TipoGenero genero)
        {
            Nombre = nombre;
            Dni = dni;
            Genero = genero;
        }

        private string Representation ()
        {
            return $"{Nombre} - {Dni}";
        }
        public override string ToString()
        {
            return Representation();
        }

        public int CompareTo([AllowNull] Profesor other)
        {
            return this.DniSinLetraInvertido.CompareTo(other.DniSinLetraInvertido);
        }
    }
}
