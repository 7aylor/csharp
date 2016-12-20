using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TeddyMineExplosion;

namespace ProgrammingAssignment5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //const window dimensions
        const int WindowWidth = 800;
        const int WindowHeight = 600;

        //lists of mines and teddybears
        List<Mine> mines = new List<Mine>();
        List<TeddyBear> teddyBears = new List<TeddyBear>();
        List<Explosion> explosions = new List<Explosion>();

        //initialize texture variables
        Texture2D teddyBearTexture;
        Texture2D mineTexture;
        Texture2D explosionTexture;

        //initialize random variable used to randomly spawn teddy bears
        Random rand = new Random();

        //values used to track random numbers
        int teddyBearSpawner;
        int teddyBearX;
        int teddyBearY;
        float vectorX;
        float vectorY;

        int timeSinceSpawn = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //initialize the window heigh and width
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;

            //make make visible on the game window
            IsMouseVisible = true;
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

            //load sprites
            teddyBearTexture = Content.Load<Texture2D>(@"graphics\teddybear");
            mineTexture = Content.Load<Texture2D>(@"graphics\mine");
            explosionTexture = Content.Load<Texture2D>(@"graphics\explosion");

            teddyBearSpawner = rand.Next(1, 4) * 1000;
            teddyBearX = rand.Next(0, WindowWidth - teddyBearTexture.Width);
            teddyBearY = rand.Next(0, WindowHeight - teddyBearTexture.Height);
            vectorX = (float)rand.Next(-5, 6) * 0.1f;
            vectorY = (float)rand.Next(-5, 6) * 0.1f;

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

            //create mouse object
            MouseState mouse = Mouse.GetState();

            
            //if it has been 1-3 seconds from the last time a bear was spawned, spawn another one and reset timeSinceSpawn
            if (timeSinceSpawn == teddyBearSpawner)
            {
                teddyBears.Add(new TeddyBear(teddyBearTexture, new Vector2(0.3f, 0.2f), 400, 400));

                timeSinceSpawn = 0;
            }

            //Update all of our teddybears in our list
            foreach(TeddyBear teddyBear in teddyBears)
            {
                teddyBear.Update(gameTime);
            }

            //if the left mouse button is clicked, add a mine at the mouse pointer's x and y coordinates
            if(mouse.LeftButton == ButtonState.Pressed)
            {
                mines.Add(new Mine(mineTexture, mouse.X, mouse.Y));

            }

            //increase timeSinceSpawn every frame
            timeSinceSpawn += gameTime.ElapsedGameTime.Milliseconds;

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

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            foreach(Mine mine in mines)
            {
                mine.Draw(spriteBatch);
            }
            foreach (TeddyBear teddyBear in teddyBears)
            {
                teddyBear.Draw(spriteBatch);
            }
            foreach (Explosion explosion in explosions)
            {
                explosion.Draw(spriteBatch);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
