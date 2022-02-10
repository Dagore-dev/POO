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
        private int numero;
        private Palo palo;

        /*CONSTRUCTORES*/
        public Carta (int numero, Palo palo)
        {
            if (NumeroIsValid(numero))
            {
                this.numero = numero;
            }
            else
            {
                throw new Exception("El número no existe en la baraja española.");
            }
            
            this.palo = palo;
        }
        public Carta (int id)
        {
            if (IdIsValid(id))
            {
                this.numero = GetNumeroById(id);
                this.palo = GetPaloById(id);
            }
            else
            {
                throw new Exception("El id para las cartas de la baraja española está comprendido entre 1 y 40, ambos incluidos.");
            }
        }

        /*PROPIEDADES*/
        public int NumeroCarta { get => numero; }
        public Palo PaloCarta { get => palo; }
        public string NombreNumero
        {
            get
            {
                string[] nombres = { "", "As", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "", "", "Sota", "Caballo", "Rey" };
                return nombres[NumeroCarta];
            }
        }
        public string NombrePalo
        {
            get
            {
                return PaloCarta.ToString().ToLower();
            }
        }
        public string NombreCarta
        {
            get
            {
                return $"{NombreNumero} de {NombrePalo}";
            }
        }
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
            bool isValid = true;

            if (numero < 1 || numero > 12 || numero == 8 || numero == 9)
            {
                isValid = false;
            }

            return isValid;
        }
        private bool IdIsValid(int id)
        {
            bool isValid = true;

            if (id < 1 || id > 40)
            {
                isValid = false;
            }

            return isValid;
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
            Palo palo;

            if (id < 11)
            {
                palo = Palo.Oros;
            }
            else if (id < 21)
            {
                palo = Palo.Copas;
            }
            else if (id < 31)
            {
                palo = Palo.Espadas;
            }
            else
            {
                palo = Palo.Bastos;
            }

            return palo;
        }
    }
}
