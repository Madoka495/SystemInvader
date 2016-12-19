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

        bool _atTheEnd = false;
        bool _inGame = true;

        float _speed;
        float _percent;
        float _negativePercent;


        Texture2D _texture;
        Vector2 _position;
        Vector2 _velocity;
        List<Texture2D> _lifeBar;
        Queue<Vector2> _waypoints = new Queue<Vector2>();
        Player _player;

        //Fonctions///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Enemy(Texture2D texture, Vector2 position, int health, int bountyGiven, int strength, float speed, Player player, List<Texture2D> lifeBar)
        {
            _position = position;
            _texture = texture;
            _health = health;
            _currentHealth = _health;
            _price = bountyGiven;
            _strength = strength;
            _speed = speed;
            _player = player;
            _lifeBar = lifeBar;
        }

        public void SetWaypoints(Queue<Vector2> waypointsRefer)
        {
            foreach (Vector2 waypoint in waypointsRefer)
                _waypoints.Enqueue(waypoint);

            _position = _waypoints.Dequeue();
        }

        public int BountyGiven => _price;
        public int GiveHealth => _health;
        public int GiveStrength => _strength;

        public float DistanceToDestination => Vector2.Distance(_position, _waypoints.Peek());
        public float GiveSpeed => _speed;

        public Texture2D GiveTexture => _texture;
        public Vector2 GetPos() => _position;

        public bool InGame
        {
            get { return _inGame; }
            set { _inGame = value; }
        }

        public void Deal(int damages)
        {
            _currentHealth -= damages;
        }

        public void AtTheEnd()
        {
            _atTheEnd = true;
        }

        public List<Texture2D> LifeBar
        {
            get { return _lifeBar; }
        }

        //Update///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update()
        {
            if (_currentHealth <= 0 && _inGame)
            {
                _player.Score += ((int) _speed + _strength + _health);
                _player.CurrentGold += _price;
                _inGame = false;
            }
            else if (_atTheEnd && _inGame)
            {
                _player.Life -= _strength;
                _inGame = false;
            }

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


        //Draw///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_inGame)
            {
                spriteBatch.Draw(_texture, new Rectangle((int)GetPos().X, (int)GetPos().Y, _texture.Width, _texture.Height), Color.White);

                _percent = ((float)_currentHealth / (float)_health) * 100;
                Console.WriteLine("life : " + _currentHealth + " / " + _health);
                for (int n = 0; n < _percent; n++)
                {
                    if(_percent < 10)
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
