using System;

namespace VideoPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            PokerHand pokerHand = new PokerHand(new PokerCard(Rank.N6, Suit.Clubs), new PokerCard(Rank.N2, Suit.Clubs), new PokerCard(Rank.Ace, Suit.Spades), new PokerCard(Rank.N6, Suit.Hearts), new PokerCard(Rank.N2, Suit.Hearts));

            Console.WriteLine(pokerHand);
            Console.WriteLine(pokerHand.IsPair());
            Console.WriteLine(pokerHand.IsTwoPair());
            Console.WriteLine(pokerHand.IsFull());

            PokerDeck deck = new PokerDeck();
            Console.WriteLine(deck.CardList());
        }
    }
}
