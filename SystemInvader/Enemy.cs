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

        protected Vector2 _position;
        protected Vector2 _velocity;

        Queue<Vector2> waypoints = new Queue<Vector2>();


        public Enemy(Vector2 position, int health, int bountyGiven, float speed)
        {
            _position = position;

            _Health = health;
            _currentHealth = _Health;
            _price = bountyGiven;
            _speed = speed;

            waypoints.Enqueue(new Vector2(2, 0) * 32);
            waypoints.Enqueue(new Vector2(2, 2) * 32);
            waypoints.Enqueue(new Vector2(4, 2) * 32);
            waypoints.Enqueue(new Vector2(4, 7) * 32);
            waypoints.Enqueue(new Vector2(1, 7) * 32);
            waypoints.Enqueue(new Vector2(1, 4) * 32);
            waypoints.Enqueue(new Vector2(9, 4) * 32);
            waypoints.Enqueue(new Vector2(9, 8) * 32);
            waypoints.Enqueue(new Vector2(14, 8) * 32);
            waypoints.Enqueue(new Vector2(14, 5) * 32);
            waypoints.Enqueue(new Vector2(18, 5) * 32);
            waypoints.Enqueue(new Vector2(18, 12) * 32);
            waypoints.Enqueue(new Vector2(16, 12) * 32);
            waypoints.Enqueue(new Vector2(16, 10) * 32);
            waypoints.Enqueue(new Vector2(23, 10) * 32);
            waypoints.Enqueue(new Vector2(23, 14) * 32);
            waypoints.Enqueue(new Vector2(12, 14) * 32);
            waypoints.Enqueue(new Vector2(12, 11) * 32);
            waypoints.Enqueue(new Vector2(5, 11) * 32);
            waypoints.Enqueue(new Vector2(5, 12) * 32);
            waypoints.Enqueue(new Vector2(4, 12) * 32);
            waypoints.Enqueue(new Vector2(4, 14) * 32);
        }

        public Vector2 GetPos()
        {
            return _position;
        }

        /* public void SetWaypoints(Queue<Vector2> waypointsRefer)
        {
            foreach (Vector2 waypoint in waypointsRefer)
                _waypoints.Enqueue(waypoint);

            _position = _waypoints.Dequeue();
        }*/ 

        public float DistanceToDestination => Vector2.Distance(_position, waypoints.Peek());

        public void Update()
        {
            if (waypoints.Count > 0)
            {
                if (DistanceToDestination < _speed)
                {
                    _position = waypoints.Peek();
                    waypoints.Dequeue();
                }

                else
                {
                    Vector2 direction = waypoints.Peek() - _position;
                    direction.Normalize();

                    _velocity = Vector2.Multiply(direction, _speed);

                    _position += _velocity;
                }
            }
            else
                _alive = false;

        }
        public void Deal(int damages)
        {
            _currentHealth -= damages;
        }
        public bool IsDead => _currentHealth <= 0;
        public int BountyGiven => _price;

    }
}
