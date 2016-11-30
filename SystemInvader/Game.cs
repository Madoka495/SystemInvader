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
        

        int frame = 0;
        static Vector2 start = new Vector2(100, 100);
        int bulletWidth = 50;
        int bulletHeight = 50;
        bool alreadyShot;

        SpriteFont font;
        List<Tower> _towers;
        List<Enemy> _listEnemies;

        /*Enemy _enemy0;
        Enemy _enemy1;
        Enemy _enemy2;
        Enemy _enemy3;*/

        //Wave _wave;
        WaveManager _waveManager;

        EnemiesData _enemiesData = new EnemiesData();
        TowersData _towersData = new TowersData();
        WavesData _wavesData = new WavesData();
        LandsData _landsData = new LandsData();

        Level _level = new Level();

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferHeight = _level.WindowsHeight;
            graphics.PreferredBackBufferWidth = _level.WindowsWidth;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            _enemiesData.AddTextureEnemies(this.Content);
            _enemiesData.AddAllEnemy();
            _towersData.AddTextureTowers(this.Content);
            _towersData.AddAllTowers();
            _landsData.AddTextureLands1(this.Content);


            bullet = Content.Load<Texture2D>("bullet1");
            towerSprite = Content.Load<Texture2D>("Towers/Tower1Upgrade1");
            font = Content.Load<SpriteFont>("font");
            path = Content.Load<Texture2D>("path");
            grass = Content.Load<Texture2D>("grass");

            _level.AddTexture(_landsData.Lands1);
            //_level.AddTexture(path);

            _wavesData.AddInfor(_enemiesData, _level);
            _wavesData.SetUpWavesData();


            _towers = new List<Tower>();
            _listEnemies = new List<Enemy>();

            /*_listTypeEnemies = new List<int>();
            _listTypeEnemies.Add(1);
            _listTypeEnemies.Add(2);
            _listTypeEnemies.Add(3);*/


            /*_listEnemies.Add(_enemy1);
            _listEnemies.Add(_enemy2);
            _listEnemies.Add(_enemy3);*/

            //_wave = new Wave(5, _enemiesData.Enemy[1], _level);

            _waveManager = new WaveManager(_wavesData.WaveLv1);

            /*_towers.Add(new Tower(towerSprite, new Vector2(5, 2) *32, 8, 150, 2, 30, 60));
            _towers.Add(new Tower(towerSprite, new Vector2(3, 11)*32, 16, 150, 1, 30, 60));
            _towers.Add(new Tower(towerSprite, new Vector2(17, 10)*32, 8, 200, 2, 30, 60));*/

            /*enemy1 = new Enemy(enemyTexture, Vector2.Zero, 100, 10, 1f, 32, 32);
            enemy1.SetWaypoints(level.Waypoints);
            enemy2 = new Enemy(enemyTexture, Vector2.Zero, 100, 10, 0.8f, 32, 32);
            enemy2.SetWaypoints(level.Waypoints);
            enemy3 = new Enemy(enemyTexture, Vector2.Zero, 100, 10, 0.4f, 32, 32);
            enemy3.SetWaypoints(level.Waypoints);

            _enemies.Add(enemy1);
            _enemies.Add(enemy2);
            _enemies.Add(enemy3);*/
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

            //_wave.Update(gameTime);
            _waveManager.Update(gameTime);

            /*foreach (Enemy enemy in _enemies)
            {
                enemy.Update();
            }*/

            foreach (Tower tower in _towers)
            {
                alreadyShot = false;
                
                foreach (Enemy enemy in _listEnemies)
                {
                    if (enemy.IsDead == false && 
                        alreadyShot == false &&
                        tower.Inrange(enemy.GetPos()) == true &&
                        frame % tower.GetRate() == 0)
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

                    foreach (Enemy enemy in _listEnemies)
                    {
                        if (enemy.IsDead == false &&
                            projectile.hitEnemy(enemy.GetPos(), bullet) &&
                            projectile.DestReached == false)
                        {
                            projectile.DestReached = true;
                            enemy.Deal(projectile.Power());
                        }
                    }
                }
            }
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

            _level.Draw(spriteBatch);
            _waveManager.Draw(spriteBatch);            
            //_wave.Draw(spriteBatch);

            /*foreach (Enemy enemy in _enemies)
            {
                enemy.Draw(spriteBatch);
            }*/


            foreach (Tower tower in _towers)
            {
                tower.Draw(spriteBatch);
                foreach(Projectile projectile in tower.GetProjectiles())
                {
                    if (projectile.DestReached == false)
                    {
                        spriteBatch.Draw(bullet, new Rectangle((int)projectile.GetPos().X, (int)projectile.GetPos().Y, bulletWidth, bulletHeight), Color.White);
                    }
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
