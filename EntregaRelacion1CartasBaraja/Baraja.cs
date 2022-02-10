using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaRelacion1CartasBaraja
{
    class Baraja
    {
        /*ATRIBUTOS*/
        private List<Carta> ListaCartas;

        /*CONSTRUCTORES*/
        public Baraja ()
        {
            ListaCartas = new List<Carta>();
        }
        public Baraja (bool shuffle)
        {
            ListaCartas = new List<Carta>();
            Carta carta;

            for (int i = 1; i < 41; i++)
            {
                carta = new Carta(i);
                ListaCartas.Add(carta);
            }

            if (shuffle)
            {
                ListaCartas = DesordenaLista(ListaCartas);
            }
        }

        /*PROPIEDADES*/
        public int NumeroCartas
        {
            get
            {
                return ListaCartas.Count;
            }
        }
        public bool Vacia
        {
            get
            {
                return NumeroCartas == 0 ? true : false;
            }
        }

        /*MÉTODOS*/
        public void Barajar ()
        {
            ListaCartas = DesordenaLista(ListaCartas);
        }
        public void Cortar (int position)
        {
            if (position > 0 && position < ListaCartas.Count)
            {
                List<Carta> monton = new List<Carta>(ListaCartas.GetRange(0, position));
                ListaCartas.RemoveRange(0, position);
                ListaCartas.AddRange(monton);
            }
            else
            {
                throw new Exception("No existe la posición en la baraja.");
            }
        }
        public Carta Robar ()
        {
            Carta primera;

            if (ListaCartas.Count > 0)
            {
                primera = ListaCartas[0];
                ListaCartas.RemoveAt(0);
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
            ListaCartas.Add(nuevaCarta);
        }
        public void InsertaCartaAlFinal (Carta carta)
        {
            ListaCartas.Add(carta);
        }
        public void InsertaCartaPrincipio (int idCarta)
        {
            Carta nuevaCarta = new Carta(idCarta);
            ListaCartas.Insert(0, nuevaCarta);
        }
        public void InsertaCartaPrincipio (Carta carta)
        {
            ListaCartas.Insert(0, carta);
        }

        /*OVERRIDE*/
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ListaCartas.Count; i++)
            {
                sb.AppendLine(ListaCartas[i].ToString());
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
