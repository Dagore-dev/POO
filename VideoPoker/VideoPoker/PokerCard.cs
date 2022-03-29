using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VideoPoker
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }
    public enum Rank
    {
        N2,
        N3,
        N4,
        N5,
        N6,
        N7,
        N8,
        N9,
        N10,
        Jack,
        Queen,
        Ace
    }
    class PokerCard : IComparable<PokerCard>
    {
        private Rank rank;
        private Suit suit;

        public PokerCard (Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public string Rank 
        { get 
            { return GetRankSymbol(rank); } 
        }
        public string Suit 
        { 
            get { return GetSuitSymbol(suit); } 
        }

        private string GetRankSymbol (Rank rank)
        {
            string symbol;

            switch (rank)
            {
                case VideoPoker.Rank.N2:
                    symbol = "2";
                    break;
                case VideoPoker.Rank.N3:
                    symbol = "3";
                    break;
                case VideoPoker.Rank.N4:
                    symbol = "4";
                    break;
                case VideoPoker.Rank.N5:
                    symbol = "5";
                    break;
                case VideoPoker.Rank.N6:
                    symbol = "6";
                    break;
                case VideoPoker.Rank.N7:
                    symbol = "7";
                    break;
                case VideoPoker.Rank.N8:
                    symbol = "8";
                    break;
                case VideoPoker.Rank.N9:
                    symbol = "9";
                    break;
                case VideoPoker.Rank.N10:
                    symbol = "10";
                    break;
                case VideoPoker.Rank.Jack:
                    symbol = "J";
                    break;
                case VideoPoker.Rank.Queen:
                    symbol = "Q";
                    break;
                case VideoPoker.Rank.Ace:
                    symbol = "A";
                    break;
                default:
                    throw new Exception("Not a rank");
            }

            return symbol;
        }
        private string GetSuitSymbol(Suit suit)
        {
            string symbol;

            switch (suit)
            {
                case VideoPoker.Suit.Hearts:
                    symbol = "\u2665";
                    break;
                case VideoPoker.Suit.Diamonds:
                    symbol = "\u2666";
                    break;
                case VideoPoker.Suit.Spades:
                    symbol = "\u2660";
                    break;
                case VideoPoker.Suit.Clubs:
                    symbol = "\u2663";
                    break;
                default:
                    throw new Exception("Not a symbol");
            }

            return symbol;
        }

        public static bool operator == (PokerCard c1, PokerCard c2)
        {
            return c1.suit == c2.suit && c1.rank == c2.rank;
        }
        public static bool operator != (PokerCard c1, PokerCard c2)
        {
            return !(c1 == c2);
        }
        private string Represent ()
        {
            return $"{Rank}{Suit}";
        }
        public override string ToString()
        {
            return Represent();
        }
        public int CompareTo([AllowNull] PokerCard other)
        {
            if (this.rank.CompareTo(other.rank) >= 0)
            {
                if (this.rank.CompareTo(other.rank) > 0)
                {
                    return 1;
                }
                else
                {
                    return this.suit.CompareTo(other.suit);
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
