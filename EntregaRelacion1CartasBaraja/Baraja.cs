using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaRelacion1CartasBaraja
{
    class Baraja
    {
        /*ATRIBUTOS*/
        private List<Carta> _listaCartas;

        /*CONSTRUCTORES*/
        /// <summary>
        /// Crea una baraja vacía.
        /// </summary>
        public Baraja ()
        {
            _listaCartas = new List<Carta>();
        }
        /// <summary>
        /// Crea una baraja española.
        /// </summary>
        /// <param name="shuffle">True para barajar, false para tener una baraja ordenada que va del As de oros al Rey de bastos.</param>
        public Baraja (bool shuffle)
        {
            _listaCartas = new List<Carta>();
            Carta carta;

            for (int i = 1; i < 41; i++)
            {
                carta = new Carta(i);
                _listaCartas.Add(carta);
            }

            if (shuffle)
            {
                Barajar();
            }
        }

        /*PROPIEDADES*/
        /// <summary>
        /// Número de cartas en la baraja.
        /// </summary>
        public int NumeroCartas
        {
            get
            {
                return _listaCartas.Count;
            }
        }
        /// <summary>
        /// Baraja vacía o no.
        /// </summary>
        public bool Vacia
        {
            get
            {
                return NumeroCartas == 0;
            }
        }

        /*MÉTODOS*/
        /// <summary>
        /// Desordena la lista que representa nuestra baraja.
        /// </summary>
        public void Barajar ()
        {
            _listaCartas = DesordenaLista(_listaCartas);
        }
        /// <summary>
        /// Corta la baraja, pasa cartas del principio al final.
        /// </summary>
        /// <param name="position">Un número posible de cartas que pasar al final de la baraja.</param>
        public void Cortar (int position)
        {
            if (position > 0 && position < _listaCartas.Count)
            {
                List<Carta> monton = new List<Carta>(_listaCartas.GetRange(0, position));
                _listaCartas.RemoveRange(0, position);
                _listaCartas.AddRange(monton);
            }
            else
            {
                throw new Exception("No existe la posición en la baraja.");
            }
        }
        /// <summary>
        /// Devuelve la primera carta de la baraja y la elimina de esta.
        /// </summary>
        /// <returns>Un objeto de tipo Carta.</returns>
        public Carta Robar ()
        {
            Carta primera;

            if (_listaCartas.Count > 0)
            {
                primera = _listaCartas[0];
                _listaCartas.RemoveAt(0);
            }
            else
            {
                throw new Exception("No quedan cartas en el mazo");
            }

            return primera;
        }
        /// <summary>
        /// Inserta una carta al final.
        /// </summary>
        /// <param name="idCarta">Un entero entre 1 y 40 que representa el id de la carta.</param>
        public void InsertaCartaAlFinal (int idCarta)
        {
            Carta nuevaCarta = new Carta(idCarta);
            _listaCartas.Add(nuevaCarta);
        }
        /// <summary>
        /// Inserta una carta al final.
        /// </summary>
        /// <param name="carta">Un objeto tipo Carta.</param>
        public void InsertaCartaAlFinal (Carta carta)
        {
            _listaCartas.Add(carta);
        }
        /// <summary>
        /// Inserta una carta al principio.
        /// </summary>
        /// <param name="idCarta">Un entero entre 1 y 40 que representa el id de la carta.</param>
        public void InsertaCartaPrincipio (int idCarta)
        {
            Carta nuevaCarta = new Carta(idCarta);
            _listaCartas.Insert(0, nuevaCarta);
        }
        /// <summary>
        /// Inserta una carta al principio.
        /// </summary>
        /// <param name="carta">Un objeto tipo Carta.</param>
        public void InsertaCartaPrincipio (Carta carta)
        {
            _listaCartas.Insert(0, carta);
        }

        /*OVERRIDE*/
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _listaCartas.Count; i++)
            {
                sb.AppendLine(_listaCartas[i].ToString());
            }

            return sb.ToString();
        }

        /*HELPERS*/
        private List<Carta> DesordenaLista(List<Carta> l)
        {
            List<Carta> result = new List<Carta>();
            Random r = new Random();
            int randomIndex;

            while (l.Count > 0)
            {
                randomIndex = r.Next(0, l.Count);
                result.Add(l[randomIndex]);
                l.RemoveAt(randomIndex);
            }

            return result;
        }
    }
}
