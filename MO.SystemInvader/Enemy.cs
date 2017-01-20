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
        private int _Health;
        private int _currentHealth;
        private int _price;
        private int _enemyWidth;
        private int _enemyHeight;
        private int _strength;
        
        private bool _atTheEnd = false;
        private float _timeChangeSprite;
        private float _speed;
        
        bool _inGame = true;

        Texture2D _texture;
        Vector2 _position;
        Vector2 _oldPosition;
        Vector2 _velocity;
        Queue<Vector2> _waypoints = new Queue<Vector2>();
        Point _spritesEnemy = new Point(0, 0);
        Point _limitSprites = new Point(3, 4);
        Player _player;

        //Fonctions///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Enemy(Texture2D texture, Vector2 position, int health, int bountyGiven, int strength, float speed, int enemyWidth, int enemyHeight, Player player)
        {
            _position = position;
            _texture = texture;
            _Health = health;
            _currentHealth = _Health;
            _price = bountyGiven;
            _speed = speed;
            _enemyWidth = enemyWidth;
            _enemyHeight = enemyHeight;
            _strength = strength;
            _player = player;
        }

        public void SetWaypoints(Queue<Vector2> waypointsRefer)
        {
            foreach (Vector2 waypoint in waypointsRefer)
                _waypoints.Enqueue(waypoint);

            _position = _waypoints.Dequeue();
        }

        public int BountyGiven => _price;
        public int GiveHealth => _Health;
        public int GiveBounty => _price;
        public int GiveWidth => _enemyWidth;
        public int GiveHeight => _enemyHeight;
        public int GiveCurrentHealth => _currentHealth;
        public int GiveStrength => _strength;

        public float DistanceToDestination => Vector2.Distance(_position, _waypoints.Peek());
        public float GiveSpeed => _speed;
        public bool InGame => _inGame;

        public Texture2D GiveTexture => _texture;
        public Vector2 GetPos() => _position;

        public void Deal(int damages)
        {
            _currentHealth -= damages;
        }

        public void AtTheEnd()
        {
            _atTheEnd = true;
        }

        //Animation////////////////////////////////////////
        public void SpritesUpdate()
        {
            if (_spritesEnemy.X < _limitSprites.X - 1)
                _spritesEnemy.X += 1;
            else
                _spritesEnemy.X = 0;
            _timeChangeSprite = 0;
        }

        public void MoveDirection(Vector2 oldPosition, Vector2 newPosition)
        {
            if (newPosition.X > oldPosition.X)//Left to Right
            {
                _spritesEnemy.Y = 2;
            }
            else if (newPosition.X < oldPosition.X)//Right to Left
            {
                _spritesEnemy.Y = 1;
            }
            else if (newPosition.Y > oldPosition.Y)//Down
            {
                _spritesEnemy.Y = 0;
            }
            else if (newPosition.Y < oldPosition.Y)//Up
            {
                _spritesEnemy.Y = 3;
            }
        }
        //Update///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update(GameTime gameTime)
        {
            //Animation
            MoveDirection(_oldPosition, _position);
            _timeChangeSprite += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timeChangeSprite > 0.1)
            {
                SpritesUpdate();
            }

            if (_currentHealth <= 0 && _inGame)
            {
                _player.Score++;
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
                    _oldPosition = _position;
                    _position += _velocity;
                }
            }
        }


        //Draw///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_inGame)
            {
                spriteBatch.Draw(_texture,
                    new Rectangle((int)GetPos().X - (int)_enemyWidth / 2, (int)GetPos().Y - (int)_enemyHeight/2 - (int)_enemyHeight/4, _enemyWidth, _enemyHeight),
                    new Rectangle(_spritesEnemy.X * _enemyWidth, _spritesEnemy.Y * _enemyHeight, _enemyWidth, _enemyHeight), 
                    Color.White);
            }
        }
    }
}
