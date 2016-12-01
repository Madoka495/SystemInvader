using Microsoft.Xna.Framework;
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
        int _width;
        int _height;
        Vector2 _position = new Vector2();
        Vector2 _original = new Vector2();
        Vector2 _old = new Vector2(-1000, -1000);
        bool _wasPressed = false;

        public TowerShop(Vector2 position, int rate, int range, int width, int height, int type)
        {
            _rate = rate;
            _range = range;
            _width = width;
            _height = height;
            _type = type;
            _position = position;
            _original = position;
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
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
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
    }
}
