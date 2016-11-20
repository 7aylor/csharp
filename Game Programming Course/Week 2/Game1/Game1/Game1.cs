using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //sprites for Teddy Bears
        Texture2D teddyBearSprite0;
        Texture2D teddyBearSprite1;
        Texture2D teddyBearSprite2;

        //draw rectangles for Teddy Bears
        Rectangle drawRectangle0;
        Rectangle drawRectangle1;
        Rectangle drawRectangle2;




        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 604;
            graphics.PreferredBackBufferHeight = 425;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // load teddy bear sprites
            teddyBearSprite0 = Content.Load<Texture2D>(@"graphics\teddybear0");
            teddyBearSprite1 = Content.Load<Texture2D>(@"graphics\teddybear1");
            teddyBearSprite2 = Content.Load<Texture2D>(@"graphics\teddybear2");

            //build draw rectangles
            drawRectangle0 = new Rectangle(graphics.PreferredBackBufferWidth / 4, 
                graphics.PreferredBackBufferHeight / 4,
                teddyBearSprite0.Width, teddyBearSprite0.Height);
            drawRectangle1 = new Rectangle(graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2,
                teddyBearSprite1.Width, teddyBearSprite1.Height);
            drawRectangle2 = new Rectangle(graphics.PreferredBackBufferWidth * 3 / 4,
                graphics.PreferredBackBufferHeight * 3 / 4,
                teddyBearSprite2.Width, teddyBearSprite2.Height);


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

            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic here

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
            spriteBatch.Draw(teddyBearSprite0, drawRectangle0, Color.White);
            spriteBatch.Draw(teddyBearSprite1, drawRectangle1, Color.White);
            spriteBatch.Draw(teddyBearSprite2, drawRectangle2, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
