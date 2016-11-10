using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemInvader
{
    public class Projectile
    {
        Vector2 _current = new Vector2();
        Vector2 _dest = new Vector2();
        Vector2 _start = new Vector2();
        int _speed;

        public Projectile(Vector2 start, Vector2 dest, int speed)
        {
            _current = start;
            _dest = dest;
            _start = start;
            _speed = speed;
        }

        public void Update()
        {
            if(_current.X < _dest.X)
            {
                _current.X += (_dest.X - _start.X) / 100 * _speed;
            }
            else if(_current.X > _dest.X)
            {
                _current.X -= (_start.X - _dest.X) / 100 * _speed;
            }

            if (_current.Y < _dest.Y)
            {
                _current.Y += (_dest.Y - _start.Y) / 100 * _speed;
            }
            else if (_current.Y > _dest.Y)
            {
                _current.Y -= (_start.Y - _dest.Y) / 100 * _speed;
            }
        }

        public bool DestReached()
        {
            if (_current.X == _dest.X && _current.Y == _dest.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Vector2 GetPos()
        {
            return _current;
        }
    }
}
