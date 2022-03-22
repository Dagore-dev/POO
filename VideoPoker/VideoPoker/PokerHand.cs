using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VideoPoker
{
    class PokerHand
    {
        private PokerCard[] hand = new PokerCard[5];

        public PokerHand (PokerCard card1, PokerCard card2, PokerCard card3, PokerCard card4, PokerCard card5)
        {
            hand[0] = card1;
            hand[1] = card2;
            hand[2] = card3;
            hand[3] = card4;
            hand[4] = card5;

            SortHand();
        }
        public void SortHand ()
        {
            Array.Sort(hand);
        }
        public bool IsPair ()
        {
            return hand[0].Rank == hand[1].Rank || hand[1].Rank == hand[2].Rank || hand[2].Rank == hand[3].Rank || hand[3].Rank == hand[4].Rank;
        }
        public bool IsTwoPair ()
        {
            return hand[0].Rank == hand[1].Rank && hand[1].Rank == hand[2].Rank || hand[1].Rank == hand[2].Rank && hand[3].Rank == hand[4].Rank || hand[0].Rank == hand[1].Rank && hand[3].Rank == hand[4].Rank;
        }
        public bool IsThree ()
        {
            return hand[0].Rank == hand[1].Rank && hand[1].Rank == hand[2].Rank || hand[1].Rank == hand[2].Rank && hand[2].Rank == hand[3].Rank || hand[2].Rank == hand[3].Rank && hand[3].Rank == hand[4].Rank;
        }
        public bool IsStraight ()
        {
            return hand[1].Rank + 1 == hand[2].Rank && hand[2].Rank +1 == hand[3].Rank && hand[3].Rank + 1 == hand[4].Rank;
        }
        public bool IsFlush ()
        {
            return hand[0].Suit == hand[1].Suit && hand[2].Suit == hand[3].Suit && hand[3].Suit == hand[4].Suit;
        }
        public bool IsFull ()
        {
            return IsPair() && IsThree();
        }
        public bool IsPoker ()
        {
            return hand[0] == hand[1] && hand[1] == hand[2] && hand[2] == hand[3] || hand[1] == hand[2] && hand[2] == hand[3] && hand[3] == hand[4] || hand[0] == hand[1] && hand[1] == hand[3] && hand[3] == hand[4];
        }
        public bool IsStraightFlush ()
        {
            return IsFlush() && IsStraight();
        }
        public bool IsRoyalFlush ()
        {
            return IsStraightFlush() && hand[4].Rank == 'A';
        }
        public string Representation ()
        {
            StringBuilder stringBuilder = new StringBuilder ();

            for (int i = 0; i < hand.Length; i++)
            {
                stringBuilder.AppendLine(hand[i].ToString());
            }
            
            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return Representation();
        }
    }
}
