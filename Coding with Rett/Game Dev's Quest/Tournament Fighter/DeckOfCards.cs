using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tournament_Fighter
{
    enum Suit { Spades, Hearts, Diamonds, Clubs }
    enum Cards { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    class DeckOfCards
    {
        public List<Card> deck = new List<Card>();

        /// <summary>
        /// Default constructor. Builds a standard deck of cards
        /// </summary>
        public DeckOfCards()
        {
            buildDeck();
        }

        /// <summary>
        /// builds a standard deck of 52 cards
        /// </summary>
        public void buildDeck()
        {
            Suit ourSuit;
            Cards ourCard;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    switch (i)
                    {
                        case 0:
                            ourSuit = Suit.Clubs;
                            break;
                        case 1:
                            ourSuit = Suit.Diamonds;
                            break;
                        case 2:
                            ourSuit = Suit.Hearts;
                            break;
                        default:
                            ourSuit = Suit.Spades;
                            break;
                    }
                    switch (j)
                    {
                        case 0:
                            ourCard = Cards.Ace;
                            break;
                        case 1:
                            ourCard = Cards.Two;
                            break;
                        case 2:
                            ourCard = Cards.Three;
                            break;
                        case 3:
                            ourCard = Cards.Four;
                            break;
                        case 4:
                            ourCard = Cards.Five;
                            break;
                        case 5:
                            ourCard = Cards.Six;
                            break;
                        case 6:
                            ourCard = Cards.Seven;
                            break;
                        case 7:
                            ourCard = Cards.Eight;
                            break;
                        case 8:
                            ourCard = Cards.Nine;
                            break;
                        case 9:
                            ourCard = Cards.Ten;
                            break;
                        case 10:
                            ourCard = Cards.Jack;
                            break;
                        case 11:
                            ourCard = Cards.Queen;
                            break;
                        default:
                            ourCard = Cards.King;
                            break;
                    }//end of j switch
                    deck.Add(new Card(ourSuit, ourCard));
                }//end of j loop
            }//end of i loop
        }//end of build deck

        /// <summary>
        /// Prints the entire deck of cards
        /// </summary>
        public void printDeck()
        {
            foreach(Card card in deck)
            {
                card.printCardFaceUp();
            }
        }

        /// <summary>
        /// Draws a random card from the deck simulating a shuffled top card
        /// Removes that card from the deck and returns it
        /// </summary>
        /// <returns></returns>
        public Card drawTopCard()
        {
            Thread.Sleep(11);
            Random rand = new Random();
            int topCardIndex = rand.Next(0, deck.Count);
            Card topCard = deck[topCardIndex];
            deck.RemoveAt(topCardIndex);
            return topCard;
        }

        /// <summary>
        /// deletes the entire deck
        /// </summary>
        public void deleteDeck()
        {
            for(int i = deck.Count - 1; i >= 0; i--)
            {
                deck.RemoveAt(i);
            }
        }
    }

    class Card
    {
        //Keep track of x and y positions here instead of a struct
        int cardValue;
        Suit suit;
        string card;
        ConsoleColor background;
        ConsoleColor foreground;
        private const char spade = '\u2660';
        private const char heart = '\u2665';
        private const char diamond = '\u2666';
        private const char club = '\u2663';

        /// <summary>
        /// Creates a card from the suit and card value
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="card"></param>
        public Card(Suit suit, Cards card)
        {
            this.suit = suit;
            
            switch (card)
            {
                //Make sure to account for when ace is 1 or 11 *cardValue*
                case Cards.Ace:
                    this.card = "A";
                    this.cardValue = 1;
                    break;
                case Cards.Two:
                    this.card = "2";
                    this.cardValue = 2;
                    break;
                case Cards.Three:
                    this.card = "3";
                    this.cardValue = 3;
                    break;
                case Cards.Four:
                    this.card = "4";
                    this.cardValue = 4;
                    break;
                case Cards.Five:
                    this.card = "5";
                    this.cardValue = 5;
                    break;
                case Cards.Six:
                    this.card = "6";
                    this.cardValue = 6;
                    break;
                case Cards.Seven:
                    this.card = "7";
                    this.cardValue = 7;
                    break;
                case Cards.Eight:
                    this.card = "8";
                    this.cardValue = 8;
                    break;
                case Cards.Nine:
                    this.card = "9";
                    this.cardValue = 9;
                    break;
                case Cards.Ten:
                    this.card = "10";
                    this.cardValue = 10;
                    break;
                case Cards.Jack:
                    this.card = "J";
                    this.cardValue = 10;
                    break;
                case Cards.Queen:
                    this.card = "Q";
                    this.cardValue = 10;
                    break;
                default:
                    this.card = "K";
                    this.cardValue = 10;
                    break;
            }

            background = ConsoleColor.White;
            if (suit == Suit.Clubs || suit == Suit.Spades)
            {
                foreground = ConsoleColor.Black;
            }
            else
            {
                foreground = ConsoleColor.Red;
            }
        }

        //getters
        public int Value
        {
            get
            {
                return this.cardValue;
            }
        }

        public string CardType
        {
            get
            {
                return this.card;
            }
        }

        /// <summary>
        /// prints the card to the console
        /// </summary>
        public void printCardFaceUp()
        {

            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;

            Console.Write(this.card);
            
            if (this.suit == Suit.Clubs)
            {
                Console.Write(club);
            }
            else if (this.suit == Suit.Diamonds)
            {
                Console.Write(diamond);
            }
            else if (this.suit == Suit.Hearts)
            {
                Console.Write(heart);
            }
            else
            {
                Console.Write(spade);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void printCardFaceDown()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\\/");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
