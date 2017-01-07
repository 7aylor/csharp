using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XnaCards;

namespace ProgrammingAssignment6
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WindowWidth = 800;
        const int WindowHeight = 600;

        // max valid blockjuck score for a hand
        const int MaxHandValue = 21;

        // deck and hands
        Deck deck;
        List<Card> dealerHand = new List<Card>();
        List<Card> playerHand = new List<Card>();

        // hand placement
        const int TopCardOffset = 100;
        const int HorizontalCardOffset = 150;
        const int VerticalCardSpacing = 125;

        // messages
        SpriteFont messageFont;
        const string ScoreMessagePrefix = "Score: ";
        Message playerScoreMessage;
        Message dealerScoreMessage;
        Message winnerMessage;
		List<Message> messages = new List<Message>();

        // message placement
        const int ScoreMessageTopOffset = 25;
        const int HorizontalMessageOffset = HorizontalCardOffset;
        Vector2 winnerMessageLocation = new Vector2(WindowWidth / 2,
            WindowHeight / 2);

        // menu buttons
        Texture2D quitButtonSprite;
        List<MenuButton> menuButtons = new List<MenuButton>();

        // menu button placement
        const int TopMenuButtonOffset = TopCardOffset;
        const int QuitMenuButtonOffset = WindowHeight - TopCardOffset;
        const int HorizontalMenuButtonOffset = WindowWidth / 2;
        const int VerticalMenuButtonSpacing = 125;

        // use to detect hand over when player and dealer didn't hit
        bool playerHit = false;
        bool dealerHit = false;

        // game state tracking
        static GameState currentState = GameState.WaitingForPlayer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set resolution and show mouse
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.PreferredBackBufferWidth = WindowWidth;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // create and shuffle deck
            deck = new Deck(Content, 0, 0);
            deck.Shuffle();
            

            // first player card
            playerHand.Add(deck.TakeTopCard());
            playerHand[0].X = HorizontalCardOffset;
            playerHand[0].Y = TopCardOffset;
            playerHand[0].FlipOver();

            // first dealer card
            dealerHand.Add(deck.TakeTopCard());
            dealerHand[0].X = WindowWidth - HorizontalCardOffset;
            dealerHand[0].Y = TopCardOffset;

            // second player card
            playerHand.Add(deck.TakeTopCard());
            playerHand[1].X = HorizontalCardOffset;
            playerHand[1].Y = TopCardOffset + VerticalCardSpacing;
            playerHand[1].FlipOver();

            // second dealer card
            dealerHand.Add(deck.TakeTopCard());
            dealerHand[1].X = WindowWidth - HorizontalCardOffset;
            dealerHand[1].Y = TopCardOffset + VerticalCardSpacing;
            dealerHand[1].FlipOver();

            // load sprite font, create message for player score and add to list
            messageFont = Content.Load<SpriteFont>(@"fonts\Arial24");
            playerScoreMessage = new Message(ScoreMessagePrefix + GetBlockjuckScore(playerHand).ToString(),
                messageFont,
                new Vector2(HorizontalMessageOffset, ScoreMessageTopOffset));
            messages.Add(playerScoreMessage);

            // load quit button sprite for later use
            quitButtonSprite = Content.Load<Texture2D>(@"graphics\quitbutton");

            // create hit button and add to list
            menuButtons.Add(new MenuButton(Content.Load<Texture2D>(@"graphics\hitbutton"), 
                            new Vector2((float)WindowWidth/2, (float)TopCardOffset), GameState.PlayerHitting));

            // create stand button and add to list
            menuButtons.Add(new MenuButton(Content.Load<Texture2D>(@"graphics\standbutton"),
                            new Vector2((float)WindowWidth / 2, (float)(TopCardOffset + VerticalCardSpacing)), 
                            GameState.WaitingForDealer));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouse = Mouse.GetState();

            // update menu buttons as appropriate
            if(currentState == GameState.WaitingForPlayer || currentState == GameState.DisplayingHandResults)
            {
                foreach (MenuButton button in menuButtons)
                {
                    button.Update(mouse);
                }
            }

            // game state-specific processing
            switch (currentState)
            {
                //player hitting
                case (GameState.PlayerHitting):
                    //take the top card and position it properly
                    playerHand.Add(deck.TakeTopCard());

                    //if there are more than 4 player cards, create a fourth row
                    if (playerHand.Count > 4)
                    {
                        playerHand[playerHand.Count - 1].X = HorizontalCardOffset + ((playerHand.Count - 5) * 100);
                        playerHand[playerHand.Count - 1].Y = (VerticalCardSpacing * 3) + TopCardOffset;
                    }
                    //otherwise, use the third row
                    else
                    {
                        playerHand[playerHand.Count - 1].X = HorizontalCardOffset + ((playerHand.Count - 3) * 100);
                        playerHand[playerHand.Count - 1].Y = (VerticalCardSpacing * 2) + TopCardOffset;
                    }

                    //flip the card over
                    playerHand[playerHand.Count - 1].FlipOver();

                    //get their new score and print it
                    playerScoreMessage.Text = ScoreMessagePrefix + GetBlockjuckScore(playerHand).ToString();

                    //set player hit to True
                    playerHit = true;

                    //change game state
                    ChangeState(GameState.WaitingForDealer);
                    break;

                //Waiting for dealer to choose
                case (GameState.WaitingForDealer):
                    //get the current dealerscore
                    int dealerScore = GetBlockjuckScore(dealerHand);

                    //if the dealer has less than 17, dealer must hit, otherwise, get the results
                    if (dealerScore < 17)
                    {
                        ChangeState(GameState.DealerHitting);
                    }
                    else
                    {
                        ChangeState(GameState.CheckingHandOver);
                    }
                    break;

                //dealer hitting
                case (GameState.DealerHitting):
                    //take the top card and position it properly
                    dealerHand.Add(deck.TakeTopCard());

                    //if there are more than 4 player cards, create a fourth row
                    if (dealerHand.Count > 4)
                    {
                        dealerHand[dealerHand.Count - 1].X = WindowWidth - HorizontalCardOffset - ((dealerHand.Count - 5) * 100);
                        dealerHand[dealerHand.Count - 1].Y = (VerticalCardSpacing * 3) + TopCardOffset;
                    }
                    //otherwise, use the third row
                    else
                    {
                        dealerHand[dealerHand.Count - 1].X = WindowWidth - HorizontalCardOffset - ((dealerHand.Count - 3) * 100);
                        dealerHand[dealerHand.Count - 1].Y = (VerticalCardSpacing * 2) + TopCardOffset;
                    }
                    
                    //flip over the card
                    dealerHand[dealerHand.Count - 1].FlipOver();

                    //dealer hit is true
                    dealerHit = true;

                    //change game state
                    ChangeState(GameState.CheckingHandOver);
                    break;

                //checks the current state of the game
                case (GameState.CheckingHandOver):

                    //if both players stood or either or both players busted
                    if((playerHit == false && dealerHit == false) || 
                        (GetBlockjuckScore(playerHand) > MaxHandValue || GetBlockjuckScore(dealerHand) > MaxHandValue))
                    {
                        //string for winner message text
                        string winner;

                        //if both busted or they have the same score, its a tie
                        if((GetBlockjuckScore(playerHand) > MaxHandValue && GetBlockjuckScore(dealerHand) > MaxHandValue) ||
                            (GetBlockjuckScore(playerHand) == GetBlockjuckScore(dealerHand)))
                        {
                            winner = "It's a tie!";
                        }
                        //otherwise we have a winner
                        else
                        {
                            //if the player busted, or the dealer didn't bust and dealer has more than player, dealer won
                            if(GetBlockjuckScore(playerHand) > MaxHandValue || ((GetBlockjuckScore(playerHand) < GetBlockjuckScore(dealerHand))
                                && (GetBlockjuckScore(dealerHand) <= MaxHandValue)))
                            {
                                winner = "Dealer wins!";
                            }
                            //otherwise, player won
                            else
                            {
                                winner = "Player wins!";
                            }
                        }

                        //clear the buttons 
                        menuButtons.Clear();

                        //flip dealers first card
                        dealerHand[0].FlipOver();

                        //set up the dealers score message and add it to messages
                        dealerScoreMessage = new Message(ScoreMessagePrefix + GetBlockjuckScore(dealerHand).ToString(), messageFont,
                                              new Vector2(WindowWidth - HorizontalMessageOffset, ScoreMessageTopOffset));
                        messages.Add(dealerScoreMessage);

                        //create the quit button
                        menuButtons.Add(new MenuButton(quitButtonSprite, new Vector2(WindowWidth / 2, WindowHeight - TopMenuButtonOffset),
                                        GameState.Exiting));

                        //create the message and add it to messages
                        winnerMessage = new Message(winner, messageFont, new Vector2(WindowWidth / 2, (WindowHeight / 2 - 75)));
                        messages.Add(winnerMessage);

                        //change to displaying hand results
                        ChangeState(GameState.DisplayingHandResults);

                    }
                    else
                    {
                        //if the player chose to stand, only have the dealer choose
                        if (playerHit == false)
                        {
                            dealerHit = false;
                            ChangeState(GameState.WaitingForDealer);
                        }
                        //otherwise, let both choose
                        else
                        {
                            playerHit = false;
                            dealerHit = false;
                            ChangeState(GameState.WaitingForPlayer);
                        }                        
                    }
                    break;

                //exit the game
                case (GameState.Exiting):
                    Exit();
                    break;

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Goldenrod);
						
            spriteBatch.Begin();

            // draw hands
            foreach(Card card in playerHand)
            {
                card.Draw(spriteBatch);
            }
            foreach(Card card in dealerHand)
            {
                card.Draw(spriteBatch);
            }

            // draw messages
            foreach(Message message in messages)
            {
                message.Draw(spriteBatch);
            }


            // draw menu buttons
            foreach(MenuButton button in menuButtons)
            {
                button.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Calculates the Blockjuck score for the given hand
        /// </summary>
        /// <param name="hand">the hand</param>
        /// <returns>the Blockjuck score for the hand</returns>
        private int GetBlockjuckScore(List<Card> hand)
        {
            // add up score excluding Aces
            int numAces = 0;
            int score = 0;
            foreach (Card card in hand)
            {
                if (card.Rank != Rank.Ace)
                {
                    score += GetBlockjuckCardValue(card);
                }
                else
                {
                    numAces++;
                }
            }

            // if more than one ace, only one should ever be counted as 11
            if (numAces > 1)
            {
                // make all but the first ace count as 1
                score += numAces - 1;
                numAces = 1;
            }

            // if there's an Ace, score it the best way possible
            if (numAces > 0)
            {
                if (score + 11 <= MaxHandValue)
                {
                    // counting Ace as 11 doesn't bust
                    score += 11;
                }
                else
                {
                    // count Ace as 1
                    score++;
                }
            }

            return score;
        }

        /// <summary>
        /// Gets the Blockjuck value for the given card
        /// </summary>
        /// <param name="card">the card</param>
        /// <returns>the Blockjuck value for the card</returns>
        private int GetBlockjuckCardValue(Card card)
        {
            switch (card.Rank)
            {
                case Rank.Ace:
                    return 11;
                case Rank.King:
                case Rank.Queen:
                case Rank.Jack:
                case Rank.Ten:
                    return 10;
                case Rank.Nine:
                    return 9;
                case Rank.Eight:
                    return 8;
                case Rank.Seven:
                    return 7;
                case Rank.Six:
                    return 6;
                case Rank.Five:
                    return 5;
                case Rank.Four:
                    return 4;
                case Rank.Three:
                    return 3;
                case Rank.Two:
                    return 2;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Changes the state of the game
        /// </summary>
        /// <param name="newState">the new game state</param>
        public static void ChangeState(GameState newState)
        {
            currentState = newState;
        }
    }
}
