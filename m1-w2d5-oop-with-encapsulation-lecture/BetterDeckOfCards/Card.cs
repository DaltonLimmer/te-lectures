using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDeckOfCards
{
    public class Card
    {
        // Member Variables

        // Suit
        public const int Spades = 1;
        public const int Diamonds = 2;
        public const int Hearts = 3;
        public const int Clubs = 4;

        // Value
        public const int Ace = 1;
        public const int Two = 2;
        public const int Three = 3;
        public const int Four = 4;
        public const int Five = 5;
        public const int Six = 6;
        public const int Seven = 7;
        public const int Eight = 8;
        public const int Nine = 9;
        public const int Ten = 10;
        public const int Jack = 11;
        public const int Queen = 12;
        public const int King = 13;

        // Color
        private const string Red = "Red";
        private const string Black = "Black";

        // Properties
        public int Suit { get; set; }
        public int Value { get; set; }
        public string Color // Derived
        {
            get
            {
                string color = "";
                if (Suit == Spades || Suit == Clubs)
                {
                    color = Black;
                }
                else
                {
                    color = Red;
                }
                return color;
            }
        }

        // Constructors
        public Card(int suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        // Methods
        public string GetSuitName()
        {
            string suitName = "";

            switch (Suit)
            {
                case Spades:
                    suitName = "Spades";
                    break;
                case Diamonds:
                    suitName = "Diamonds";
                    break;
                case Clubs:
                    suitName = "Clubs";
                    break;
                case Hearts:
                    suitName = "Hearts";
                    break;
            }

            return suitName;
        }
        
        public string GetValueName()
        {
            string suitName = "";

            switch (Value)
            {
                case Ace:
                    suitName = "Ace";
                    break;
                case Two:
                    suitName = "Two";
                    break;
                case Three:
                    suitName = "Three";
                    break;
                case Four:
                    suitName = "Four";
                    break;
                case Five:
                    suitName = "Five";
                    break;
                case Six:
                    suitName = "Six";
                    break;
                case Seven:
                    suitName = "Seven";
                    break;
                case Eight:
                    suitName = "Eight";
                    break;
                case Nine:
                    suitName = "Nine";
                    break;
                case Ten:
                    suitName = "Ten";
                    break;
                case Jack:
                    suitName = "Jack";
                    break;
                case Queen:
                    suitName = "Queen";
                    break;
                case King:
                    suitName = "King";
                    break;
            }

            return suitName;
        }

    }
}
