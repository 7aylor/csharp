using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ExplodingTeddies;

namespace Lab10
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        const int WindowWidth = 800;
        const int WindowHeight = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TeddyBear bear0;
        TeddyBear bear1;
        Explosion explosion0;

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

            //vectors
            Vector2 vect0 = new Vector2(-1, 0);
            Vector2 vect1 = new Vector2(1, 0);

            //create teddy bears
            bear0 = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics\teddybear0", 200, 200, vect0);
            bear1 = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics\teddybear1", 0, 200, vect1);

            //create explosion
            explosion0 = new Explosion(Content, @"graphics\explosion");
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

            //update bears
            bear0.Update(gameTime);
            bear1.Update(gameTime);
            explosion0.Update(gameTime);

            if (bear0.Active && bear1.Active && bear0.DrawRectangle.X == (bear1.DrawRectangle.X + bear1.DrawRectangle.Width))
            {
                bear1.Active = false;
                bear0.Active = false;
                explosion0.Play(bear0.DrawRectangle.X, bear0.DrawRectangle.Height / 2 + bear0.DrawRectangle.Y);
            }
            if (bear0.Active && bear1.Active && bear1.DrawRectangle.X == (bear0.DrawRectangle.X + bear0.DrawRectangle.Width))
            {
                bear1.Active = false;
                bear0.Active = false;
                explosion0.Play(bear1.DrawRectangle.X, bear1.DrawRectangle.Height/2 + bear1.DrawRectangle.Y);
            }
            if (bear0.Active && bear1.Active && bear0.DrawRectangle.Y == (bear1.DrawRectangle.Y + bear1.DrawRectangle.Height))
            {
                bear1.Active = false;
                bear0.Active = false;
                explosion0.Play(bear0.DrawRectangle.X + bear0.DrawRectangle.Width / 2, bear0.DrawRectangle.Y);
            }
            if (bear0.Active && bear1.Active && bear1.DrawRectangle.Y == (bear0.DrawRectangle.Y + bear0.DrawRectangle.Height))
            {
                bear1.Active = false;
                bear0.Active = false;
                explosion0.Play(bear1.DrawRectangle.X + bear1.DrawRectangle.Width / 2, bear1.DrawRectangle.Y);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //draw bears
            spriteBatch.Begin();
            bear0.Draw(spriteBatch);
            bear1.Draw(spriteBatch);
            explosion0.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
