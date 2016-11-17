using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using VirusInvader;

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
        Texture2D path;
        Texture2D grass;
        Texture2D enemyTexture;
        int frame = 0;
        static Vector2 start = new Vector2(100, 100);
        int bulletWidth = 50;
        int bulletHeight = 50;
        int towerWidth = 62;
        int towerHeight = 90;
        int enemyWidth = 32;
        int enemyHeight = 32;
        bool alreadyShot;
        SpriteFont font;
        List<Tower> _towers;
        List<Enemy> _enemies;

        Level level = new Level();

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
            _enemies = new List<Enemy>();

            _towers.Add(new Tower(new Vector2(200, 30), 8, 150, 2));
            _towers.Add(new Tower(new Vector2(50, 300), 16, 150, 1));
            _towers.Add(new Tower(new Vector2(530, 280), 8, 200, 2));

            _enemies.Add(new Enemy(Vector2.Zero, 100, 10, 1f));
            _enemies.Add(new Enemy(Vector2.Zero, 300, 20, 2f));
            _enemies.Add(new Enemy(Vector2.Zero, 300, 50, 0.4f));
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
            path = Content.Load<Texture2D>("path");
            grass = Content.Load<Texture2D>("grass");
            level.AddTexture(grass);
            level.AddTexture(path);
            enemyTexture = Content.Load<Texture2D>("enemy");
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
            
            foreach (Enemy enemy in _enemies)
            {
                enemy.Update();
            }

            foreach (Tower tower in _towers)
            {
                alreadyShot = false;
                foreach (Enemy enemy in _enemies)
                {
                    if (enemy.IsDead == false && alreadyShot == false && enemy.GetPos().X >= tower.GetPos().X - tower.GetRange() && enemy.GetPos().X <= tower.GetPos().X + tower.GetRange() && enemy.GetPos().Y >= tower.GetPos().Y - tower.GetRange() && enemy.GetPos().Y <= tower.GetPos().Y + tower.GetRange() && frame % tower.GetRate() == 0)
                    {
                        tower.Shoot(new Vector2(enemy.GetPos().X, enemy.GetPos().Y));
                        alreadyShot = true;
                    }
                }
                foreach(Projectile projectile in tower.GetProjectiles())
                {
                    if (projectile.DestReached == false)
                    {
                        projectile.Update();
                    }

                    foreach (Enemy enemy in _enemies)
                    {
                        if (enemy.IsDead == false && projectile.GetPos().X <= enemy.GetPos().X && projectile.GetPos().X + bullet.Width >= enemy.GetPos().X && projectile.GetPos().Y <= enemy.GetPos().Y && projectile.GetPos().Y + bullet.Height >= enemy.GetPos().Y && projectile.DestReached == false)
                        {
                            projectile.DestReached = true;
                            enemy.Deal(projectile.Power());
                        }
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

            level.Draw(spriteBatch);
            foreach (Enemy enemy in _enemies)
            {
                if(enemy.IsDead == false)
                {
                    spriteBatch.Draw(enemyTexture, new Rectangle((int)enemy.GetPos().X, (int)enemy.GetPos().Y, enemyWidth, enemyHeight), Color.White);
                }
            }

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
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
