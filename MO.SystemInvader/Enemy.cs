﻿using System;
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
        int _Health;
        int _currentHealth;
        int _price;
        int _strength;

        bool _atTheEnd = false;
        bool _inGame = true;

        float _speed;


        Texture2D _texture;
        Vector2 _position;
        Vector2 _velocity;
        Queue<Vector2> _waypoints = new Queue<Vector2>();
        Player _player;

        //Fonctions///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Enemy(Texture2D texture, Vector2 position, int health, int bountyGiven, int strength, float speed, Player player)
        {
            _position = position;
            _texture = texture;
            _Health = health;
            _currentHealth = _Health;
            _price = bountyGiven;
            _strength = strength;
            _speed = speed;
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

        //Update///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update()
        {
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
            }
        }
    }
}
