using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MO.SystemInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO.SystemInvader
{
    public class Snow
    {
        int _speed;

        private List<Texture2D> _listeTextureSnow = new List<Texture2D>();
        private Vector2[] _snow = new Vector2[50];
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _startPoint;
        private Vector2 _quitPoint;
        private Vector2 _velocity;

        public Snow(Texture2D texture, Vector2 startPoint, Vector2 quitPoint, int speed)
        {
            _speed = speed;
            _texture = texture;
            _quitPoint = quitPoint;
            _position = startPoint;
            _startPoint = startPoint;
        }

        public void Update(Random random)
        {
            Vector2 direction = _quitPoint - _position;
            direction.Normalize();
            _velocity = Vector2.Multiply(direction, _speed);
            _position += _velocity;

            if (_position.Y >= _quitPoint.Y)
            {
                int k = random.Next(0, 1920 - _texture.Width);
                _position = new Vector2(k, _startPoint.Y);
                _quitPoint = new Vector2(k, 1080);
            }
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(_texture,
                new Rectangle((int)GivePos.X, (int)GivePos.Y, _texture.Width, _texture.Height),
                Color.White);
        }

        private Vector2 GivePos => _position;


    }
}
