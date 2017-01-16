using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MO.SystemInvader
{
    public class Enemy
    {
        //Parametre///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        int _health;
        int _currentHealth;
        int _price;
        int _strength;
        int i;
        int _frame = 0;
        int _type;

        bool _atTheEnd = false;
        bool _inGame = true;

        float _speed;
        float _baseSpeed;
        float _percent;
        float _negativePercent;


        Texture2D _texture;
        Vector2 _position;
        Vector2 _velocity;
        List<Texture2D> _lifeBar;
        Queue<Vector2> _waypoints = new Queue<Vector2>();
        Player _player;

        int _slowDown = 0;
        int _frozen = 0;
        bool _psn = false;

        //Fonctions///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Enemy(Texture2D texture, Vector2 position, int health, int bountyGiven, int strength, float speed, int type, Player player, List<Texture2D> lifeBar)
        {
            _position = position;
            _texture = texture;
            _health = health;
            _currentHealth = _health;
            _price = bountyGiven;
            _strength = strength;
            _speed = speed;
            _type = type;
            _baseSpeed = speed;
            _player = player;
            _lifeBar = lifeBar;
        }

        public void SetWaypoints()
        {
            if(_type == 1) // Base
            {
                _waypoints.Enqueue(new Vector2(0, 3) * 32);
                _waypoints.Enqueue(new Vector2(3, 3) * 32);
                _waypoints.Enqueue(new Vector2(3, 4) * 32);
                _waypoints.Enqueue(new Vector2(5, 4) * 32);
                _waypoints.Enqueue(new Vector2(5, 10) * 32);
                _waypoints.Enqueue(new Vector2(2, 10) * 32);
                _waypoints.Enqueue(new Vector2(2, 7) * 32);
                _waypoints.Enqueue(new Vector2(10, 7) * 32);
                _waypoints.Enqueue(new Vector2(10, 10) * 32);
                _waypoints.Enqueue(new Vector2(17, 10) * 32);
                _waypoints.Enqueue(new Vector2(17, 7) * 32);
                _waypoints.Enqueue(new Vector2(23, 7) * 32);
                _waypoints.Enqueue(new Vector2(23, 18) * 32);
                _waypoints.Enqueue(new Vector2(21, 18) * 32);
                _waypoints.Enqueue(new Vector2(18, 15) * 32);
                _waypoints.Enqueue(new Vector2(18, 13) * 32);
                _waypoints.Enqueue(new Vector2(31, 13) * 32);
                _waypoints.Enqueue(new Vector2(31, 21) * 32);
                _waypoints.Enqueue(new Vector2(13, 21) * 32);
                _waypoints.Enqueue(new Vector2(13, 15) * 32);
                _waypoints.Enqueue(new Vector2(6, 15) * 32);
                _waypoints.Enqueue(new Vector2(6, 17) * 32);
                _waypoints.Enqueue(new Vector2(5, 17) * 32);
                _waypoints.Enqueue(new Vector2(5, 22) * 32);
            }
            else if(_type == 2) // Shortcut
            {
                _waypoints.Enqueue(new Vector2(0, 1) * 32);
                _waypoints.Enqueue(new Vector2(3, 1) * 32);
                _waypoints.Enqueue(new Vector2(3, 2) * 32);
                _waypoints.Enqueue(new Vector2(5, 2) * 32);
                _waypoints.Enqueue(new Vector2(5, 5) * 32);
                _waypoints.Enqueue(new Vector2(10, 5) * 32);
                _waypoints.Enqueue(new Vector2(10, 8) * 32);
                _waypoints.Enqueue(new Vector2(17, 8) * 32);
                _waypoints.Enqueue(new Vector2(17, 5) * 32);
                _waypoints.Enqueue(new Vector2(23, 5) * 32);
                _waypoints.Enqueue(new Vector2(23, 11) * 32);
                _waypoints.Enqueue(new Vector2(31, 11) * 32);
                _waypoints.Enqueue(new Vector2(31, 19) * 32);
                _waypoints.Enqueue(new Vector2(13, 19) * 32);
                _waypoints.Enqueue(new Vector2(13, 13) * 32);
                _waypoints.Enqueue(new Vector2(6, 13) * 32);
                _waypoints.Enqueue(new Vector2(6, 14) * 32);
                _waypoints.Enqueue(new Vector2(5, 14) * 32);
                _waypoints.Enqueue(new Vector2(5, 20) * 32);
            }
            else if(_type == 3) // Flying
            {
                _waypoints.Enqueue(new Vector2(0, 1) * 32);
                _waypoints.Enqueue(new Vector2(31, 6) * 32);
                _waypoints.Enqueue(new Vector2(0, 11) * 32);
                _waypoints.Enqueue(new Vector2(5, 20) * 32);
            }

            _position = _waypoints.Dequeue();
        }

        public int BountyGiven => _price;
        public int GiveHealth => _health;
        public int GiveStrength => _strength;
        public int GiveType => _type;

        public float DistanceToDestination => Vector2.Distance(_position, _waypoints.Peek());
        public float GiveSpeed => _speed;

        public Texture2D GiveTexture => _texture;
        public Vector2 GetPos() => _position;

        public bool InGame
        {
            get { return _inGame; }
            set { _inGame = value; }
        }

        public void Deal(int damages, int type)
        {
            _currentHealth -= damages;
            if(type == 2)
            {
                if(_slowDown < 2)
                {
                    _speed -= _baseSpeed / 5;
                    _slowDown++;
                }
            }
            else if(type == 3)
            {
                if(_frozen == 0 || _frame >= _frozen + 180)
                {
                    _frozen = _frame;
                }
            }
            else if(type == 4)
            {
                _psn = true;
            }
        }

        public void AtTheEnd()
        {
            _atTheEnd = true;
        }

        public List<Texture2D> LifeBar
        {
            get { return _lifeBar; }
        }

        public Texture2D Sprite
        {
            get { return _texture; }
        }

        //Update///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update()
        {
            if (_currentHealth <= 0 && _inGame)
            {
                _player.Score += ((((int) _speed * 10) + (_strength * 10) + (_health / 10)) / 2) * _player.Difficulty;
                _player.CurrentGold += _price;
                _inGame = false;
            }
            else if (_atTheEnd && _inGame)
            {
                _player.Life -= _strength;
                _inGame = false;
            }

            if(_frozen == 0 || _frozen + 120 < _frame)
            {
                if (_waypoints.Count > 0)
                {
                    if (DistanceToDestination < _speed)
                    {
                        _position = _waypoints.Peek();
                        _waypoints.Dequeue();
                    }

                    else
                    {
                        Vector2 direction = _waypoints.Peek() - _position;
                        direction.Normalize();

                        _velocity = Vector2.Multiply(direction, _speed);

                        _position += _velocity;
                    }
                }
            }
            if(_psn == true && _frame % 30 == 0)
            {
                _currentHealth -= 15;
            }
            _frame++;
        }


        //Draw///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_inGame)
            {
                spriteBatch.Draw(_texture, new Rectangle((int)GetPos().X, (int)GetPos().Y, _texture.Width, _texture.Height), Color.White);

                _percent = ((float)_currentHealth / (float)_health) * 100;
                for (int n = 0; n < _percent; n++)
                {
                    if (_percent < 10)
                    {
                        spriteBatch.Draw(_lifeBar[2], new Rectangle((int)GetPos().X + (_texture.Width / 2) - 50 + n, (int)GetPos().Y, _lifeBar[2].Width, _lifeBar[2].Height), Color.White);
                    }
                    else if (_percent < 50)
                    {
                        spriteBatch.Draw(_lifeBar[1], new Rectangle((int)GetPos().X + (_texture.Width / 2) - 50 + n, (int)GetPos().Y, _lifeBar[1].Width, _lifeBar[1].Height), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(_lifeBar[0], new Rectangle((int)GetPos().X + (_texture.Width / 2) - 50 + n, (int)GetPos().Y, _lifeBar[0].Width, _lifeBar[0].Height), Color.White);
                    }
                    i = n;
                }
                _negativePercent = 100 - _percent;
                for (int n = 0; n < _negativePercent; n++)
                {
                    spriteBatch.Draw(_lifeBar[3], new Rectangle((int)GetPos().X + (_texture.Width / 2) - 50 + n + i, (int)GetPos().Y, _lifeBar[3].Width, _lifeBar[3].Height), Color.White);
                }
            }
        }
    }
}
