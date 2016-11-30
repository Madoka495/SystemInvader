using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VirusInvader
{
    public class Enemy
    {
        //Parametre///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected int _Health;
        protected int _currentHealth;
        protected int _price;
        protected int _enemyWidth;
        protected int _enemyHeight;

        protected bool _alive = true;
        protected bool _atTheEnd = false;

        protected float _speed;
        

        Texture2D _texture;
        Vector2 _position;
        Vector2 _velocity;
        Queue<Vector2> _waypoints = new Queue<Vector2>();

        //Fonctions///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Enemy(Texture2D texture, Vector2 position, int health, int bountyGiven, float speed, int enemyWidth, int enemyHeight)
        {
            _position = position;
            _texture = texture;

            _Health = health;
            _currentHealth = _Health;
            _price = bountyGiven;
            _speed = speed;
            _enemyWidth = enemyWidth;
            _enemyHeight = enemyHeight;
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

        public float DistanceToDestination => Vector2.Distance(_position, _waypoints.Peek());
        public float GiveSpeed => _speed;
        public bool IsDead => _currentHealth <= 0;
        
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

        //Update///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update()
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
            else
                _alive = false;
        }


        //Draw///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead && !_atTheEnd)
            {
                spriteBatch.Draw(_texture, new Rectangle((int)GetPos().X, (int)GetPos().Y, _enemyWidth, _enemyHeight), Color.White);
            }
        }

        

    }
}
