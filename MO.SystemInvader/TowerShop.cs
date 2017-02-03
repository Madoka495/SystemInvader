using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        int _power;
        int _speed;
        string _comment;
        Vector2 _position = new Vector2();
        Vector2 _original = new Vector2();
        Vector2 _old = new Vector2(-1000, -1000);
        Texture2D _sprite;
        List<Tower> _evolutions;
        SoundEffect _shoot;
        bool _wasPressed = false;

        public TowerShop(Vector2 position, Texture2D sprite, List<Tower> evolutions, int rate, int range, int power, int speed, int type, int price, string comment, SoundEffect shoot)
        {
            _rate = rate;
            _range = range;
            _type = type;
            _position = position;
            _original = position;
            _price = price;
            _sprite = sprite;
            _power = power;
            _speed = speed;
            _comment = comment;
            _evolutions = evolutions;
            _shoot = shoot;
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
        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int Range
        {
            get { return _range; }
            set { _range = value; }
        }
        public int Price
        {
            get { return _price; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public Texture2D Sprite
        {
            get { return _sprite; }
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
        public List<Tower> Evolutions
        {
            get { return _evolutions; }
        }
        public SoundEffect Shoot
        {
            get { return _shoot; }
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
