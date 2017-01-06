using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO.SystemInvader
{
    public class TowerShop
    {
        int _type;
        int _rate;
        int _range;
        int _price;
        Vector2 _position = new Vector2();
        Vector2 _original = new Vector2();
        Vector2 _old = new Vector2(-1000, -1000);
        Texture2D _sprite;
        bool _wasPressed = false;

        public TowerShop(Vector2 position, Texture2D sprite, int rate, int range, int type, int price)
        {
            _rate = rate;
            _range = range;
            _type = type;
            _position = position;
            _original = position;
            _price = price;
            _sprite = sprite;
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        public int Range
        {
            get { return _range; }
            set { _range = value; }
        }
        public Texture2D Sprite
        {
            get { return _sprite; }
        }

        public int Price
        {
            get { return _price; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Vector2 Old
        {
            get { return _old; }
            set { _old = value; }
        }
        public Vector2 Original
        {
            get { return _original; }
        }

        public bool WasPressed
        {
            get { return _wasPressed; }
            set { _wasPressed = value; }
        }

        public int ConvertToNearestTile(int value)
        {
            int newValue = (int)(value / 32);
            newValue = newValue * 32;

            return newValue;
        }
    }
}
