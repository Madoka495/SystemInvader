using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO.SystemInvader
{
    public class Projectile
    {
        Vector2 _current = new Vector2();
        Vector2 _dest = new Vector2();
        Vector2 _start = new Vector2();
        Vector2 _diff = new Vector2();
        Texture2D _sprite;
        int _speed;
        bool _xPos;
        bool _yPos;
        bool _reached;
        int _power;
        int _type;

        public Projectile(Vector2 start, Vector2 dest, int speed, int power, Texture2D sprite, int type)
        {
            _current = start;
            _dest = dest;
            _start = start;
            _speed = speed;
            _power = power;
            _sprite = sprite;
            _type = type;
        }

        public Texture2D Sprite
        {
            get { return _sprite; }
        }

        public void Update()
        {
            if (_start.X < _dest.X)
            {
                _xPos = true;
                _diff.X = _dest.X - _start.X;
            }
            else if (_start.X > _dest.X)
            {
                _xPos = false;
                _diff.X = _start.X - _dest.X;
            }

            if (_start.Y < _dest.Y)
            {
                _yPos = true;
                _diff.Y = _dest.Y - _start.Y;
            }
            else if (_start.Y > _dest.Y)
            {
                _yPos = false;
                _diff.Y = _start.Y - _dest.Y;
            }

            if (Math.Abs(_diff.X) == Math.Abs(_diff.Y))
            {
                if (_xPos == true)
                {
                    _current.X += _speed;
                }
                else if (_xPos == false)
                {
                    _current.X -= _speed;
                }

                if (_yPos == true)
                {
                    _current.Y += _speed;
                }
                else if (_yPos == false)
                {
                    _current.Y -= _speed;
                }
            }
            else if (Math.Abs(_diff.X) > Math.Abs(_diff.Y))
            {
                if (_xPos == true)
                {
                    _current.X += _speed;
                }
                else if (_xPos == false)
                {
                    _current.X -= _speed;
                }

                if (_yPos == true)
                {
                    _current.Y += Math.Abs(_diff.Y) / Math.Abs(_diff.X) * _speed;
                }
                else if (_yPos == false)
                {
                    _current.Y -= Math.Abs(_diff.Y) / Math.Abs(_diff.X) * _speed;
                }
            }
            else if (Math.Abs(_diff.X) < Math.Abs(_diff.Y))
            {
                if (_xPos == true)
                {
                    _current.X += Math.Abs(_diff.X) / Math.Abs(_diff.Y) * _speed;
                }
                else if (_xPos == false)
                {
                    _current.X -= Math.Abs(_diff.X) / Math.Abs(_diff.Y) * _speed;
                }

                if (_yPos == true)
                {
                    _current.Y += _speed;
                }
                else if (_yPos == false)
                {
                    _current.Y -= _speed;
                }
            }
            if (_start.X < _dest.X)
            {
                if (_start.Y < _dest.Y)
                {
                    if (_current.X >= _dest.X && _current.Y >= _dest.Y)
                    {
                        _reached = true;
                    }
                    else
                    {
                        _reached = false;
                    }
                }
                else
                {
                    if (_current.X >= _dest.X && _current.Y <= _dest.Y)
                    {
                        _reached = true;
                    }
                    else
                    {
                        _reached = false;
                    }
                }
            }
            else
            {
                if (_start.Y < _dest.Y)
                {
                    if (_current.X <= _dest.X && _current.Y >= _dest.Y)
                    {
                        _reached = true;
                    }
                    else
                    {
                        _reached = false;
                    }
                }
                else
                {
                    if (_current.X <= _dest.X && _current.Y <= _dest.Y)
                    {
                        _reached = true;
                    }
                    else
                    {
                        _reached = false;
                    }
                }
            }
        }

        public bool DestReached
        {
            get
            {
                return _reached;
            }
            set
            {
                _reached = value;
            }
        }

        public int Power()
        {
            return _power;
        }

        public int Type()
        {
            return _type;
        }

        public Vector2 GetPos()
        {
            return _current;
        }
    }
}
