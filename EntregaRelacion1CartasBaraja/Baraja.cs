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
        public Baraja ()
        {
            _listaCartas = new List<Carta>();
        }
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
                _listaCartas = DesordenaLista(_listaCartas);
            }
        }

        /*PROPIEDADES*/
        public int NumeroCartas
        {
            get
            {
                return _listaCartas.Count;
            }
        }
        public bool Vacia
        {
            get
            {
                return NumeroCartas == 0;
            }
        }

        /*MÉTODOS*/
        public void Barajar ()
        {
            _listaCartas = DesordenaLista(_listaCartas);
        }
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
        public void InsertaCartaAlFinal (int idCarta)
        {
            Carta nuevaCarta = new Carta(idCarta);
            _listaCartas.Add(nuevaCarta);
        }
        public void InsertaCartaAlFinal (Carta carta)
        {
            _listaCartas.Add(carta);
        }
        public void InsertaCartaPrincipio (int idCarta)
        {
            Carta nuevaCarta = new Carta(idCarta);
            _listaCartas.Insert(0, nuevaCarta);
        }
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
            //Escribe la función DesordenaLista a la que le pasas una lista y te la desordena. Para ello, iremos cogiendo al azar elementos de la lista y poniéndolos en otra lista(quitándolos de la primera).La segunda lista, contendrá los elementos al azar.
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
