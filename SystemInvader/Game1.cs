using Data.SystemInvader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MO.SystemInvader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemInvader;

namespace SystemInvader
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Menu
        enum GameState { mainMenu, enterName, scores, shopTower, inGame, beforeGame }

        GameState gameState;

        List<ElementMenu> main = new List<ElementMenu>();
        List<ElementMenu> enterName = new List<ElementMenu>();
        List<ElementMenu> inGame = new List<ElementMenu>();
        List<ElementMenu> beforeGame = new List<ElementMenu>();
        List<ElementMenu> shopTower = new List<ElementMenu>();
        List<ElementMenu> scores = new List<ElementMenu>();

        Keys[] lastPressedKeys = new Keys[5];

        string myName = string.Empty;
        bool _isPressed = false;
        bool _isInGame;
        bool _alreadyShot;

        SpriteFont sf;
        // Keyboard
        InputTextKeyboard _keyboard;
        KeyboardState _lastKeyboardState;

        //Mouse
        MouseMove _mouseMove;

        // Player
        Player _player;

        // Background
        //Texture2D _backGroundMenu;
        Texture2D _backGroundUser;
        Vector2 _bgPosition;
        Texture2D _bgTexture;
        Texture2D _logo;
        // map
        Level _level = new Level();
        LandsData _landsData = new LandsData();

        // Ennemies
        EnemiesData _enemiesData = new EnemiesData();

        //Tower
        Texture2D _towerSprite;
        List<Tower> _towers;

        // Bullet
        Texture2D _bullet;

        // Timer
        int _timer = 30;
        int _frame = 0;
        SpriteFont _timerFont;

        // Wave
        WaveManager _waveManager;
        WavesData _wavesData = new WavesData();

        // Record Pseudo User
        string userNameTxt = @"D:\dev\ProjetInformatique\SystemInvader\SystemInvader\Content\json\userName.txt";

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Player
            _player = new Player();

            //Windows size
            graphics.PreferredBackBufferHeight = _level.WindowsHeight;
            graphics.PreferredBackBufferWidth = _level.WindowsWidth;

            //Mouse
            IsMouseVisible = true;
            _mouseMove = new MouseMove(_player);

            // Keyboard
            _keyboard = new InputTextKeyboard();
            _lastKeyboardState = new KeyboardState();

            //Menu
            main.Add(new ElementMenu("Sprites/play"));
            main.Add(new ElementMenu("Sprites/name"));
            main.Add(new ElementMenu("Sprites/options"));
            main.Add(new ElementMenu("Sprites/exit"));
            main.Add(new ElementMenu("Sprites/scores"));

            enterName.Add(new ElementMenu("Sprites/done"));

            beforeGame.Add(new ElementMenu("Sprites/towersShop"));
            beforeGame.Add(new ElementMenu("Sprites/start"));

            shopTower.Add(new ElementMenu("Sprites/towers2"));
            shopTower.Add(new ElementMenu("Sprites/start"));
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
            _bgPosition = new Vector2(0, 0);

            // Timer
            _timerFont = Content.Load<SpriteFont>("timer");
            //Towers
            _towers = new List<Tower>();
          
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _bgTexture = Content.Load<Texture2D>("Background/mainBackground");
            _logo= Content.Load<Texture2D>("Sprites/logo");
            // TODO: use this.Content to load your game content here
            //Menu
            ContentManager content = Content;
            sf = content.Load<SpriteFont>("userName");

            //_backGroundMenu = Content.Load<Texture2D>("Background/backgroundMenu");
            _backGroundUser = Content.Load<Texture2D>("Background/enter_name");

            foreach (ElementMenu element in main)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            main.Find(x => x.AssetName == "Sprites/play").MoveElement(80, 15);
            main.Find(x => x.AssetName == "Sprites/name").MoveElement(79, 100);
            main.Find(x => x.AssetName == "Sprites/options").MoveElement(279, 100);
            main.Find(x => x.AssetName == "Sprites/exit").MoveElement(180, 185);
            main.Find(x => x.AssetName == "Sprites/scores").MoveElement(280, 15);

            foreach (ElementMenu element in enterName)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            enterName.Find(x => x.AssetName == "Sprites/done").MoveElement(150, 80);

            foreach (ElementMenu element in shopTower)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            shopTower.Find(x => x.AssetName == "Sprites/towers2").MoveElement(-336, 343);
            shopTower.Find(x => x.AssetName == "Sprites/start").MoveElement(620, -265);

            foreach (ElementMenu element in beforeGame)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            beforeGame.Find(x => x.AssetName == "Sprites/towersShop").MoveElement(-336, 343);
            beforeGame.Find(x => x.AssetName == "Sprites/start").MoveElement(620, -265);

            // Map
            _landsData.AddTextureLands1(this.Content);
            _level.AddTexture(_landsData.Lands1);

            //Ennemies
            _enemiesData.AddTextureEnemies(this.Content, _player);
            _enemiesData.AddAllEnemy();

            //Tower
            _towerSprite = Content.Load<Texture2D>("Sprites/tower");

            //Bullet
            _bullet = Content.Load<Texture2D>("Sprites/bullet1");

            //Wave
            _wavesData.AddInfor(_enemiesData, _level, _player);
            _wavesData.SetUpWavesData();
            _waveManager = new WaveManager(_wavesData.Wave);
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
            //Menu
            _towers = _mouseMove.PlacedTowers();
            

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                _isPressed = false;
            }
            switch (gameState)
            {
                case GameState.mainMenu:
                    foreach (ElementMenu element in main)
                    {
                        element.Update();
                    }
                    break;
                case GameState.enterName:
                    foreach (ElementMenu element in enterName)
                    {
                        element.Update();
                    }
                    _keyboard.Write(_lastKeyboardState);
                    if (myName.Length > 14)
                    {

                    }
                    else
                    {
                        if (_keyboard.NewChar == "DELETE")
                        {
                            if (myName.Length > 0)
                            {
                                myName = myName.Substring(0, myName.Length - 1);
                            }
                        }
                        else
                        {
                            myName += _keyboard.NewChar;
                        }
                    }
                    _lastKeyboardState = Keyboard.GetState();
                    break;
                case GameState.shopTower:
                    foreach (ElementMenu element in shopTower)
                    {
                        element.Update();
                    }
                    _mouseMove.Update();
                    if (_frame % 60 == 0)
                        _timer--;
                    break;
                case GameState.inGame:

                    _waveManager.Update(gameTime);
                    foreach (Tower tower in _towers)
                    {
                        _alreadyShot = false;
                        foreach(Wave wave in _waveManager.Waves)
                        {
                            foreach (Enemy enemy in wave.Enemies)
                            {
                                if (enemy.InGame== true && _alreadyShot == false && enemy.GetPos().X >= tower.GetPos().X - tower.GetRange() && enemy.GetPos().X <= tower.GetPos().X + tower.GetRange() && enemy.GetPos().Y >= tower.GetPos().Y - tower.GetRange() && enemy.GetPos().Y <= tower.GetPos().Y + tower.GetRange() && _frame % tower.GetRate() == 0)
                                {
                                    tower.Shoot(new Vector2(enemy.GetPos().X, enemy.GetPos().Y));
                                    _alreadyShot = true;
                                }
                            }
                        }
                        foreach (Projectile projectile in tower.GetProjectiles())
                        {
                            if (projectile.DestReached == false)
                            {
                                projectile.Update();
                            }
                            foreach (Wave wave in _waveManager.Waves)
                            {
                                foreach (Enemy enemy in wave.Enemies)
                                {
                                    if (enemy.InGame == true && projectile.GetPos().X <= enemy.GetPos().X && projectile.GetPos().X + _bullet.Width >= enemy.GetPos().X && projectile.GetPos().Y <= enemy.GetPos().Y && projectile.GetPos().Y + _bullet.Height >= enemy.GetPos().Y && projectile.DestReached == false)
                                    {
                                        projectile.DestReached = true;
                                        enemy.Deal(projectile.Power());
                                    }
                                }
                            }
                        }
                    }

                    break;
                case GameState.beforeGame:
                    foreach (ElementMenu element in beforeGame)
                    {
                        element.Update();
                    }
                    if (_frame % 60 == 0)
                        _timer--;
                    break;
                default:
                    break;
            }
            if (_timer == 0)
            {
                gameState = GameState.inGame;
                Console.WriteLine("gameState: " + gameState);
                _timer = 30;
            }
            _frame++;
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
            _isInGame = false;
            spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.mainMenu:
                    spriteBatch.Draw(_bgTexture, new Rectangle(0, 0, 1280, 800), Color.White);
                    spriteBatch.Draw(_logo, new Rectangle(330, 0, _logo.Width, _logo.Height), Color.White);
                    foreach (ElementMenu element in main)
                    {
                        element.Draw(spriteBatch);
                    }
                    break;
                case GameState.enterName:
                    spriteBatch.Draw(_bgTexture, new Rectangle(0, 0, 1280, 800), Color.White);
                    spriteBatch.Draw(_backGroundUser, new Rectangle(400, 225, 300, 200), Color.White);
                    foreach (ElementMenu element in enterName)
                    {
                        element.Draw(spriteBatch);
                    }
                    spriteBatch.DrawString(sf, myName, new Vector2(430, 325), Color.Black);
                    break;

                case GameState.inGame:
                    _level.Draw(spriteBatch);
                    _isInGame = true;
                    //Pseudo player
                    _waveManager.Draw(spriteBatch);
                    spriteBatch.DrawString(sf, myName, new Vector2(150, 10), Color.White);
                    spriteBatch.DrawString(_timerFont, "Score : " + _player.Score, new Vector2(450, 20), Color.MediumOrchid);
                    spriteBatch.DrawString(_timerFont, "Life : " + _player.Life, new Vector2(650, 20), Color.White);
                    spriteBatch.DrawString(_timerFont, "Vang : " + _player.CurrentGold, new Vector2(800, 20), Color.Gold);
                    
                    

                    break;
                case GameState.shopTower:
                    _level.Draw(spriteBatch);
                    _isInGame = true;
                    foreach (ElementMenu element in shopTower)
                    {
                        element.Draw(spriteBatch);
                    }
                    foreach (TowerShop tower in _mouseMove.Towers())
                    {
                        spriteBatch.Draw(_towerSprite, new Rectangle((int)tower.Position.X, (int)tower.Position.Y, tower.Width, tower.Height), Color.White);
                    }
                    spriteBatch.DrawString(_timerFont, "Timer : " + _timer, new Vector2(250, 20), Color.Black);
                    spriteBatch.DrawString(_timerFont, "Score : " + _player.Score, new Vector2(450, 20), Color.MediumOrchid);
                    spriteBatch.DrawString(_timerFont, "Life : " + _player.Life, new Vector2(650, 20), Color.White);
                    spriteBatch.DrawString(_timerFont, "Vang : " + _player.CurrentGold, new Vector2(800, 20), Color.Gold);


                    break;

                case GameState.beforeGame:
                    _level.Draw(spriteBatch);
                    _isInGame = true;
                    foreach (ElementMenu element in beforeGame)
                    {
                        element.Draw(spriteBatch);
                    }
                    spriteBatch.DrawString(_timerFont, "Timer : " + _timer, new Vector2(250, 20), Color.Black);
                    spriteBatch.DrawString(_timerFont, "Score : " + _player.Score, new Vector2(450, 20), Color.MediumOrchid);
                    spriteBatch.DrawString(_timerFont, "Life : " + _player.Life, new Vector2(650, 20), Color.White);
                    spriteBatch.DrawString(_timerFont, "Vang : " + _player.CurrentGold, new Vector2(800, 20), Color.Gold);
                    break;
                default:
                    break;
            }
            if (_isInGame == true)
            {
                _waveManager.Draw(spriteBatch);
                foreach (Tower tower in _towers)
                {
                    spriteBatch.Draw(_towerSprite, new Rectangle((int)tower.GetPos().X, (int)tower.GetPos().Y, _towerSprite.Width, _towerSprite.Height), Color.White);
                    foreach (Projectile projectile in tower.GetProjectiles())
                    {
                        if (projectile.DestReached == false)
                        {
                            spriteBatch.Draw(_bullet, new Rectangle((int)projectile.GetPos().X, (int)projectile.GetPos().Y, _bullet.Width, _bullet.Height), Color.White);
                        }
                    }
                }
            }
            spriteBatch.End();
        }

        public void OnClick(string element)
        {
            /*Console.WriteLine("Onclick : " + element);
              Console.WriteLine("Pressed : " + _isPressed);*/
            if (_isPressed == false)
            {
                if (element == "Sprites/play")
                {
                    //Play the game
                    gameState = GameState.beforeGame;
                }
                if (element == "Sprites/name")
                {
                    gameState = GameState.enterName;
                }
                if (element == "Sprites/done")
                {
                    if (!File.Exists(userNameTxt))
                    {
                        // Create a file to write to.
                        File.WriteAllText(userNameTxt, myName + ";" + _player.Score + Environment.NewLine);
                    }
                    else
                    {
                        // Add a new line for write into the txt
                        string myString = File.ReadAllText(userNameTxt);
                        File.WriteAllText(userNameTxt, myString + "\n\r" + myName + ";" + _player.Score + "\n\r");
                    }
                    gameState = GameState.mainMenu;
                }
                if (element == "Sprites/towersShop")
                {
                    gameState = GameState.shopTower;
                }
                if (element == "Sprites/start")
                {
                    gameState = GameState.inGame;
                }
                if (element == "Sprites/towers2")
                {
                    gameState = GameState.beforeGame;
                    //Console.WriteLine("gameState: " + gameState);
                }
                _isPressed = true;
            }
        }

        public SpriteFont TimerFont()
        {
            return _timerFont;
        }
    }
}
