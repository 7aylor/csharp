using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //initialize the dealer, Norm, with card positions at the middle of the console and down 4 units (Investigate the - 6)
            initBlackJackPlayer(GameCharacters.Norm, (GameConstants.WINDOW_WIDTH / 2) - 6, Console.WindowTop + 4);

            //initialize the player with card positions at the middle of the screen and down 16 units (Investigate the - 2)
            initBlackJackPlayer(GameCharacters.player, (GameConstants.WINDOW_WIDTH / 2) - 2, 16);

            //call Deal
            deal();
        }

        /// <summary>
        /// Deals the first two cards to the players
        /// </summary>
        static void deal()
        {
            /*Testing splits
            GameCharacters.player.blackJackHand.Add(new Card(Suit.Clubs, Cards.Eight));
            GameCharacters.player.blackJackHand.Add(new Card(Suit.Hearts, Cards.Eight));
            */

            dealCard(GameCharacters.player);
            dealCard(GameCharacters.Norm);

            dealCard(GameCharacters.player);
            dealCard(GameCharacters.Norm);

            //print the deal
            printNewDeal();
            playersChoice();
        }

        /// <summary>
        /// Adds a card to a player's hand and updates the current card position
        /// </summary>
        /// <param name="blackJackPlayer"></param>
        static void dealCard(NPC blackJackPlayer)
        {
            blackJackPlayer.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
            updatePlayerCardPos(blackJackPlayer);
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
                    //print Dealer - Norm and set the correction positions
                    string normsTitle = GameCharacters.Norm.Occupation + " - " + GameCharacters.Norm.Name;
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - (normsTitle.Length / 2),
                                               GameCharacters.Norm.handCurrPos.Y - 1);
                    Console.WriteLine(normsTitle);
                    Console.SetCursorPosition(GameCharacters.Norm.handCurrPos.X, GameCharacters.Norm.handCurrPos.Y);

                    //try to print the cards, assuming the hand has cards
                    try
                    {
                        //print the first card facedown
                        GameCharacters.Norm.blackJackHand[0].printCardFaceDown();

                        //print the second card faceup
                        GameCharacters.Norm.blackJackHand[1].printCardFaceUp();
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
                    //set the cursor position and print the name of the player
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - (GameCharacters.player.Name.Length / 2),
                                               GameCharacters.player.handCurrPos.Y - 1);
                    Console.WriteLine(GameCharacters.player.Name);
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - 2, GameCharacters.player.handCurrPos.Y);

                    //try to print the cards, assuming the hand has cards
                    try
                    {
                        GameCharacters.player.blackJackHand[0].printCardFaceUp();
                        GameCharacters.player.blackJackHand[1].printCardFaceUp();
                    }
                    //catch and print no cards if they have no cards
                    catch
                    {
                        Console.Write("No cards in hand");
                    }
                    
                }
            }

        }

        /// <summary>
        /// Update the card position for a given player
        /// </summary>
        /// <param name="currentPlayer"></param>
        static void updatePlayerCardPos(NPC currentPlayer)
        {
            //gets the last card dealt to the player
            Card lastCard = currentPlayer.blackJackHand[currentPlayer.blackJackHand.Count - 1];

            //if the card is a 10, we need an extra space for its suit (3 instead of 2)
            if(lastCard.CardType == "10")
            {
                currentPlayer.handCurrPos.X += 3;
            }
            else
            {
                currentPlayer.handCurrPos.X += 2;
            }
        }

        static void playersChoice()
        {
            
            Helper.buildPlayerNav();

            char[] options = new char[4];
            options[0] = 'a';
            options[1] = 'b';

            Console.WriteLine("a) Hit");
            Console.WriteLine("b) Stand");

            //If there is a split case or double down, take care of it here
            if(GameCharacters.player.blackJackHand[0].CardType == GameCharacters.player.blackJackHand[1].CardType)
            {
                Console.WriteLine("c) Split");
                options[2] = 'c';
                //call split function here
            }

            Console.Write("> ");

            char playerChoice = Console.ReadKey().KeyChar;

            Helper.checkInput(ref playerChoice, options);


        }

        static void endGame()
        {
            Helper.buildPlayerNav();
            Console.WriteLine("Press any key to flip dealer's card.");
            Console.ReadKey();
            Console.SetCursorPosition(GameCharacters.Norm.handStartPos.X, GameCharacters.Norm.handStartPos.Y);
            GameCharacters.Norm.blackJackHand[0].printCardFaceUp();
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

            //set the start position of the player's cards
            blackJackPlayer.handStartPos.setCoords(handStartPosX, handStartPosY);

            //set the current position of the player's cards to the start position
            blackJackPlayer.handCurrPos = blackJackPlayer.handStartPos;
        }

    }
}
