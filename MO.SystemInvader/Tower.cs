using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MO.SystemInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tower
{
    int _rate;
    int _range;
    int _type;
    Vector2 _position = new Vector2();
    Texture2D _sprite;
    List<Projectile> _projectiles;

    public Tower(Vector2 position, Texture2D sprite, int rate, int range, int type)
    {
        _position = position;
        _rate = rate;
        _range = range;
        _type = type;
        _sprite = sprite;
        _projectiles = new List<Projectile>();
    }

    public void Shoot(Vector2 enemyPosition, ContentManager content)
    {
        if (_type == 1)
        {
            int speed = 8;
            int power = 10;
            Texture2D texture1 = content.Load<Texture2D>("Sprites/bullet2");
            Texture2D texture2 = content.Load<Texture2D>("Sprites/bullet3");
            Texture2D texture3 = content.Load<Texture2D>("Sprites/bullet4");
            Texture2D texture4 = content.Load<Texture2D>("Sprites/bullet5");
            Texture2D texture5 = content.Load<Texture2D>("Sprites/bullet6");

            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 200, _position.Y), speed, power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 175, _position.Y + 25), speed, power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y + 50), speed, power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 125, _position.Y + 75), speed, power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y + 100), speed, power, texture5, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 75, _position.Y + 125), speed, power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y + 150), speed, power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 25, _position.Y + 175), speed, power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y + 200), speed, power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 25, _position.Y + 175), speed, power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y + 150), speed, power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 75, _position.Y + 125), speed, power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y + 100), speed, power, texture5, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 125, _position.Y + 75), speed, power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y + 50), speed, power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 175, _position.Y + 25), speed, power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 200, _position.Y), speed, power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 175, _position.Y - 25), speed, power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y - 50), speed, power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 125, _position.Y - 75), speed, power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y - 100), speed, power, texture5, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 75, _position.Y - 125), speed, power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y - 150), speed, power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 25, _position.Y - 175), speed, power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y - 200), speed, power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 25, _position.Y - 175), speed, power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y - 150), speed, power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 75, _position.Y - 125), speed, power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y - 100), speed, power, texture5, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 125, _position.Y - 75), speed, power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y - 50), speed, power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 175, _position.Y - 25), speed, power, texture2, 1));
        }
        else if (_type == 2)
        {
            int speed = 16;
            int power = 5;
            Texture2D texture = content.Load<Texture2D>("Sprites/bullet7");
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 200, enemyPosition.Y), new Vector2(enemyPosition.X, enemyPosition.Y), speed, power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 200, enemyPosition.Y), new Vector2(enemyPosition.X, enemyPosition.Y), speed, power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X, enemyPosition.Y + 200), new Vector2(enemyPosition.X, enemyPosition.Y), speed, power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X, enemyPosition.Y - 200), new Vector2(enemyPosition.X, enemyPosition.Y), speed, power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 200, enemyPosition.Y + 200), new Vector2(enemyPosition.X, enemyPosition.Y), speed, power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 200, enemyPosition.Y - 200), new Vector2(enemyPosition.X, enemyPosition.Y), speed, power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 200, enemyPosition.Y + 200), new Vector2(enemyPosition.X, enemyPosition.Y), speed, power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 200, enemyPosition.Y - 200), new Vector2(enemyPosition.X, enemyPosition.Y), speed, power, texture, 1));
        }
        else if (_type == 3)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, 8, 12, content.Load<Texture2D>("Sprites/bullet8"), 2));
        }
        else if (_type == 4)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, 24, 24, content.Load<Texture2D>("Sprites/bullet10"), 3));
        }
        else if (_type == 5)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, 24, 8, content.Load<Texture2D>("Sprites/bullet9"), 4));
        }
    }

    public int GetRange()
    {
        return _range;
    }

    public int GetRate()
    {
        return _rate;
    }

    public Vector2 GetPos()
    {
        return _position;
    }

    public Texture2D Sprite
    {
        get { return _sprite; }
    }

    public List<Projectile> GetProjectiles()
    {
        return _projectiles;
    }
}
