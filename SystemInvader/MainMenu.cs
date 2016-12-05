using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tutoMonoGame
{
    class MainMenu
    {
        enum GameState { mainMenu, enterName, inGame }

        GameState gameState;

        List<BgMenu> main = new List<BgMenu>();
        List<BgMenu> enterName = new List<BgMenu>();

        private Keys[] lastPressedKeys = new Keys[5];

        private string myName = string.Empty;

        private SpriteFont sf;

        public MainMenu()
        {
            main.Add(new BgMenu("bgMenu"));
            main.Add(new BgMenu("play"));
            main.Add(new BgMenu("name"));
            main.Add(new BgMenu("options"));
            main.Add(new BgMenu("exit"));

            enterName.Add(new BgMenu("enter_name"));
            enterName.Add(new BgMenu("done"));
        }

        public void LoadContent(ContentManager content)
        {
            sf = content.Load<SpriteFont>("userName");
            foreach(BgMenu element in main)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            main.Find(x => x.AssetName == "play").MoveElement(0, -200);
            main.Find(x => x.AssetName == "name").MoveElement(0, -100);
            main.Find(x => x.AssetName == "options").MoveElement(0, 0);
            main.Find(x => x.AssetName == "exit").MoveElement(0, 100);

            foreach (BgMenu element in enterName)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            enterName.Find(x => x.AssetName == "done").MoveElement(0, 60);
        }

        public void Update()
        {
            switch (gameState)
            {
                case GameState.mainMenu:
                    foreach (BgMenu element in main)
                    {
                        element.Update();
                    }
                    break;
                case GameState.enterName:
                    foreach (BgMenu element in enterName)
                    {
                        element.Update();
                    }
                    GetKeys();
                    break;
                case GameState.inGame:
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gameState)
            {
                case GameState.mainMenu:
                    foreach (BgMenu element in main)
                    {
                        element.Draw(spriteBatch);
                    }
                    break;
                case GameState.enterName:
                    foreach (BgMenu element in enterName)
                    {
                        element.Draw(spriteBatch);
                    }
                    spriteBatch.DrawString(sf, myName, new Vector2(290, 300), Color.Black);
                    break;
                case GameState.inGame:
                    break;
                default:
                    break;
            }
        }

        public void OnClick(string element )
        {
            if (element == "play")
            {
                //Play the game
                gameState = GameState.inGame;
            }
            if (element == "name")
            {
                gameState = GameState.enterName;
            }
            if (element == "done")
            {
                gameState = GameState.mainMenu;
            }            
        }

        public void GetKeys()
        {
            KeyboardState kbState = Keyboard.GetState();
            Keys[] pressedKeys = kbState.GetPressedKeys();

            foreach (Keys key in lastPressedKeys)
            {
                if(!pressedKeys.Contains(key))
                {
                    // Key is no longer pressed
                    OnKeyUp(key);
                }
            }

            foreach (Keys key in pressedKeys)
            {
                if(!lastPressedKeys.Contains(key))
                {
                    OnKeyDown(key);
                }
            }
            lastPressedKeys = pressedKeys;
        }

        public void OnKeyUp(Keys key)
        {
        
        }

        public void OnKeyDown(Keys key)
        {
            if (myName.Length > 12)
            {
                if (key == Keys.Back && myName.Length > 0)
                {
                    myName = myName.Remove(myName.Length - 1);
                }
            }
            else
            {
                if (key == Keys.Back && myName.Length > 0)
                {
                    myName = myName.Remove(myName.Length - 1);
                }
                else
                {
                    myName += key.ToString();
                }
            } 
        }
    }
}