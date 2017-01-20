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
        private int _type;
        Tower _tower;

        Vector2 _position = new Vector2();
        Vector2 _original = new Vector2();
        Vector2 _posBase = new Vector2();
        Vector2 _old = new Vector2(-1000, -1000);
        bool _isSetup = false;

        public TowerShop(Vector2 position, Tower tower, int type)
        {
            _type = type;
            _position = position;
            _original = position;
            _tower = tower;
        }
        public Tower GiveTower => _tower;

        /*public int Type
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

        public int Price => _price;*/

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

        public bool IsSetup
        {
            get { return _isSetup; }
            set { _isSetup = value; }
        }

        public Vector2 Base
        {
            get { return _posBase; }
            set { _posBase = value; }
        }

        public int ConvertToNearestTile(int value)
        {
            int newValue = (int)(value / 32);
            newValue = newValue * 32;

            return newValue;
        }
    }
}
