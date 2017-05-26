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

        static public void play()
        {
            blackJackPlayers.Add(GameCharacters.Norm);
            blackJackPlayers.Add(GameCharacters.player);

            //Set the dealer's (Norm) starting card position to the middle of the console window and
            //down 4 from the top
            GameCharacters.Norm.handStartPos.setCoords((GameConstants.WINDOW_WIDTH / 2) - 2, Console.WindowTop + 4);

            //Sets the current hand position equal to the start position since we haven't dealt any cards
            GameCharacters.Norm.handCurrPos = GameCharacters.Norm.handStartPos;

            GameCharacters.player.handStartPos.setCoords((GameConstants.WINDOW_WIDTH / 2) - 2, 16);
            GameCharacters.player.handCurrPos = GameCharacters.player.handStartPos;

            deal();

        }

        static void deal()
        {
            //foreach(NPC cardPlayer in blackJackPlayers)
            //{
            GameCharacters.player.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
            updatePlayerCardPos(GameCharacters.player);
            GameCharacters.Norm.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
            updatePlayerCardPos(GameCharacters.Norm);


            GameCharacters.player.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
            updatePlayerCardPos(GameCharacters.player);
            GameCharacters.Norm.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
            updatePlayerCardPos(GameCharacters.Norm);
            //}
            printNewDeal();
        }

        static void printNewDeal()
        {
            Helper.printCleanUI();

            for(int i = 0; i < blackJackPlayers.Count; i++)
            {
                if (blackJackPlayers[i] == GameCharacters.Norm)
                {
                    string normsTitle = GameCharacters.Norm.Occupation + " - " + GameCharacters.Norm.Name;
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - (normsTitle.Length / 2),
                                               GameCharacters.Norm.handCurrPos.Y - 1);
                    Console.WriteLine(normsTitle);
                    Console.SetCursorPosition(GameCharacters.Norm.handCurrPos.X, GameCharacters.Norm.handCurrPos.Y);

                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            GameCharacters.Norm.blackJackHand[j].printCardFaceDown();
                        }
                        else
                        {
                            GameCharacters.Norm.blackJackHand[j].printCardFaceUp();
                        }
                    }
                }
                if (blackJackPlayers[i] == GameCharacters.player)
                {
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - (GameCharacters.player.Name.Length / 2),
                                               GameCharacters.player.handCurrPos.Y - 1);
                    Console.WriteLine(GameCharacters.player.Name);
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - 2, GameCharacters.player.handCurrPos.Y);


                    for (int j = 0; j < 2; j++)
                    {
                        GameCharacters.player.blackJackHand[j].printCardFaceUp();
                    }
                }
            }

        }

        static void updatePlayerCardPos(NPC currentPlayer)
        {
            //gets the last card dealt to the player
            Card lastCard = currentPlayer.blackJackHand[currentPlayer.blackJackHand.Count - 1];
            if(lastCard.Value == 10)
            {
                currentPlayer.handCurrPos.X += 3;
            }
            else
            {
                currentPlayer.handCurrPos.X += 2;
            }
        }

        static void endGame()
        {
            Helper.buildPlayerNav();
            Console.WriteLine("Press any key to flip dealer's card.");
            Console.ReadKey();
            Console.SetCursorPosition(GameCharacters.Norm.handStartPos.X, GameCharacters.Norm.handStartPos.Y);
            GameCharacters.Norm.blackJackHand[0].printCardFaceUp();
        }
    }
}
