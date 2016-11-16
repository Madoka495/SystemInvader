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
        protected int _Health;
        protected int _currentHealth;

        protected bool _alive = true;

        protected float _speed;
        protected int _price;

        protected Texture2D _texture;

        protected Vector2 _position;
        protected Vector2 _velocity;

        public Enemy(Texture2D texture, Vector2 position, int health, int bountyGiven, float speed)
        {
            _texture = texture;
            _position = position;

            _Health = health;
            _currentHealth = _Health;
            _price = bountyGiven;
            _speed = speed;
        }

        //public bool IsDead => _currentHealth <= 0;
        //public int BountyGiven => _price;
        
        private Queue<Vector2> _waypoints = new Queue<Vector2>();

        public void SetWaypoints(Queue<Vector2> waypointsRefer)
        {
            foreach (Vector2 waypoint in waypointsRefer)
                _waypoints.Enqueue(waypoint);

            _position = _waypoints.Dequeue();
        }

        public float DistanceToDestination => Vector2.Distance(_position, _waypoints.Peek());

        public void Update(GameTime gameTime)
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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(_alive)
                spriteBatch.Draw(_texture, _position, Color.White);
        }

    }
}
