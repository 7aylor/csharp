using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MovingTeddyBears;

namespace BetterNAG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //instance variables for teddy bears
        TeddyBear bear0;
        TeddyBear bear1;
        TeddyBear bear2;

        public const int WindowWidth = 604;
        public const int WindowHeight = 453;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
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

            //create the teddy bear objects
            bear0 = new TeddyBear(Content, @"graphics\teddybear0",
                graphics.PreferredBackBufferWidth / 4,
                graphics.PreferredBackBufferHeight /4,
                WindowWidth, WindowHeight);
            bear1 = new TeddyBear(Content, @"graphics\teddybear1",
                graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2,
                WindowWidth, WindowHeight);
            bear2 = new TeddyBear(Content, @"graphics\teddybear2",
                graphics.PreferredBackBufferWidth * 3 / 4,
                graphics.PreferredBackBufferHeight * 3 / 4,
                WindowWidth, WindowHeight);
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

            //update the teddy bears
            bear0.Update();
            bear1.Update();
            bear2.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //draw the teddy bears
            spriteBatch.Begin();
            bear0.Draw(spriteBatch);
            bear1.Draw(spriteBatch);
            bear2.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
