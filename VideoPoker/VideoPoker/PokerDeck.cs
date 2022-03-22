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

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    deck.Add(new PokerCard((Rank)i, (Suit)j));
                }
            }

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
        public string CardList ()
        {
            StringBuilder sb = new StringBuilder ();

            foreach (PokerCard pokerCard in deck)
            {
                sb.AppendLine(pokerCard.ToString());
            }

            return sb.ToString ();
        }
    }
}
