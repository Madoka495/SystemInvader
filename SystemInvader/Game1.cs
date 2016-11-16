using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VirusInvader
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Level level = new Level();
        Enemy enemy1;
        Tower tower;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = level.Width * 32;
            graphics.PreferredBackBufferHeight = level.Height * 32;
            IsMouseVisible = true;

            Window.Title = "BlaBlaBla";
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

            Texture2D path = Content.Load<Texture2D>("path");
            Texture2D grass = Content.Load<Texture2D>("grass");
            level.AddTexture(grass);
            level.AddTexture(path);

            Texture2D enemyTexture = Content.Load<Texture2D>("enemy");
            enemy1 = new Enemy(enemyTexture, Vector2.Zero, 100, 10, 0.5f);
            enemy1.SetWaypoints(level.Waypoints);

            //Texture2D towerTexture = Content.Load<Texture2D>("arrowtower");
            //tower = new Tower(enemyTexture, Vector2.Zero, 100, 10, 0.5f);

        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            enemy1.Update(gameTime);

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            level.Draw(spriteBatch);
            enemy1.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
