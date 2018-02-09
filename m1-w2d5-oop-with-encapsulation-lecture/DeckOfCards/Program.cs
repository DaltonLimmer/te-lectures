using DeckOfCards.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            for (int i = 1; i <= 52; i++)
            {
                Card topCard = deck.DealOne();
                Console.WriteLine($"{topCard.FaceValue} of {topCard.Suit} - {topCard.Symbol}");
            }
        }
    }
}
