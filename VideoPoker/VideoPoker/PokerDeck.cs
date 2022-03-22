using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPoker
{
    class PokerDeck
    {
        private List<PokerCard> deck;

        public PokerDeck ()
        {
            deck = new List<PokerCard> ();

            //TODO: Añadir las 52 cartas de la baraja.

            Shuffle();
        }

        public PokerCard DrawCard ()
        {
            PokerCard pokerCard = deck[0];

            deck.Remove(pokerCard);

            return pokerCard;
        }
        public void Shuffle ()
        {
            deck = DesordenaLista (deck);
        }
        private List<PokerCard> DesordenaLista(List<PokerCard> l)
        {
            List<PokerCard> result = new List<PokerCard>();
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
