﻿using Data.SystemInvader;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        enum GameState { mainMenu, enterName, scores, difficulty, shopTower, inGame, beforeGame, won, lost }

        GameState gameState;

        List<ElementMenu> main = new List<ElementMenu>();
        List<ElementMenu> enterName = new List<ElementMenu>();
        List<ElementMenu> difficulty = new List<ElementMenu>();
        List<ElementMenu> inGame = new List<ElementMenu>();
        List<ElementMenu> beforeGame = new List<ElementMenu>();
        List<ElementMenu> shopTower = new List<ElementMenu>();
        List<ElementMenu> scores = new List<ElementMenu>();
        List<ElementMenu> won = new List<ElementMenu>();
        List<ElementMenu> lost = new List<ElementMenu>();


        Keys[] lastPressedKeys = new Keys[5];

        string myName = string.Empty;
        bool _isPressed = false;
        bool _isPressed2 = false;
        bool _alreadyShot;

        SpriteFont _mainSpriteFont;
        SpriteFont _mainFont;
        SpriteFont _commentFont;
        SpriteFont _statsFont;
        SpriteFont _endingMessage;
        SpriteFont _score;

        // Keyboard
        InputTextKeyboard _keyboard;
        KeyboardState _lastKeyboardState;

        //Mouse
        PlaceTower _placeTowers;

        // Player
        Player _player;

        // Background
        Texture2D _backGroundUser;
        Vector2 _bgPosition;
        Texture2D _bgTexture;
        Texture2D _logo;
        Texture2D _properties;
        Texture2D _properties2;
        Texture2D _bgTowers;
        Texture2D _sellButton;
        Rectangle _sellRect;
        Texture2D _navBarInfo;

        // Map
        Level _level;
        LandsData _landsData;
        Texture2D _map;

        // Waterfall
        Texture2D _waterfall1;
        Texture2D _waterfall2;

        // Ennemies
        EnemiesData _enemiesData;

        //Tower
        List<Tower> _towers;
        Tower _selectedTower;

        // Timer
        int _timer = 30;
        int _frame = 0;

        // Wave
        WaveManager _waveManager;
        WavesData _wavesData;

        // Random
        Random _random = new Random();

        // Income
        int _income = 0;
        int _displayIncome = 0;

        // Save Pseudo JSON
        string path = @"../../../../Content/DataJson/data.json";

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            // Player
            _player = new Player();

            // Map
            _level = new Level();
            _landsData = new LandsData();

            //Mouse
            IsMouseVisible = true;

            // Keyboard
            _keyboard = new InputTextKeyboard();
            _lastKeyboardState = new KeyboardState();

            //Windows size
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = true;

            // Waves
            _wavesData = new WavesData();

            // Enemies
            _enemiesData = new EnemiesData(_player);

            //Menu
            main.Add(new ElementMenu("Sprites/play"));
            main.Add(new ElementMenu("Sprites/name"));
            main.Add(new ElementMenu("Sprites/options"));
            main.Add(new ElementMenu("Sprites/exit"));
            main.Add(new ElementMenu("Sprites/scores"));

            enterName.Add(new ElementMenu("Sprites/done"));

            inGame.Add(new ElementMenu("Sprites/menuInGame"));
            inGame.Add(new ElementMenu("Sprites/rewind"));

            beforeGame.Add(new ElementMenu("Sprites/towersShop"));
            beforeGame.Add(new ElementMenu("Sprites/start"));
            beforeGame.Add(new ElementMenu("Sprites/menuInGame"));
            beforeGame.Add(new ElementMenu("Sprites/rewind"));

            shopTower.Add(new ElementMenu("Sprites/towers2"));
            shopTower.Add(new ElementMenu("Sprites/start"));
            shopTower.Add(new ElementMenu("Sprites/menuInGame"));
            shopTower.Add(new ElementMenu("Sprites/rewind"));

            won.Add(new ElementMenu("Sprites/menu"));
            won.Add(new ElementMenu("Sprites/rewind"));
            won.Add(new ElementMenu("Sprites/scores"));

            lost.Add(new ElementMenu("Sprites/menu"));
            lost.Add(new ElementMenu("Sprites/rewind"));
            lost.Add(new ElementMenu("Sprites/scores"));

            scores.Add(new ElementMenu("Sprites/menu"));

            difficulty.Add(new ElementMenu("Sprites/easy"));
            difficulty.Add(new ElementMenu("Sprites/normal"));
            difficulty.Add(new ElementMenu("Sprites/hard"));
            difficulty.Add(new ElementMenu("Sprites/lunatic"));
            difficulty.Add(new ElementMenu("Sprites/menu"));
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

            // Fonts
            _mainFont = Content.Load<SpriteFont>("timer");
            _commentFont = Content.Load<SpriteFont>("comment");
            _statsFont = Content.Load<SpriteFont>("stats");

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
            _logo = Content.Load<Texture2D>("Sprites/logo");
            _properties = Content.Load<Texture2D>("Sprites/properties");
            _properties2 = Content.Load<Texture2D>("Sprites/properties2");
            _bgTowers = Content.Load<Texture2D>("Sprites/towers");
            _sellButton = Content.Load<Texture2D>("Sprites/sell");
            _sellRect = new Rectangle(980, 440, _sellButton.Width, _sellButton.Height);
            _navBarInfo = Content.Load<Texture2D>("Sprites/navBarGame");
            // TODO: use this.Content to load your game content here
            //Menu
            ContentManager content = Content;
            _mainSpriteFont = content.Load<SpriteFont>("userName");
            _endingMessage = content.Load<SpriteFont>("won");
            _backGroundUser = Content.Load<Texture2D>("Background/enter_name");
            _score = Content.Load<SpriteFont>("score");

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

            foreach (ElementMenu element in beforeGame)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            beforeGame.Find(x => x.AssetName == "Sprites/towersShop").MoveElement(-336, 403);
            beforeGame.Find(x => x.AssetName == "Sprites/start").MoveElement(670, -267);
            beforeGame.Find(x => x.AssetName == "Sprites/rewind").MoveElement(570, -267);
            beforeGame.Find(x => x.AssetName == "Sprites/menuInGame").MoveElement(470, -267);

            foreach (ElementMenu element in shopTower)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            shopTower.Find(x => x.AssetName == "Sprites/towers2").MoveElement(-336, 403);
            shopTower.Find(x => x.AssetName == "Sprites/start").MoveElement(670, -267);
            shopTower.Find(x => x.AssetName == "Sprites/rewind").MoveElement(570, -267);
            shopTower.Find(x => x.AssetName == "Sprites/menuInGame").MoveElement(470, -267);

            foreach (ElementMenu element in inGame)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            inGame.Find(x => x.AssetName == "Sprites/rewind").MoveElement(670, -267);
            inGame.Find(x => x.AssetName == "Sprites/menuInGame").MoveElement(570, -267);

            foreach (ElementMenu element in won)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            won.Find(x => x.AssetName == "Sprites/menu").MoveElement(-90, 200);
            won.Find(x => x.AssetName == "Sprites/rewind").MoveElement(160, 200);
            won.Find(x => x.AssetName == "Sprites/scores").MoveElement(430, 200);

            foreach (ElementMenu element in lost)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            lost.Find(x => x.AssetName == "Sprites/menu").MoveElement(-90, 200);
            lost.Find(x => x.AssetName == "Sprites/rewind").MoveElement(160, 200);
            lost.Find(x => x.AssetName == "Sprites/scores").MoveElement(430, 200);

            foreach (ElementMenu element in scores)
            {
                element.LoadContent(Content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            scores.Find(x => x.AssetName == "Sprites/menu").MoveElement(-320, -250);

            foreach (ElementMenu element in difficulty)
            {
                element.LoadContent(Content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            difficulty.Find(x => x.AssetName == "Sprites/easy").MoveElement(180, -150);
            difficulty.Find(x => x.AssetName == "Sprites/normal").MoveElement(180, -50);
            difficulty.Find(x => x.AssetName == "Sprites/hard").MoveElement(180, 50);
            difficulty.Find(x => x.AssetName == "Sprites/lunatic").MoveElement(180, 150);
            difficulty.Find(x => x.AssetName == "Sprites/menu").MoveElement(180, 250);

            // Map
            _map = Content.Load<Texture2D>("Background/map");
            _level.AddMap(_map);

            //Waterfall
            _waterfall1 = Content.Load<Texture2D>("Sprites/waterfall1.png");
            _waterfall2 = Content.Load<Texture2D>("Sprites/waterfall2.png");
            _level.AddWaterFall(_waterfall1, _waterfall2);

            //Ennemies
            _enemiesData.AddTextureEnemies(this.Content);
            _enemiesData.AddAllEnemy();

            //Tower
            _placeTowers = new PlaceTower(_player, _level, this.Content);
            

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
            // Enregistrement Pseudo + ID (si aucun pseudo)

            _towers = _placeTowers.PlacedTowers();

            int id = _random.Next(1, 100);
            if (_player.Life <= 0)
            {
                gameState = GameState.lost;
                var objects = JArray.Parse(File.ReadAllText(path));

                if (myName.Length >= 1)
                {
                    objects.Add(new JArray(myName, _player.Score));
                }
                else
                {
                    objects.Add(new JArray("Player" + id, _player.Score));
                }

                JArray array = new JArray();

                for (int u = 0; u < 10; u++)
                {
                    if (objects.Count > 0)
                    {
                        int i = 0;
                        string pseudo = null;
                        JToken currentToken = null;
                        foreach (JToken token in objects)
                        {
                            if ((int)token[1] >= i)
                            {
                                i = (int)token[1];
                                pseudo = (string)token[0];
                                currentToken = token;
                            }
                        }
                        objects.Remove(currentToken);
                        array.Add(new JArray(pseudo, i));
                    }
                }
                File.WriteAllText(path, JsonConvert.SerializeObject(array.ToArray()));
                _player.Life = 1;
            }
            else if (_waveManager.Won)
            {
                gameState = GameState.won;
                _income = _player.Income();
                var objects = JArray.Parse(File.ReadAllText(path));

                if (myName.Length >= 1)
                {
                    objects.Add(new JArray(myName, _player.Score));
                }
                else
                {
                    objects.Add(new JArray("Player" + id, _player.Score));
                }

                JArray array = new JArray();

                for (int u = 0; u < 10; u++)
                {
                    if(objects.Count > 0)
                    {
                        int i = 0;
                        string pseudo = null;
                        JToken currentToken = null;
                        foreach (JToken token in objects)
                        {
                            if ((int)token[1] >= i)
                            {
                                i = (int)token[1];
                                pseudo = (string)token[0];
                                currentToken = token;
                            }
                        }
                        objects.Remove(currentToken);
                        array.Add(new JArray(pseudo, i));
                    }
                }

                File.WriteAllText(path, JsonConvert.SerializeObject(array.ToArray()));
                _waveManager.Won = false;

            }
            
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                _isPressed = false;
                _isPressed2 = false;
            }
            else
            {
                if(_isPressed2 == false)
                {
                    bool _selected = false;
                    
                    if (_selectedTower != null)
                    {
                        Rectangle _rec = new Rectangle(700, 284, (_properties2.Width * 3) / 2, (_properties2.Height * 3) / 2);

                        if (_rec.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                        {
                            _selected = true;
                        }

                        foreach (Tower evolution in _selectedTower.Evolutions)
                        {
                            Rectangle _rect = new Rectangle((int)evolution.GetPos().X, (int)evolution.GetPos().Y, evolution.Sprite.Width, evolution.Sprite.Height);

                            if (_rect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                            {
                                _selectedTower.Evolve(evolution);
                            }
                        }
                        if (_sellRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                        {
                            _selectedTower.Sell();
                            _selectedTower = null;
                        }
                    }

                    foreach (Tower tower in _towers)
                    {
                        if(tower.InGame() == true)
                        {
                            Rectangle _rect = new Rectangle((int)tower.GetPos().X, (int)tower.GetPos().Y, tower.Sprite.Width, tower.Sprite.Height);
                            if (_rect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                            {
                                _selectedTower = tower;
                                _selected = true;
                            }
                        }
                    }

                    if(_selected == false)
                    {
                        _selectedTower = null;
                    }

                    _isPressed2 = true;
                }
            }
            switch (gameState)
            {
                case GameState.scores:
                    foreach (ElementMenu element in scores)
                    {
                        element.Update();
                    }
                    break;
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
                    if (_keyboard.NewChar == "DELETE")
                    {
                        if (myName.Length > 0)
                        {
                            myName = myName.Substring(0, myName.Length - 1);
                        }
                    }
                    else
                    {
                        if (myName.Length <= 14)
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
                    _placeTowers.Update();
                    if (_frame % 60 == 0)
                        _timer--;
                    break;
                case GameState.inGame:
                    _waveManager.Update(gameTime);
                    if(gameState == GameState.inGame)
                    {
                        foreach (Tower tower in _towers)
                        {
                            if (tower.InGame() == true)
                            {
                                tower.GetProjectiles().RemoveAll(projectile => projectile.DestReached == true);
                                _alreadyShot = false;
                                foreach (Wave wave in _waveManager.Waves)
                                {
                                    foreach (Enemy enemy in wave.Enemies)
                                    {
                                        if (enemy.InGame == true && _alreadyShot == false && enemy.GetPos().X >= tower.GetPos().X - tower.GetRange() && enemy.GetPos().X <= tower.GetPos().X + tower.GetRange() && enemy.GetPos().Y >= tower.GetPos().Y - tower.GetRange() && enemy.GetPos().Y <= tower.GetPos().Y + tower.GetRange() && _frame % tower.GetRate() == 0)
                                        {
                                            tower.Shoot(new Vector2(enemy.GetPos().X, enemy.GetPos().Y), Content);
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
                                            float enemyX1 = enemy.GetPos().X;
                                            float enemyX2 = enemy.GetPos().X + enemy.Sprite.Width;
                                            float enemyY1 = enemy.GetPos().Y;
                                            float enemyY2 = enemy.GetPos().Y + enemy.Sprite.Height;
                                            float projectileX1 = projectile.GetPos().X;
                                            float projectileX2 = projectile.GetPos().X + projectile.Sprite.Width;
                                            float projectileY1 = projectile.GetPos().Y;
                                            float projectileY2 = projectile.GetPos().Y + projectile.Sprite.Height;

                                            if (enemy.InGame == true && projectile.DestReached == false)
                                            {
                                                if ((enemyX1 > projectileX1 && enemyX1 < projectileX2) || (enemyX2 > projectileX1 && enemyX2 < projectileX2) || (projectileX1 > enemyX1 && projectileX1 < enemyX2) || (projectileX2 > enemyX1 && projectileX2 < enemyX2))
                                                {
                                                    if ((enemyY1 > projectileY1 && enemyY1 < projectileY2) || (enemyY2 > projectileY1 && enemyY2 < projectileY2) || (projectileY1 > enemyY1 && projectileY1 < enemyY2) || (projectileY2 > enemyY1 && projectileY2 < enemyY2))
                                                    {
                                                        projectile.DestReached = true;
                                                        enemy.Deal(projectile.Power(), projectile.Type());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        foreach (ElementMenu element in inGame)
                        {
                            element.Update();
                        }
                    }

                    if(_waveManager.SendNextWave)
                    {
                        if (_waveManager.NbWave > 0)
                        {
                            gameState = GameState.beforeGame;
                            _income = _player.Income();
                            _displayIncome = _frame;
                        }
                        _waveManager.NextWave();
                        _timer = 30;
                    }
                    break;
                case GameState.beforeGame:
                    foreach (ElementMenu element in beforeGame)
                    {
                        element.Update();
                    }
                    if (_frame % 60 == 0)
                        _timer--;
                    foreach (Tower tower in _towers)
                    {
                        if(tower.InGame() == true)
                        {
                            foreach (Projectile projectile in tower.GetProjectiles())
                            {
                                projectile.DestReached = true;
                            }
                        }
                    }
                        break;
                case GameState.won:
                    foreach (ElementMenu element in won)
                    {
                        element.Update();
                    }
                    break;
                case GameState.lost:
                    foreach (ElementMenu element in lost)
                    {
                        element.Update();
                    }
                    break;
                case GameState.difficulty:
                    foreach (ElementMenu element in difficulty)
                    {
                        element.Update();
                    }
                    break;
                default:
                    break;
            }
            if (_timer == 0)
            {
                gameState = GameState.inGame;
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
            spriteBatch.Begin();
            spriteBatch.Draw(_bgTexture, new Rectangle(0, 0, 1920, 1080), Color.White);

            if(gameState == GameState.scores)
            {
                spriteBatch.DrawString(_score, "Scoreboard", new Vector2(500, 30), Color.DarkSalmon);
                foreach (ElementMenu element in scores)
                {
                    element.Draw(spriteBatch);
                }
                var objects = JArray.Parse(File.ReadAllText(path));
                int y = 100;
                JArray sorted = new JArray(objects.OrderBy(obj => obj[1]));
                foreach (JToken token in objects)
                {
                    spriteBatch.DrawString(_mainFont, token[0] + " : " + token[1], new Vector2(450, y), Color.MediumOrchid);
                    y += 50;

                }
            }
            if (gameState == GameState.mainMenu)
            {
                spriteBatch.Draw(_logo, new Rectangle(330, 0, _logo.Width, _logo.Height), Color.White);
                foreach (ElementMenu element in main)
                {
                    element.Draw(spriteBatch);
                }
            }
            if (gameState == GameState.enterName)
            {
                spriteBatch.Draw(_backGroundUser, new Rectangle(400, 225, _backGroundUser.Width, _backGroundUser.Height), Color.White);
                foreach (ElementMenu element in enterName)
                {
                    element.Draw(spriteBatch);
                }
                spriteBatch.DrawString(_mainSpriteFont, myName, new Vector2(430, 325), Color.Black);
            }
            if (gameState == GameState.inGame || gameState == GameState.beforeGame || gameState == GameState.shopTower)
            {
                _level.Draw(spriteBatch);
                foreach (Tower tower in _towers)
                {
                    if (tower.InGame() == true)
                    {
                        spriteBatch.Draw(tower.Sprite, new Rectangle((int)tower.GetPos().X, (int)tower.GetPos().Y, tower.Sprite.Width, tower.Sprite.Height), Color.White);
                        foreach (Projectile projectile in tower.GetProjectiles())
                        {
                            if (projectile.DestReached == false)
                            {
                                spriteBatch.Draw(projectile.Sprite, new Rectangle((int)projectile.GetPos().X, (int)projectile.GetPos().Y, projectile.Sprite.Width, projectile.Sprite.Height), Color.White);
                            }
                        }
                    }
                }
                _waveManager.Draw(spriteBatch);
                spriteBatch.Draw(_navBarInfo, new Rectangle(0, 0, _navBarInfo.Width, _navBarInfo.Height), Color.White);
                spriteBatch.DrawString(_mainSpriteFont, "Player : " + myName, new Vector2(5, 20), Color.Black);
                spriteBatch.DrawString(_mainFont, "Score : " + _player.Score, new Vector2(645, 20), Color.MediumOrchid);
                spriteBatch.DrawString(_mainFont, "Life : " + _player.Life, new Vector2(400, 20), Color.ForestGreen);
                spriteBatch.DrawString(_mainFont, "Vang : " + _player.CurrentGold, new Vector2(500, 20), Color.Goldenrod);


                switch (_player.Difficulty)
                {
                    case 1:
                        spriteBatch.DrawString(_mainFont, "Difficulty : Easy ", new Vector2(240, 20), Color.LightSeaGreen);
                        break;
                    case 2:
                        spriteBatch.DrawString(_mainFont, "Difficulty : Normal ", new Vector2(230, 20), Color.MonoGameOrange);
                        break;
                    case 3:
                        spriteBatch.DrawString(_mainFont, "Difficulty : Hard ", new Vector2(230, 20), Color.Red);
                        break;
                    case 4:
                        spriteBatch.DrawString(_mainFont, "Difficulty : Lunatic ", new Vector2(230, 20), Color.Blue);
                        break;
                    default:
                        break;
                }



                if (_displayIncome + 30 > _frame && _displayIncome != 0)
                {
                    spriteBatch.DrawString(_mainFont, "+" + (_income / 2) * _player.Difficulty, new Vector2(350, 50), Color.MediumOrchid);
                    spriteBatch.DrawString(_mainFont, "+" + _income, new Vector2(750, 50), Color.Gold);
                }

                if (gameState != GameState.inGame)
                {
                    spriteBatch.DrawString(_mainFont, "Timer : " + _timer, new Vector2(120, 20), Color.Black);
                }

                if (_selectedTower != null)
                {
                    spriteBatch.Draw(_properties2, new Rectangle(700, 284, (_properties2.Width * 3) / 2, (_properties2.Height * 3) / 2), Color.LightGray);
                    spriteBatch.DrawString(_statsFont, "Power : " + _selectedTower.GetPower(), new Vector2(740, 295), Color.Black);
                    spriteBatch.DrawString(_statsFont, "Speed : " + _selectedTower.GetSpeed(), new Vector2(740, 325), Color.Black);
                    spriteBatch.DrawString(_statsFont, "Lag : " + _selectedTower.GetRate(), new Vector2(940, 295), Color.Black);
                    spriteBatch.DrawString(_statsFont, "Range : " + _selectedTower.GetRange(), new Vector2(940, 325), Color.Black);
                    spriteBatch.DrawString(_commentFont, _selectedTower.GetComment(), new Vector2(730, 365), Color.Black);

                    foreach(Tower evolution in _selectedTower.Evolutions)
                    {
                        Rectangle _rect = new Rectangle((int)evolution.GetPos().X, (int)evolution.GetPos().Y, evolution.Sprite.Width, evolution.Sprite.Height);
                        if (evolution.Price() > _player.CurrentGold)
                        {
                            spriteBatch.Draw(evolution.Sprite, _rect, Color.Black);
                        }
                        else if (_rect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                        {
                            spriteBatch.Draw(evolution.Sprite, _rect, Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(evolution.Sprite, _rect, Color.LightGray);
                        }

                        if (_rect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            spriteBatch.Draw(_properties, new Rectangle(200, 350, (_properties.Width * 3) / 2, (_properties.Height * 3) / 2), Color.LightGray);
                            spriteBatch.DrawString(_statsFont, "Power : " + evolution.GetPower(), new Vector2(240, 360), Color.Black);
                            spriteBatch.DrawString(_statsFont, "Speed : " + evolution.GetSpeed(), new Vector2(240, 390), Color.Black);
                            spriteBatch.DrawString(_statsFont, "Lag : " + evolution.GetRate(), new Vector2(440, 360), Color.Black);
                            spriteBatch.DrawString(_statsFont, "Range : " + evolution.GetRange(), new Vector2(440, 390), Color.Black);
                            spriteBatch.DrawString(_commentFont, evolution.GetComment(), new Vector2(230, 430), Color.Black);

                            if (evolution.Price() > _player.CurrentGold)
                            {
                                spriteBatch.DrawString(_statsFont, "Price : " + evolution.Price() + " Vang", new Vector2(300, 474), Color.Red);
                            }
                            else
                            {
                                spriteBatch.DrawString(_statsFont, "Price : " + evolution.Price() + " Vang", new Vector2(300, 474), Color.Green);
                            }
                        }
                    }

                    if (_sellRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Released)
                    {
                        spriteBatch.Draw(_sellButton, _sellRect, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(_sellButton, _sellRect, Color.LightGray);
                    }
                }
            }
            if(gameState == GameState.inGame)
            {
                spriteBatch.DrawString(_mainSpriteFont, myName, new Vector2(150, 10), Color.White);
                foreach (ElementMenu element in inGame)
                {
                    element.Draw(spriteBatch);
                }
            }
            if (gameState == GameState.shopTower)
            {
                foreach (ElementMenu element in shopTower)
                {
                    element.Draw(spriteBatch);
                }
                if (_placeTowers.Selected() == false)
                {
                    spriteBatch.Draw(_bgTowers, new Rectangle(138, 580, _bgTowers.Width, _bgTowers.Height), Color.LightGray);
                    foreach (TowerShop tower in _placeTowers.Towers())
                    {
                        Rectangle _rect = new Rectangle((int)tower.Position.X, (int)tower.Position.Y, tower.Sprite.Width, tower.Sprite.Height);

                        if(tower.Price > _player.CurrentGold)
                        {
                            spriteBatch.Draw(tower.Sprite, _rect, Color.Black);
                        }
                        else if (_rect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                        {
                            spriteBatch.Draw(tower.Sprite, _rect, Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(tower.Sprite, _rect, Color.LightGray);
                        }

                        if (_rect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            spriteBatch.Draw(_properties, new Rectangle(200, 350, (_properties.Width * 3) / 2, (_properties.Height * 3) / 2), Color.LightGray);
                            spriteBatch.DrawString(_statsFont, "Power : " + tower.Power, new Vector2(240, 360), Color.Black);
                            spriteBatch.DrawString(_statsFont, "Speed : " + tower.Speed, new Vector2(240, 390), Color.Black);
                            spriteBatch.DrawString(_statsFont, "Lag : " + tower.Rate, new Vector2(440, 360), Color.Black);
                            spriteBatch.DrawString(_statsFont, "Range : " + tower.Range, new Vector2(440, 390), Color.Black);
                            spriteBatch.DrawString(_commentFont, tower.Comment, new Vector2(230, 430), Color.Black);

                            if (tower.Price > _player.CurrentGold)
                            {
                                spriteBatch.DrawString(_statsFont, "Price : " + tower.Price + " Vang", new Vector2(300, 474), Color.Red);
                            }
                            else
                            {
                                spriteBatch.DrawString(_statsFont, "Price : " + tower.Price + " Vang", new Vector2(300, 474), Color.Green);
                            }
                            
                        }
                    }
                }
                else
                {
                    spriteBatch.Draw(_placeTowers.SelectedTower().Sprite, new Rectangle((int)_placeTowers.SelectedTower().Position.X, (int)_placeTowers.SelectedTower().Position.Y, _placeTowers.SelectedTower().Sprite.Width, _placeTowers.SelectedTower().Sprite.Height), Color.White);
                }
            }
            if(gameState == GameState.beforeGame)
            {
                foreach (ElementMenu element in beforeGame)
                {
                    element.Draw(spriteBatch);
                }
            }
            if (gameState == GameState.won)
            {
                spriteBatch.DrawString(_endingMessage, "SUCCESS !", new Vector2(370, 100), Color.White);
                spriteBatch.DrawString(_mainFont, "Score : " + _player.Score, new Vector2(450, 200), Color.MediumOrchid);
                foreach (ElementMenu element in won)
                {
                    element.Draw(spriteBatch);
                }
            }
            if (gameState == GameState.lost)
            {
                spriteBatch.DrawString(_endingMessage, "GAME OVER", new Vector2(370, 100), Color.White);
                spriteBatch.DrawString(_mainFont, "Score : " + _player.Score, new Vector2(450, 200), Color.MediumOrchid);
                foreach (ElementMenu element in lost)
                {
                    element.Draw(spriteBatch);
                }
            }
            if (gameState == GameState.difficulty)
            {
                spriteBatch.DrawString(_mainFont, "Choose a difficulty level !", new Vector2(400, 30), Color.DarkSalmon);
                foreach (ElementMenu element in difficulty)
                {
                    element.Draw(spriteBatch);
                }
            }
            spriteBatch.End();

        }


        public void OnClick(string element)
        {
            if (_isPressed == false)
            {
                if (element == "Sprites/play")
                {
                    gameState = GameState.difficulty;
                }
                else if (element == "Sprites/name")
                {
                    gameState = GameState.enterName;
                }
                else if (element == "Sprites/done")
                {
                    gameState = GameState.mainMenu;
                }
                else if (element == "Sprites/towersShop")
                {
                    gameState = GameState.shopTower;
                }
                else if (element == "Sprites/start")
                {
                    gameState = GameState.inGame;
                }
                else if (element == "Sprites/towers2")
                {
                    gameState = GameState.beforeGame;
                }
                else if (element == "Sprites/menu" || element == "Sprites/menuInGame")
                {
                    gameState = GameState.mainMenu;
                    _timer = 30;
                    _towers.Clear();
                    _wavesData = new WavesData();
                    _wavesData.AddInfor(_enemiesData, _level, _player);
                    _wavesData.SetUpWavesData();
                    _waveManager = new WaveManager(_wavesData.Wave);
                    _player.Rewind();
                }
                else if (element == "Sprites/rewind")
                {
                    gameState = GameState.beforeGame;
                    _timer = 30;
                    _towers.Clear();
                    _wavesData.Wave.Clear();
                    _wavesData = new WavesData();
                    _wavesData.AddInfor(_enemiesData, _level, _player);
                    _wavesData.SetUpWavesData();
                    _waveManager = new WaveManager(_wavesData.Wave);
                    _player.Rewind();
                }
                else if (element == "Sprites/scores")
                {
                    gameState = GameState.scores;
                }

                else if (element == "Sprites/easy")
                {
                    _player.ChangeDifficulty(1);
                    gameState = GameState.beforeGame;
                }
                else if (element == "Sprites/normal")
                {
                    _player.ChangeDifficulty(2);
                    gameState = GameState.beforeGame;
                }
                else if (element == "Sprites/hard")
                {
                    _player.ChangeDifficulty(3);
                    gameState = GameState.beforeGame;
                }
                else if (element == "Sprites/lunatic")
                {
                    _player.ChangeDifficulty(4);
                    gameState = GameState.beforeGame;
                }

                else if (element == "Sprites/exit")
                {
                    Exit();
                }
                _isPressed = true;
            }
        }
    }
}
