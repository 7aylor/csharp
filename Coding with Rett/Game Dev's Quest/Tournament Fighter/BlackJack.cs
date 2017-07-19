using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace Tournament_Fighter
{
    //make constants to keep track of choice positions on the console

    public static class BlackJack
    {
        //list that keeps track of the players
        static List<NPC> blackJackPlayers = new List<NPC>();

        /// <summary>
        /// Starts the game of blackjack. Called from another method to begin the game
        /// </summary>
        static public void play()
        {

            GameCharacters.player.Name = "Testing the name!";
            GameCharacters.player.Gold = 50;

            //initialize the dealer, Norm, with card positions at the middle of the console and down 4 units. - 2 is used to help center with name
            initBlackJackPlayer(GameCharacters.Norm, (GameConstants.WINDOW_WIDTH / 2) - 2, 
                Console.WindowTop + 4, GameCharacters.Norm.Name.Length + GameCharacters.Norm.Occupation.Length, GameCharacters.Norm.Occupation.Length / 2, 0);

            //initialize the player with card positions at the middle of the screen and down 16 units. -2 is used to help center with name
            initBlackJackPlayer(GameCharacters.player, (GameConstants.WINDOW_WIDTH / 2) - 2, 16, 0, 0, 2);

            //game loop should go here

            //print a clean UI
            Helper.printCleanUI();

            //print the player's names
            printPlayerName(GameCharacters.Norm);
            printPlayerName(GameCharacters.player);

            //make bets
            placeBets();

            //call Deal
            deal();

            //play turns
            playersTurn();
            dealersTurn();

            //check for winner

            //check to play again
        }

        static void placeBets()
        {
            bool checkNumWorked = false;
            int bet = GameCharacters.player.blackJackHand.Bet;
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Place your bet!");
            Console.Write("> ");
            checkNumWorked = Int32.TryParse(Console.ReadLine(), out bet);

            while (checkNumWorked == false || bet > GameCharacters.player.Gold || bet < 1)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Helper.ClearLine(0, Console.CursorTop);
                Console.Write("Please pick a number between 1 and " + GameCharacters.player.Gold + " > ");
                checkNumWorked = Int32.TryParse(Console.ReadLine(), out bet);
            }

            GameCharacters.player.blackJackHand.Bet = bet;
            GameCharacters.player.Gold -= bet;
            Helper.buildPlayerNav();
        }

        /// <summary>
        /// Deals the first two cards to the players
        /// </summary>
        static void deal()
        {

            //GameCharacters.player.blackJackHand.addCardToHand(new Card(Suit.Clubs, Cards.Ace), GameCharacters.player.Name.Length, true);
            dealCard(GameCharacters.player, true, true);
            dealCard(GameCharacters.Norm, false, false); //////change this to false false

            //GameCharacters.player.blackJackHand.addCardToHand(new Card(Suit.Clubs, Cards.Queen), GameCharacters.player.Name.Length, true);
            dealCard(GameCharacters.player, true, true);
            dealCard(GameCharacters.Norm, true, false);
        }

        /// <summary>
        /// Adds a card to a player's hand and updates the current card position
        /// </summary>
        /// <param name="blackJackPlayer"></param>
        /// <param name="printFaceUp"></param>
        /// <param name="updateScore"></param>
        static void dealCard(NPC blackJackPlayer, bool printFaceUp, bool updateScore)
        {
            blackJackPlayer.blackJackHand.addCardToHand(BlackJackDeck.deck.drawTopCard(), blackJackPlayer.Name.Length, printFaceUp, updateScore);
        }

        /// <summary>
        /// Prints the deal, dealer has one card face down and player doesn't
        /// </summary>
        static void printPlayerName(NPC blackJackPlayer)
        {
            //if the player is the dealer
            if (blackJackPlayer == GameCharacters.Norm)
            {
                //build the string to hold Norm's Title in the play screen
                string normsTitle = GameCharacters.Norm.Occupation + " - " + GameCharacters.Norm.Name;
                    
                //print Dealer - Norm and set the correction positions
                Console.SetCursorPosition(GameCharacters.Norm.blackJackHand.namePos.X, GameCharacters.Norm.blackJackHand.namePos.Y);
                Console.WriteLine(normsTitle);
                Console.SetCursorPosition(GameCharacters.Norm.blackJackHand.handCurrPos.X, GameCharacters.Norm.blackJackHand.handCurrPos.Y);
            }
            //if the player is the player of the game
            if (blackJackPlayer == GameCharacters.player)
            {
                Console.SetCursorPosition(GameCharacters.player.blackJackHand.namePos.X, GameCharacters.player.blackJackHand.namePos.Y);
                Console.WriteLine(GameCharacters.player.Name);
                Console.SetCursorPosition(GameCharacters.player.blackJackHand.handCurrPos.X, GameCharacters.player.blackJackHand.handCurrPos.Y);
            }
        }

        static void playersTurn()
        {
            NPC player = GameCharacters.player;
            Helper.buildPlayerNav();
            char playerChoice = ' ';

            char[] options = new char[4];
            options[0] = 'a';
            options[1] = 'b';
            options[2] = 'c';

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Bet: " + player.blackJackHand.Bet);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("a) Hit");
            Console.WriteLine("b) Stand");
            Console.WriteLine("c) Double Down");

            //If there is a split case or double down, take care of it here
            if(player.blackJackHand.hand[0].CardName == player.blackJackHand.hand[1].CardName)
            {
                Console.WriteLine("d) Split");
                options[2] = 'd';
                //call split function here
            }

            Console.Write("> ");

            while (!player.blackJackHand.Busted && !player.blackJackHand.BlackJack && playerChoice != 'b')
            {
                if (player.blackJackHand.HandValue <= 21)
                {
                    playerChoice = Console.ReadKey().KeyChar;

                    Helper.checkInput(ref playerChoice, options);

                    if (playerChoice == 'a')
                    {
                        printStatus(player.blackJackHand, "Hit");
                        GameCharacters.player.blackJackHand.addCardToHand(BlackJackDeck.deck.drawTopCard(), player.Name.Length, true, true);
                    }
                    else if(playerChoice == 'b')
                    {
                        printStatus(player.blackJackHand, "Stay");
                        Console.SetCursorPosition(player.blackJackHand.statusPos.X, player.blackJackHand.statusPos.Y);
                    }
                    else if(playerChoice == 'c')
                    {
                        //deal with double down logic
                        //need to remove the option if player hits, and breaks the loop if they double down
                        //also need to double their bet
                    }
                }
            }
        }

        /// <summary>
        /// plays out the dealer's turn automatically
        /// </summary>
        static void dealersTurn()
        {
            //holds the norm object (shorter to type)
            NPC norm = GameCharacters.Norm;

            //pause for 1 second
            Thread.Sleep(1000);

            //print the first card faceup and set the cursor position back to current card position
            Console.SetCursorPosition(norm.blackJackHand.handStartPos.X, norm.blackJackHand.handStartPos.Y);
            norm.blackJackHand.hand[0].printCardFaceUp();
            Console.SetCursorPosition(norm.blackJackHand.handCurrPos.X, norm.blackJackHand.handCurrPos.Y);

            norm.blackJackHand.printUpdatedHandValue(norm.Name.Length);

            while (norm.blackJackHand.HandValue < 17)
            {
                Thread.Sleep(1000);
                printStatus(norm.blackJackHand, "Hit");
                dealCard(norm, true, true);
            }

            if (!norm.blackJackHand.isBust())
            {
                printStatus(norm.blackJackHand, "Stay");
            }
        }

        static void printStatus(BlackJackHand hand, string status)
        {
            Console.SetCursorPosition(hand.statusPos.X, hand.statusPos.Y);

            if(status == "Hit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if(status == "Stay")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.Write(status);
            Console.ForegroundColor = ConsoleColor.Gray;
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
        /// Creates the blackjack player and initializes all of the console coordinates
        /// </summary>
        /// <param name="blackJackPlayer">Black Jack Player</param>
        /// <param name="handStartPosX">Start position of hand in the X position</param>
        /// <param name="handStartPosY">Start position of hand in the Y position</param>
        /// <param name="nameGap">The gap between the name and the score start positions</param>
        /// <param name="occupationOffset">In the case that an occupation is used in the title, uses this to adjust score position</param>
        /// <param name="nameStartOffset">Used to offset the name in case its start position is off</param>
        static void initBlackJackPlayer(NPC blackJackPlayer, int handStartPosX, int handStartPosY, int nameGap, int occupationOffset, int nameStartOffset)
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
            int nameX = (GameConstants.WINDOW_WIDTH / 2) - (blackJackPlayer.Name.Length / 2) - occupationOffset - nameStartOffset;

            //sets the name position y to 1 above current position in the console, ie one position above the hand
            int nameY = blackJackPlayer.blackJackHand.handStartPos.Y - 1;
            blackJackPlayer.blackJackHand.namePos.setCoords(nameX, nameY);

            //sets the gap between the name and score
            blackJackPlayer.blackJackHand.gapFromNamePosToScorePos = nameGap;

            //set the status Position
            blackJackPlayer.blackJackHand.statusPos.setCoords(blackJackPlayer.blackJackHand.namePos.X + 
                                                            (blackJackPlayer.Name.Length / 2) + occupationOffset, nameY - 1);
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

        //keeps track of if the hand has busted
        public bool Busted { get; set; }

        //keeps track of if the hand is a blackjack
        public bool BlackJack { get; set; }

        //coordinates of the start and current hand positions
        public consoleCoords handStartPos;
        public consoleCoords handCurrPos;
        public consoleCoords namePos;
        public int gapFromNamePosToScorePos { get; set; }
        public consoleCoords scorePos;
        public consoleCoords statusPos;

        public int Bet { get; set; }


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
            BlackJack = false;
            statusPos = new consoleCoords(0, 0);
            Bet = 0;
        }

        /// <summary>
        /// Adds a card to the hand, updates card value and prints it
        /// </summary>
        /// <param name="card"></param>
        /// <param name="nameLength"></param>
        /// <param name="printFaceUp"></param>
        /// <param name="printUpdatedScore"></param>
        public void addCardToHand(Card card, int nameLength, bool printFaceUp, bool printUpdatedScore)
        {
            if(card.CardName == "A")
            {
                numAcesValuedEleven++;
            }

            //add new card to hand
            hand.Add(card);

            //update the card value
            HandValue += card.Value;


            //set the cursor position to print the new card
            Console.SetCursorPosition(handCurrPos.X, handCurrPos.Y);

            //if we want to print face up
            if (printFaceUp)
            {
                //print it face up
                card.printCardFaceUp();
            }
            else
            {
                //otherwise, facedown
                card.printCardFaceDown();
            }

            //update the card position
            updatePlayerCardPos();

            //check for a bust
            Busted = isBust();

            Debug.WriteLine("added card");

            if(printUpdatedScore)
            {
                Debug.WriteLine("Called print score");
                //if hand hasn't busted
                if (!Busted)
                {
                    //print the new score
                    printUpdatedHandValue(nameLength);
                    BlackJack = CheckForBlackJack();

                    if (BlackJack == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" Black Jack!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                //if hand has busted
                else
                {
                    //print the score and BUSTED
                    printUpdatedHandValue(nameLength);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" BUSTED");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        /// <summary>
        /// Checks hand value to see if it's more than 21. Adjust the Ace value if needed
        /// </summary>
        /// <returns></returns>
        public bool isBust()
        {

            //if there are no aces in the hand using value 11 and hand value is greater than 21
            if (HandValue > 21 && numAcesValuedEleven == 0)
            {
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
                        //make its value 1 and break out of the loop
                        card.Value = 1;

                        //subtract 10 from handvalue
                        HandValue -= 10;

                        //decrease number of aces with value 11
                        numAcesValuedEleven--;

                        //break the loop
                        break;
                    }
                }

                //we haven't busted
                return false;
            }
            else
            {
                //we don't have a value greater than 21
                return false;
            }
        }

        /// <summary>
        /// Checks to see if after a deal the hand is a blackjack
        /// </summary>
        /// <returns>returns if there is a blackjack or not</returns>
        public bool CheckForBlackJack()
        {
            if (hand.Count == 2 && HandValue == 21)
            {
                return true;
            }
            return false;
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

        /// <summary>
        /// Prints the updated Score of the hand
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void printUpdatedHandValue(int nameLength)
        {
            
            Console.SetCursorPosition(namePos.X + nameLength + gapFromNamePosToScorePos, namePos.Y);
            Console.Write(" - " + HandValue);
        }

    }
}
