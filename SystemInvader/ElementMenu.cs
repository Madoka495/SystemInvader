using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SystemInvader
{
    class ElementMenu
    {
        Texture2D _menuTexture;
        Rectangle _menuRect;
        bool _wasClicked = false;
        string _assetName;

        public string AssetName
        {
            get { return _assetName; }
            set { _assetName = value; }
        }

        public delegate void ElementClicked(string element);
        public event ElementClicked clickEvent;

        public ElementMenu(string assetName)
        {
            _assetName = assetName;
        }

        public void LoadContent(ContentManager content)
        {
            _menuTexture = content.Load<Texture2D>(AssetName);
            _menuRect = new Rectangle(0, 0, _menuTexture.Width, _menuTexture.Height);
        }

        public void Update()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (_menuRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && _wasClicked == false)
                {
                    clickEvent(_assetName);
                }
                else
                {
                    _wasClicked = true;
                }
            }
            else
            {
                _wasClicked = false;
            }
        }

        public void CenterElement(int height, int width)
        {
            _menuRect = new Rectangle((width / 2) - (_menuTexture.Width / 2), (height / 2) - (_menuTexture.Height / 2), _menuTexture.Width, _menuTexture.Height);
        }

        public void MoveElement(int x, int y)
        {
             _menuRect = new Rectangle(_menuRect.X += x, _menuRect.Y += y, _menuRect.Width, _menuRect.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_menuTexture, _menuRect, Color.White);
        }

    }
}

