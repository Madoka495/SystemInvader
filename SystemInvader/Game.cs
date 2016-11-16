using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SystemInvader
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D bullet;
        Texture2D towerSprite;
        int frame = 0;
        static Vector2 start = new Vector2(100, 100);
        static Vector2 dest;
        int bulletWidth = 50;
        int bulletHeight = 50;
        int towerWidth = 62;
        int towerHeight = 90;
        SpriteFont font;
        int lives = 5;
        List<Tower> _towers;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            _towers = new List<Tower>();
            _towers.Add(new Tower(new Vector2(200, 50), 4, 300, 2));
            _towers.Add(new Tower(new Vector2(50, 300), 8, 600, 1));
            _towers.Add(new Tower(new Vector2(500, 300), 4, 1000, 2));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bullet = Content.Load<Texture2D>("bullet1");
            towerSprite = Content.Load<Texture2D>("rumia");
            font = Content.Load<SpriteFont>("font");

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

            MouseState mouse = Mouse.GetState();
            System.Diagnostics.Debug.WriteLine("mouse : " + mouse.X + ", " + mouse.Y);

            foreach(Tower tower in _towers)
            {
                if (mouse.X >= tower.GetPos().X - tower.GetRange() && mouse.X <= tower.GetPos().X + tower.GetRange() && mouse.Y >= tower.GetPos().Y - tower.GetRange() && mouse.Y <= tower.GetPos().Y + tower.GetRange() && frame % tower.GetRate() == 0)
                {
                    tower.Shoot(new Vector2(mouse.X, mouse.Y));
                }
                foreach(Projectile projectile in tower.GetProjectiles())
                {
                    if (projectile.DestReached == false)
                    {
                        projectile.Update();
                    }

                    if (projectile.GetPos().X <= mouse.X && projectile.GetPos().X + bullet.Width >= mouse.X && projectile.GetPos().Y <= mouse.Y && projectile.GetPos().Y + bullet.Height >= mouse.Y && projectile.DestReached == false)
                    {
                        projectile.DestReached = true;
                        lives--;
                    }
                }
            }
            // TODO: Add your update logic here
            frame++;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (Tower tower in _towers)
            {
                spriteBatch.Draw(towerSprite, new Rectangle((int)tower.GetPos().X, (int)tower.GetPos().Y, towerWidth, towerHeight), Color.White);
                foreach(Projectile projectile in tower.GetProjectiles())
                {
                    if (projectile.DestReached == false)
                    {
                        spriteBatch.Draw(bullet, new Rectangle((int)projectile.GetPos().X, (int)projectile.GetPos().Y, bulletWidth, bulletHeight), Color.White);
                    }
                }
            }

            if(lives > 0)
            {
                spriteBatch.DrawString(font, "Lives : " + lives, new Vector2(0, 0), Color.Black);
            }
            else
            {
                spriteBatch.DrawString(font, "GAME OVER", new Vector2(300, 100), Color.Black);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
