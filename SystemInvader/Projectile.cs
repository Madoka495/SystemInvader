using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SystemInvader
{
    public class Projectile
    {
        //Parametres///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Vector2 _current = new Vector2();
        Vector2 _dest = new Vector2();
        Vector2 _start = new Vector2();
        Vector2 _diff = new Vector2();
        Texture2D _texture;

        int _speed;
        bool _xPos;
        bool _yPos;
        bool _reached;
        int _power;
        int _bulletWidth;
        int _bulletHeight;

        //Fonctions///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Projectile(Texture2D texture ,Vector2 start, Vector2 dest, int speed, int power, int bulletWidth, int bulletHeight)
        {
            _texture = texture;
            _current = start;
            _dest = dest;
            _start = start;
            _speed = speed;
            _power = power;
            _texture = texture;
            _bulletHeight = bulletHeight;
            _bulletWidth = bulletWidth;
        }

        public bool DestReached
        {
            get { return _reached; }
            set { _reached = value; }
        }
        public int Power() => _power;

        public Vector2 GetPos() => _current;

        public bool hitEnemy(Vector2 enemy, Texture2D bullet)
        {
            if (_current.X <= enemy.X &&
                _current.X + bullet.Width >= enemy.X &&
                _current.Y <= enemy.Y &&
                _current.Y + bullet.Height >= enemy.Y)
                return true;
            return false;
        }



        //Update///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update()
        {
            if(_start.X < _dest.X)
            {
                _xPos = true;
                _diff.X = _dest.X - _start.X;
            }
            else if(_start.X > _dest.X)
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

            if(Math.Abs(_diff.X) == Math.Abs(_diff.Y))
            {
                if(_xPos == true)
                {
                    _current.X += _speed;
                }
                else if(_xPos == false)
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
            else if(Math.Abs(_diff.X) > Math.Abs(_diff.Y))
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

        //Draw///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)GetPos().X, (int)GetPos().Y, _bulletWidth, _bulletHeight), Color.White);
        }


    }
}
