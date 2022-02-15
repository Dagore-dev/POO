using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaRelacion1CartasBaraja
{
    enum Palo
    {
        Oros,
        Copas,
        Espadas,
        Bastos
    }
    class Carta
    {
        /*ATRIBUTOS*/
        private int _numero;
        private Palo _palo;

        /*CONSTRUCTORES*/
        /// <summary>
       /// Crea una carta con un número y palo determinados.
       /// </summary>
       /// <param name="numero">Número del 1 al 12 que no sean 8 o 9</param>
       /// <param name="palo">Oros, Copas, Espadas y Bastos</param>
        public Carta (int numero, Palo palo)
        {
            if (NumeroIsValid(numero))
            {
                _numero = numero;
            }
            else
            {
                throw new Exception("El número no existe en la baraja española.");
            }
            
            _palo = palo;
        }
        /// <summary>
        /// Crea una carta a partir de un id. Siendo el 1 el "as de oros" y 40 el "rey de bastos".
        /// </summary>
        /// <param name="id">Un valor entre 1 y 40, ambos incluidos.</param>
        public Carta (int id)
        {
            if (IdIsValid(id))
            {
                _numero = GetNumeroById(id);
                _palo = GetPaloById(id);
            }
            else
            {
                throw new Exception("El id para las cartas de la baraja española está comprendido entre 1 y 40, ambos incluidos.");
            }
        }

        /*PROPIEDADES*/
        /// <summary>
        /// Devuelve un entero con el número de la carta.
        /// </summary>
        public int NumeroCarta { get => _numero; }
        /// <summary>
        /// Devuelve un enum con el palo de la carta.
        /// </summary>
        public Palo PaloCarta { get => _palo; }
        /// <summary>
        /// Devuelve el nombre del número de la carta ("As", "Dos", ..., "Sota", "Caballo", "Rey").
        /// </summary>
        private string NombreNumero
        {
            get
            {
                string[] nombres = { "", "As", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "", "", "Sota", "Caballo", "Rey" };
                return nombres[NumeroCarta];
            }
        }
        /// <summary>
        /// Devuelve un string con el palo de la carta.
        /// </summary>
        private string NombrePalo
        {
            get
            {
                return PaloCarta.ToString().ToLower();
            }
        }
        /// <summary>
        /// Devuelve un string con el nombre completo de la carta ("As de copas", "Tres de bastos").
        /// </summary>
        public string NombreCarta
        {
            get
            {
                return $"{NombreNumero} de {NombrePalo}";
            }
        }
        /// <summary>
        /// Devuelve un entero con el valor de la carta en el Tute.
        /// </summary>
        public int ValorTute
        {
            get
            {
                int valorTute;

                switch (NumeroCarta)
                {
                    case 1: valorTute = 11; break;
                    case 3: valorTute = 10; break;
                    case 10: valorTute = 2; break;
                    case 11: valorTute = 3; break;
                    case 12: valorTute = 4; break;
                    default: valorTute = 0; break;
                }

                return valorTute;
            }
        }
        /// <summary>
        /// Devuelve un entero con el valor de la carta en el Mus.
        /// </summary>
        public int ValorMus
        {
            get
            {
                int ValorMus;

                switch (NumeroCarta)
                {
                    case 2: ValorMus = 1; break;
                    case 3: ValorMus = 10; break;
                    case 10: ValorMus = 10; break;
                    case 11: ValorMus = 10; break;
                    case 12: ValorMus = 10; break;
                    default: ValorMus = NumeroCarta; break;
                }

                return ValorMus;
            }
        }
        /// <summary>
        /// Devuelve un decimal con el valor de la carta en las 7 y media.
        /// </summary>
        public decimal Valor7ymedia
        {
            get
            {
                decimal valor7ymedia;

                switch (NumeroCarta)
                {
                    case 10: valor7ymedia = 0.5m; break;
                    case 11: valor7ymedia = 0.5m; break;
                    case 12: valor7ymedia = 0.5m; break;
                    default: valor7ymedia = NumeroCarta; break;
                }

                return valor7ymedia;
            }
        }

        /*OVERRIDE*/
        public override string ToString()
        {
            return NombreCarta;
        }

        /*HELPERS*/
        private bool NumeroIsValid(int numero)
        {
            return numero > 0 && numero < 13 && numero != 8 && numero != 9;
        }
        private bool IdIsValid(int id)
        {
            return id >= 1 && id <= 40;
        }
        private int GetNumeroById (int id)
        {
            while (id > 10)
            {
                id -= 10;
            }

            if (id < 8)
            {
                return id;
            }
            else
            {
                return id + 2;
            }
        }
        private Palo GetPaloById (int id)
        {
            return (Palo) ((id - 1) / 10);
        }
    }
}
