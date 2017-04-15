using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    public class BlackJack
    {
        List<NPC> blackJackPlayers = new List<NPC>();
        List<Card> dealerHand = new List<Card>();
        List<Card> playerHand = new List<Card>();

        void play()
        {
            blackJackPlayers.Add(new Tournament_Fighter.NPC("Dealer", PlayerType.Villager));
        }

        void deal()
        {
            foreach(NPC player in blackJackPlayers)
            {
                playerHand.Add(BlackJackDeck.deck.drawTopCard());
                dealerHand.Add(BlackJackDeck.deck.drawTopCard());
                playerHand.Add(BlackJackDeck.deck.drawTopCard());
            }
        }
    }
}
