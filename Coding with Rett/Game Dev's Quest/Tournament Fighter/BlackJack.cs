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

            deal();

        }

        static void deal()
        {
            foreach(NPC cardPlayer in blackJackPlayers)
            {
                GameCharacters.player.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
                GameCharacters.Norm.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
                GameCharacters.player.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
                GameCharacters.Norm.blackJackHand.Add(BlackJackDeck.deck.drawTopCard());
            }
            printNewDeal();
        }

        static void printNewDeal()
        {
            Helper.printCleanUI();

            int normCardTopPos = Console.CursorTop + 1;

            for(int i = 0; i < blackJackPlayers.Count; i++)
            {
                if (blackJackPlayers[i] == GameCharacters.Norm)
                {
                    string normsTitle = GameCharacters.Norm.Occupation + " " + GameCharacters.Norm.Name;
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - (normsTitle.Length / 2), Console.CursorTop);
                    Console.WriteLine(normsTitle);
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - 2, normCardTopPos);

                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 1)
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
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - (GameCharacters.player.Name.Length / 2), 16);
                    Console.WriteLine(GameCharacters.player.Name);
                    Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2) - 2, 14);


                    for (int j = 0; j < 2; j++)
                    {
                        GameCharacters.player.blackJackHand[j].printCardFaceUp();
                    }
                }
            }

            Helper.buildPlayerNav();
            Console.WriteLine("Press any key to flip dealer's card.");
            Console.ReadKey();
            Console.SetCursorPosition((GameConstants.WINDOW_WIDTH / 2), normCardTopPos);
            GameCharacters.Norm.blackJackHand[1].printCardFaceUp();

        }
    }
}
