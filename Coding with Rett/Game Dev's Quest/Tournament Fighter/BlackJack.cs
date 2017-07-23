using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
//using System.Timers;


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
            //used for testing
            GameCharacters.player.Name = "Rett";
            GameCharacters.player.Gold = 15;

            //make sure they have enough gold to play
            if (GameCharacters.player.Gold <= 0)
            {
                Helper.printCleanUI();
                Console.Write("You don't have enough money to play Black Jack, you filthy beggar!");
                Console.SetCursorPosition(0, 20);
                Console.Write("To leave the table press any key...");
                Console.ReadKey();
                //return to previous game state (the tavern?)
            }
            else
            {
                char continuePlay = 'y';
                //initialize the dealer, Norm, with card positions at the middle of the console and down 4 units. - 2 is used to help center with name
                initBlackJackPlayer(GameCharacters.Norm, (GameConstants.WINDOW_WIDTH / 2) - 2,
                    Console.WindowTop + 4, GameCharacters.Norm.Name.Length + GameCharacters.Norm.Occupation.Length, GameCharacters.Norm.Occupation.Length / 2, 0);

                //initialize the player with card positions at the middle of the screen and down 16 units. -2 is used to help center with name
                initBlackJackPlayer(GameCharacters.player, (GameConstants.WINDOW_WIDTH / 2) - 2, 16, 0, 0, 2);

                //game loop should go here
                while (continuePlay == 'y' || continuePlay == 'Y')
                {
                    //print a clean UI
                    Helper.printCleanUI();

                    //print the player's names
                    printPlayerName(GameCharacters.Norm);
                    printPlayerName(GameCharacters.player);

                    //make bets
                    placeBets();

                    //call Deal
                    deal();

                    //check for blackjacks
                    if (GameCharacters.player.blackJackHand.CheckForBlackJack() || GameCharacters.Norm.blackJackHand.CheckForBlackJack())
                    {
                        dealtABlackJack();
                    }
                    else
                    {
                        doTurns();
                    }

                    //check to play again
                    playAgain(ref continuePlay);
                }
            }
        }

        /// <summary>
        /// Checks if the player wants to play again and clears hand
        /// </summary>
        /// <param name="continuePlay"></param>
        static void playAgain(ref char continuePlay)
        {
            //clear the player input lines
            Helper.ClearLine(0, 20);
            Helper.ClearLine(0, 21);
            Helper.ClearLine(0, 22);
            Helper.ClearLine(0, 23);
            Helper.ClearLine(0, 24);
            Helper.ClearLine(0, 25);
            Helper.ClearLine(0, 26);

            //set the position to a good place
            Console.SetCursorPosition(0, 20);

            //prompt to play again and get the user's input
            Console.Write("Play Again? (y/n)");
            continuePlay = Console.ReadKey().KeyChar;

            //check the user's input
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Helper.checkInput(ref continuePlay, new char[] { 'y', 'Y', 'n', 'Y' });

            //loop through all players and clear their hands
            foreach(NPC player in blackJackPlayers)
            {
                player.blackJackHand.clearHand();
            }
        }

        /// <summary>
        /// Player places bet and gold reflects that bet
        /// </summary>
        static void placeBets()
        {
            //used to check if user input is a number
            bool checkNumWorked = false;

            //gets the bet of the player
            int bet = GameCharacters.player.blackJackHand.Bet;

            //move cursor position to user input section
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Place your bet!");
            Console.Write("> ");

            //try to parse the user input and set value of checkNumWorked based off of whether or not it succeeded
            checkNumWorked = Int32.TryParse(Console.ReadLine(), out bet);

            //while the bet is an incorrect number
            while (checkNumWorked == false || bet > GameCharacters.player.Gold || bet < 1)
            {
                //move cursor position back up to prompt line
                Console.SetCursorPosition(0, Console.CursorTop - 1);

                //clear the line and write the error message the get user input and try parse again
                Helper.ClearLine(0, Console.CursorTop);
                Console.Write("Please pick a number between 1 and " + GameCharacters.player.Gold + " > ");
                checkNumWorked = Int32.TryParse(Console.ReadLine(), out bet);
            }

            //reassign the bet to blackjackhand bet so it can be used later then subtract bet from gold
            GameCharacters.player.blackJackHand.Bet = bet;
            GameCharacters.player.Gold -= bet;

            //reprint UI
            Helper.printCleanUI();

            //print the player's names
            printPlayerName(GameCharacters.Norm);
            printPlayerName(GameCharacters.player);
        }

        /// <summary>
        /// Deals the first two cards to the players
        /// </summary>
        static void deal()
        {

            //GameCharacters.player.blackJackHand.addCardToHand(new Card(Suit.Clubs, Cards.Ace), GameCharacters.player.Name.Length, true, true);
            //GameCharacters.Norm.blackJackHand.addCardToHand(new Card(Suit.Spades, Cards.Ace), GameCharacters.Norm.Name.Length, true, true);
            //GameCharacters.Norm.blackJackHand.addCardToHand(new Card(Suit.Spades, Cards.Jack), GameCharacters.Norm.Name.Length, true, true);
            //GameCharacters.player.blackJackHand.addCardToHand(new Card(Suit.Clubs, Cards.Seven), GameCharacters.player.Name.Length, true, true);
            dealCard(GameCharacters.player, true, true);
            dealCard(GameCharacters.Norm, false, false);

            //GameCharacters.Norm.blackJackHand.addCardToHand(new Card(Suit.Spades, Cards.Five), GameCharacters.Norm.Name.Length, true, true);
            //GameCharacters.player.blackJackHand.addCardToHand(new Card(Suit.Clubs, Cards.King), GameCharacters.player.Name.Length, true, true);
            //GameCharacters.player.blackJackHand.addCardToHand(new Card(Suit.Clubs, Cards.Queen), GameCharacters.player.Name.Length, true, true);
            //GameCharacters.Norm.blackJackHand.addCardToHand(new Card(Suit.Diamonds, Cards.Queen), GameCharacters.Norm.Name.Length, true, true);
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
        /// Carries out functionality if there is a blackjack
        /// </summary>
        static void dealtABlackJack()
        {
            //if the player has a blackjack, they win
            if (GameCharacters.player.blackJackHand.BlackJack)
            {
                //print the winner status
                printWinnerStatus(GameCharacters.player);

                //calculate winnings
                calculateWinnings();
            }
            else if (GameCharacters.Norm.blackJackHand.BlackJack && GameCharacters.player.blackJackHand.BlackJack == false)
            {
                Thread.Sleep(1000); //research timers instead
                Debug.WriteLine("Norm has a blackjack");
                Console.SetCursorPosition(GameCharacters.Norm.blackJackHand.handStartPos.X, GameCharacters.Norm.blackJackHand.handStartPos.Y);
                GameCharacters.Norm.blackJackHand.hand[0].printCardFaceUp();
                printLoserStatus(GameCharacters.player);
            }
        }

        /// <summary>
        /// Carries out player turns
        /// </summary>
        static void doTurns()
        {
            bool playerBusted = playersTurn();
            bool dealerBusted = false;
            //play turns
            if (playerBusted == false)
            {
                dealerBusted = dealersTurn();
            }

            Debug.WriteLine("DealerBusted: " + dealerBusted);

            //check for winner
            checkWinner(playerBusted, dealerBusted);
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

        /// <summary>
        /// Goes through the steps to playout the player's turn
        /// </summary>
        static bool playersTurn()
        {
            //shorthand for player
            NPC player = GameCharacters.player;

            //gets cursor down to bottom frame
            Helper.buildPlayerNav();

            //blank player choice
            char playerChoice = ' ';

            //possible options for the player
            char[] options = new char[4];
            options[0] = 'a';
            options[1] = 'b';
            options[2] = 'c';

            //show chosen bet amount
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Bet: " + player.blackJackHand.Bet);
            Console.ForegroundColor = ConsoleColor.Gray;

            //print options
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

            //prompt user for input
            Console.Write("> ");

            //store the current cursor position in console coordinate
            consoleCoords playerInputPos = new consoleCoords(Console.CursorLeft, Console.CursorTop);


            while (!player.blackJackHand.Busted && !player.blackJackHand.BlackJack && playerChoice != 'b')
            {
                Console.SetCursorPosition(playerInputPos.X, playerInputPos.Y);
                Helper.ClearLine(0, playerInputPos.Y);
                Console.Write("> ");
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
                        player.blackJackHand.Bet *= 2;
                        printStatus(player.blackJackHand, "Doubled Down");
                        GameCharacters.player.blackJackHand.addCardToHand(BlackJackDeck.deck.drawTopCard(), player.Name.Length, true, true);
                        player.blackJackHand.DoubledDown = true;
                        //check for a bust
                        if (player.blackJackHand.isBust())
                        {
                            return true;
                        }
                        break;
                    }
                    //check for a bust
                    if (player.blackJackHand.isBust())
                    {
                        return true;
                    }
                }
            }

            //this means we haven't busted
            return false;
        }

        /// <summary>
        /// plays out the dealer's turn automatically
        /// </summary>
        static bool dealersTurn()
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

            //Norm must hit on a hand value lower than 17
            while (norm.blackJackHand.HandValue < 17)
            {
                Thread.Sleep(1000);
                printStatus(norm.blackJackHand, "Hit");
                dealCard(norm, true, true);
            }

            //If Norm didn't bust, print stay and return false
            if (!norm.blackJackHand.isBust())
            {
                printStatus(norm.blackJackHand, "Stay");
                return false;
            }
            //otherwise he busted so return true
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Prints the status of whether the player has hit or stood
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="status"></param>
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
            if(status == "Doubled Down")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            Console.Write(status);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Checks to see who has won their hand
        /// </summary>
        /// <param name="busted">Used to check if the hand is over 21</param>
        static void checkWinner(bool playerBusted, bool dealerBusted)
        {
            //if player has a higher hand value
            if((GameCharacters.player.blackJackHand.HandValue > GameCharacters.Norm.blackJackHand.HandValue && playerBusted == false) || dealerBusted)
            {
                printWinnerStatus(GameCharacters.player);
                calculateWinnings();
            }
            //if the player and Norm have the same hand value, print push
            else if(GameCharacters.player.blackJackHand.HandValue == GameCharacters.Norm.blackJackHand.HandValue && playerBusted == false)
            {
                printPushStatus(GameCharacters.player);
                GameCharacters.player.Gold += GameCharacters.player.blackJackHand.Bet;
            }
            else
            {
                printLoserStatus(GameCharacters.player);
            }
        }

        /// <summary>
        /// prints the win message for the given player at the correct status position
        /// </summary>
        /// <param name="player"></param>
        static void printWinnerStatus(NPC player)
        {
            Console.SetCursorPosition(player.blackJackHand.statusPos.X, player.blackJackHand.statusPos.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Winner!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// if the values of the hands are the same it is a push (or a tie)
        /// </summary>
        /// <param name="player"></param>
        static void printPushStatus(NPC player)
        {
            Console.SetCursorPosition(player.blackJackHand.statusPos.X, player.blackJackHand.statusPos.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Push.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// prints the lose message for the given player at the correct status position
        /// </summary>
        /// <param name="player"></param>
        static void printLoserStatus(NPC player)
        {
            Console.SetCursorPosition(player.blackJackHand.statusPos.X, player.blackJackHand.statusPos.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Loser!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void calculateWinnings()
        {
            //if the player hit a black jack give them 1.5 times their bet
            if (GameCharacters.player.blackJackHand.BlackJack)
            {
                GameCharacters.player.Gold += ((GameCharacters.player.blackJackHand.Bet * 3) / 2) + GameCharacters.player.blackJackHand.Bet;
            }
            //otherwise, give them their twice their bet
            else
            {
                GameCharacters.player.Gold += GameCharacters.player.blackJackHand.Bet * 2;
            }

            //update the nav
            Helper.buildPlayerNav();
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
        public int numAcesValuedEleven;

        //keeps track of if the hand has busted
        public bool Busted { get; set; }

        //keeps track of if the hand is a blackjack
        public bool BlackJack { get; set; }

        //coordinates of the first card's position
        public consoleCoords handStartPos;

        //keeps track of the position of the current card
        public consoleCoords handCurrPos;

        //keeps track of the name's coordinate position
        public consoleCoords namePos;

        //keeps track of the distance between the name of the player and the score
        public int gapFromNamePosToScorePos { get; set; }

        //keeps track of the coordinates of the hand's score
        public consoleCoords scorePos;

        //keeps track of the coordinates of the status (hit, stand, win, lose, etc.)
        public consoleCoords statusPos;

        //keeps track of the bet for that had
        public int Bet { get; set; }


        /// <summary>
        /// Default contructor. Creats an empty list of cards and sets default values
        /// </summary>
        public BlackJackHand()
        {
            hand = new List<Card>();
            handStartPos = new consoleCoords(0, 0);
            namePos = new consoleCoords(0, 0);
            statusPos = new consoleCoords(0, 0);
            gapFromNamePosToScorePos = 0;
            clearHand();
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

            //Print card name to debug log
            Debug.WriteLine(card.CardName);

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

            if(printUpdatedScore)
            {
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

        /// <summary>
        /// Removes all cards in the hand and sets the other values to defaults
        /// </summary>
        public void clearHand()
        {
            //puts our used cards back in the deck
            foreach(Card card in hand)
            {
                //if the card is an ace, set its value back to 11
                if(card.CardName == "A")
                {
                    card.Value = 11;
                }
                BlackJackDeck.deck.deck.Add(card);
            }

            //clears the hand
            hand.Clear();

            //sets other properties back to default
            handCurrPos = handStartPos;
            HandValue = 0;
            DoubledDown = false;
            Busted = false;
            BlackJack = false;
            Bet = 0;
            numAcesValuedEleven = 0;
        }
    }
}
