using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MovingTeddyBears
{
    /// <summary>
    /// A teddy bear
    /// </summary>
    class TeddyBear
    {
        #region Fields

        // drawing support
        Texture2D sprite;
        Rectangle drawRectangle;

        // velocity information
        Vector2 velocity = new Vector2(0, 0);

        // bouncing support
        int windowWidth;
        int windowHeight;

        #endregion

        #region Constructors

        /// <summary>
        ///  Constructs a teddy bear with random direction and speed
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="spriteName">the name of the sprite for the teddy bear</param>
        /// <param name="x">the x location of the center of the teddy bear</param>
        /// <param name="y">the y location of the center of the teddy bear</param>
        /// <param name="windowWidth">the window width</param>
        /// <param name="windowHeight">the window height</param>
        public TeddyBear(ContentManager contentManager, string spriteName, int x, int y,
            int windowWidth, int windowHeight)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            LoadContent(contentManager, spriteName, x, y);

            // generate random velocity
            Random rand = new Random();
            int speed = rand.Next(5) + 3;
            double angle = 2 * Math.PI * rand.NextDouble();
            velocity.X = (float)Math.Cos(angle) * speed;
            velocity.Y = -1 * (float)Math.Sin(angle) * speed;
        }

        /// <summary>
        /// Constructs a teddy bear with the given characteristics
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="spriteName">the name of the sprite for the teddy bear</param>
        /// <param name="x">the x location of the center of the teddy bear</param>
        /// <param name="y">the y location of the center of the teddy bear</param>
        /// <param name="velocity">the velocity vector for the teddy bear</param>
        /// <param name="windowWidth">the window width</param>
        /// <param name="windowHeight">the window height</param>
        public TeddyBear(ContentManager contentManager, string spriteName, int x, int y,
            Vector2 velocity, int windowWidth, int windowHeight)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            LoadContent(contentManager, spriteName, x, y);
            this.velocity = velocity;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the teddy bear's location, bouncing if necessary
        /// </summary>
        public void Update()
        {
            // move the teddy bear
            drawRectangle.X += (int)(velocity.X);
            drawRectangle.Y += (int)(velocity.Y);

            // bounce as necessary
            BounceTopBottom();
            BounceLeftRight();
        }

        /// <summary>
        /// Draws the teddy bear
        /// </summary>
        /// <param name="spriteBatch">the sprite batch to use</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, drawRectangle, Color.White);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the teddy bear
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        /// <param name="spriteName">the name of the sprite for the teddy bear</param>
        /// <param name="x">the x location of the center of the teddy bear</param>
        /// <param name="y">the y location of the center of the teddy bear</param>
        private void LoadContent(ContentManager contentManager, string spriteName,
            int x, int y)
        {
            // load content and set remainder of draw rectangle
            sprite = contentManager.Load<Texture2D>(spriteName);
            drawRectangle = new Rectangle(x - sprite.Width / 2,
                y - sprite.Height / 2, sprite.Width,
                sprite.Height);
        }

        /// <summary>
        /// Bounces the teddy bear off the top and bottom window borders if necessary
        /// </summary>
        private void BounceTopBottom()
        {
            if (drawRectangle.Y < 0)
            {
                // bounce off top
                drawRectangle.Y = 0;
                velocity.Y *= -1;
            }
            else if ((drawRectangle.Y + drawRectangle.Height) > windowHeight)
            {
                // bounce off bottom
                drawRectangle.Y = windowHeight - drawRectangle.Height;
                velocity.Y *= -1;
            }
        }
        /// <summary>
        /// Bounces the teddy bear off the left and right window borders if necessary
        /// </summary>
        private void BounceLeftRight()
        {
            if (drawRectangle.X < 0)
            {
                // bounce off left
                drawRectangle.X = 0;
                velocity.X *= -1;
            }
            else if ((drawRectangle.X + drawRectangle.Width) > windowWidth)
            {
                // bounce off right
                drawRectangle.X = windowWidth - drawRectangle.Width;
                velocity.X *= -1;
            }
        }

        #endregion
    }
}
