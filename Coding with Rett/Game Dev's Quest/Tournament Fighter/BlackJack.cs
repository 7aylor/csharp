using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Tournament_Fighter
{

    public static class BlackJack
    {
        static List<NPC> blackJackPlayers = new List<NPC>();

        /// <summary>
        /// Starts the game of blackjack. Called from another method to begin the game
        /// </summary>
        static public void play()
        {
            //initialize the dealer, Norm, with card positions at the middle of the console and down 4 units. -6 is used to help center with name
            initBlackJackPlayer(GameCharacters.Norm, (GameConstants.WINDOW_WIDTH / 2) - 6, Console.WindowTop + 4);

            //initialize the player with card positions at the middle of the screen and down 16 units. -6 is used to help center with name
            initBlackJackPlayer(GameCharacters.player, (GameConstants.WINDOW_WIDTH / 2) - 6, 16);

            //call Deal
            deal();
        }

        /// <summary>
        /// Deals the first two cards to the players
        /// </summary>
        static void deal()
        {


            GameCharacters.player.blackJackHand.addCardToHand(new Card(Suit.Clubs, Cards.Ace), GameCharacters.player.Name.Length);
            //dealCard(GameCharacters.player);
            dealCard(GameCharacters.Norm);

            GameCharacters.player.blackJackHand.addCardToHand(new Card(Suit.Clubs, Cards.Ace), GameCharacters.player.Name.Length);
            //dealCard(GameCharacters.player);
            dealCard(GameCharacters.Norm);

            //print the deal
            printNewDeal();

            //GameCharacters.player.blackJackHand.CheckForBlackJack();
            //GameCharacters.Norm.blackJackHand.CheckForBlackJack();


            playersTurn();
        }

        /// <summary>
        /// Adds a card to a player's hand and updates the current card position
        /// </summary>
        /// <param name="blackJackPlayer"></param>
        static void dealCard(NPC blackJackPlayer)
        {
            blackJackPlayer.blackJackHand.addCardToHand(BlackJackDeck.deck.drawTopCard(), blackJackPlayer.Name.Length);
        }

        /// <summary>
        /// Prints the deal, dealer has one card face down and player doesn't
        /// </summary>
        static void printNewDeal()
        {
            //print a clean interface
            Helper.printCleanUI();

            //loop through each player and print their cards
            for(int i = 0; i < blackJackPlayers.Count; i++)
            {
                //if the player is the dealer
                if (blackJackPlayers[i] == GameCharacters.Norm)
                {
                    //build the string to hold Norm's Title in the play screen
                    string normsTitle = GameCharacters.Norm.Occupation + " - " + GameCharacters.Norm.Name;

                    //set net position of Norms name to account for occupation length and " - "
                    GameCharacters.Norm.blackJackHand.namePos.X -= GameCharacters.Norm.Occupation.Length / 2 + 1;
                    
                    //print Dealer - Norm and set the correction positions
                    Console.SetCursorPosition(GameCharacters.Norm.blackJackHand.namePos.X, GameCharacters.Norm.blackJackHand.namePos.Y);
                    Console.WriteLine(normsTitle);
                    Console.SetCursorPosition(GameCharacters.Norm.blackJackHand.handCurrPos.X, GameCharacters.Norm.blackJackHand.handCurrPos.Y);
                    
                    //Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - (normsTitle.Length / 2),
                    //                           GameCharacters.Norm.blackJackHand.handCurrPos.Y - 1);
                    //Console.WriteLine(normsTitle);
                    //Console.SetCursorPosition(GameCharacters.Norm.blackJackHand.handCurrPos.X, GameCharacters.Norm.blackJackHand.handCurrPos.Y);

                    //try to print the cards, assuming the hand has cards
                    try
                    {
                        //print the first card facedown
                        GameCharacters.Norm.blackJackHand.hand[0].printCardFaceDown();
                        GameCharacters.Norm.blackJackHand.updatePlayerCardPos();

                        //print the second card faceup
                        GameCharacters.Norm.blackJackHand.hand[1].printCardFaceUp();
                        GameCharacters.Norm.blackJackHand.updatePlayerCardPos();
                    }
                    //catch and print no cards if they have no cards
                    catch
                    {
                        Console.Write("No cards in hand");
                    }

                }
                //if the player is the player of the game
                if (blackJackPlayers[i] == GameCharacters.player)
                {
                    //adjust the name position to account for " - score"
                    GameCharacters.player.blackJackHand.namePos.X -=  2;

                    Console.SetCursorPosition(GameCharacters.player.blackJackHand.namePos.X, GameCharacters.player.blackJackHand.namePos.Y);
                    Console.WriteLine(GameCharacters.player.Name + " - " + GameCharacters.player.blackJackHand.HandValue);
                    Console.SetCursorPosition(GameCharacters.player.blackJackHand.handCurrPos.X, GameCharacters.player.blackJackHand.handCurrPos.Y);


                    //set the cursor position and print the name of the player and their current hand value
                    //Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - (GameCharacters.player.Name.Length / 2),
                    //                           GameCharacters.player.blackJackHand.handCurrPos.Y - 1);
                    //Console.WriteLine(GameCharacters.player.Name + " - " + GameCharacters.player.blackJackHand.HandValue);
                    //Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - 2, GameCharacters.player.blackJackHand.handCurrPos.Y);

                    //try to print the cards, assuming the hand has cards
                    try
                    {
                        GameCharacters.player.blackJackHand.hand[0].printCardFaceUp();
                        GameCharacters.player.blackJackHand.updatePlayerCardPos();
                        GameCharacters.player.blackJackHand.hand[1].printCardFaceUp();
                        GameCharacters.player.blackJackHand.updatePlayerCardPos();
                    }
                    //catch and print no cards if they have no cards
                    catch
                    {
                        Console.Write("No cards in hand");
                    }

                }
            }

        }

        static void playersTurn()
        {
            
            Helper.buildPlayerNav();

            char[] options = new char[4];
            options[0] = 'a';
            options[1] = 'b';

            Console.WriteLine("a) Hit");
            Console.WriteLine("b) Stand");


            //If there is a split case or double down, take care of it here
            if(GameCharacters.player.blackJackHand.hand[0].CardName == GameCharacters.player.blackJackHand.hand[1].CardName)
            {
                Console.WriteLine("c) Split");
                options[2] = 'c';
                //call split function here
            }
            

            Console.Write("> ");


            while (!GameCharacters.player.blackJackHand.Busted)
            {
                if (GameCharacters.player.blackJackHand.HandValue <= 21)
                {
                    char playerChoice = Console.ReadKey().KeyChar;

                    Helper.checkInput(ref playerChoice, options);

                    if (playerChoice == 'a')
                    {
                        GameCharacters.player.blackJackHand.addCardToHand(BlackJackDeck.deck.drawTopCard(), GameCharacters.player.Name.Length);
                    }
                }
            }
        }

        static void endGame()
        {
            Helper.buildPlayerNav();
            Console.WriteLine("Press any key to flip dealer's card.");
            Console.ReadKey();
            Console.SetCursorPosition(GameCharacters.Norm.blackJackHand.handStartPos.X, GameCharacters.Norm.blackJackHand.handStartPos.Y);
            GameCharacters.Norm.blackJackHand.hand[0].printCardFaceUp();
        }

        /// <summary>
        /// Creates a blackjack player and assigns the card positions
        /// </summary>
        /// <param name="blackJackPlayer"></param>
        /// <param name="handStartPosX"></param>
        /// <param name="handStartPosY"></param>
        static void initBlackJackPlayer(NPC blackJackPlayer, int handStartPosX, int handStartPosY)
        {
            //add character to field of play but adding them to the blackJackPlayers list
            blackJackPlayers.Add(blackJackPlayer);

            //creates the given player a blackjack hand
            blackJackPlayer.blackJackHand = new BlackJackHand();

            //set the start position of the player's cards
            blackJackPlayer.blackJackHand.handStartPos.setCoords(handStartPosX, handStartPosY);

            //set the current position of the player's cards to the start position
            blackJackPlayer.blackJackHand.handCurrPos = blackJackPlayer.blackJackHand.handStartPos;

            //sets the name position x in the console to half the width - have the length of the player name
            int nameX = (GameConstants.WINDOW_WIDTH / 2) - (blackJackPlayer.Name.Length / 2);

            //sets the name position y to 1 above current position in the console, ie one position above the hand
            int nameY = blackJackPlayer.blackJackHand.handStartPos.Y - 1;
            blackJackPlayer.blackJackHand.namePos.setCoords(nameX, nameY);
        }

    }

    /// <summary>
    /// A black jack hand
    /// </summary>
    public class BlackJackHand
    {
        //list of cards
        public List<Card> hand;

        //total value of hand
        public int HandValue { get; set; }

        //check if the hand has been doubled down
        public bool DoubledDown { get; set; }

        //keeps track of number of Aces valued at 11
        public int numAcesValuedEleven = 0;

        public bool Busted { get; set; }

        //coordinates of the start and current hand positions
        public consoleCoords handStartPos;
        public consoleCoords handCurrPos;
        public consoleCoords namePos;


        /// <summary>
        /// Default contructor. Creats an empty list of cards and sets default values
        /// </summary>
        public BlackJackHand()
        {
            hand = new List<Card>();
            HandValue = 0;
            handStartPos = new consoleCoords(0, 0);
            handCurrPos = new consoleCoords(0, 0);
            namePos = new consoleCoords(0, 0);
            DoubledDown = false;
            Busted = false;
        }

        /// <summary>
        /// Adds a card to the hand, updates card value
        /// </summary>
        /// <param name="card"></param>
        public void addCardToHand(Card card, int nameLength)
        {
            if(card.CardName == "A")
            {
                if(HandValue + card.Value > 21)
                {

                }
                numAcesValuedEleven++;
            }

            //add new card to hand
            hand.Add(card);

            //set the cursor position to print the new card
            Console.SetCursorPosition(handCurrPos.X, handCurrPos.Y);

            //print the new card
            card.printCardFaceUp();

            //update the card position
            updatePlayerCardPos();

            //update the card value
            HandValue += card.Value;

            //check for a bust
            Busted = isBust();

            //if hand hasn't busted
            if (!Busted)
            {
                //print the new score
                printUpdatedHandValue(namePos.X + nameLength + 3, namePos.Y);
            }
            //if hand has busted
            else
            {
                //print the score and BUSTED
                printUpdatedHandValue(namePos.X + nameLength + 3, namePos.Y);
                Console.Write(" BUSTED");
            }
            
        }

        /// <summary>
        /// Checks hand value to see if it's more than 21. Adjust the Ace value if needed
        /// </summary>
        /// <returns></returns>
        public bool isBust()
        {

            Debug.Write("Called isBust()");

            //if there are no aces in the hand using value 11 and hand value is greater than 21
            if (HandValue > 21 && numAcesValuedEleven == 0)
            {
                Debug.Write("busted");
                //we have busted
                return true;
            }
            //if there hand value is greater than 21, but there are aces valued at 11
            else if(HandValue > 21 && numAcesValuedEleven > 0)
            {
                //loop through cards
                foreach(Card card in hand)
                {
                    //find the first ace with value 11
                    if(card.CardName == "A" && card.Value == 11)
                    {

                        Debug.Write("Called Ace");
                        //make its value 1 and break out of the loop
                        card.Value = 1;

                        //subtract 10 from handvalue
                        HandValue -= 10;

                        break;
                    }
                }

                //decrease number of aces with value 11
                numAcesValuedEleven--;

                

                //we haven't busted
                return false;
            }
            else
            {
                //we don't have a value greater than 21
                return false;
            }
        }

        public void CheckForBlackJack()
        {
            if (hand.Count == 2 && (hand[0].Value == 10 && hand[1].CardName == "A")
                               || (hand[1].Value == 10 && hand[0].CardName == "A"))
            {
                //print who the winner is
            }
        }

        /// <summary>
        /// Update the card position for a given player
        /// </summary>
        /// <param name="currentPlayer"></param>
        public void updatePlayerCardPos()
        {
            //gets the last card dealt to the player
            Card lastCard = hand[hand.Count - 1];

            //if the card is a 10, we need an extra space for its suit (3 instead of 2)
            if (lastCard.CardName == "10")
            {
                handCurrPos.X += 3;
            }
            else
            {
                handCurrPos.X += 2;
            }
        }

        public void printUpdatedHandValue(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(HandValue);
        }

    }
}
