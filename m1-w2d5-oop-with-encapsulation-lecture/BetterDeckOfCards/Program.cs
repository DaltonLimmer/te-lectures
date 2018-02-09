using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card(Card.Hearts, Card.Ace);
            WriteCardDetails(card);

            card.Suit = Card.Clubs;
            WriteCardDetails(card);

            card.Suit = Card.Diamonds;
            WriteCardDetails(card);

            card.Suit = Card.Spades;
            WriteCardDetails(card);

            Console.ReadKey();
        }

        private static void WriteCardDetails(Card card)
        {
            Console.WriteLine($"{card.Color} {card.GetValueName()} of {card.GetSuitName()}");
        }
    }
}
