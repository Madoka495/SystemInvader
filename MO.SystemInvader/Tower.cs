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
            _projectiles.Add(new Projectile(_position, enemyPosition, 8, 20, content.Load<Texture2D>("Sprites/bullet1")));
        }
        else if (_type == 2)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, 15, 5, content.Load<Texture2D>("Sprites/bullet2")));
        }
        else if (_type == 3)
        {
            int speed = 8;
            int power = 30;
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 200, _position.Y), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 175, _position.Y + 25), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y + 50), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 125, _position.Y + 75), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y + 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 75, _position.Y + 125), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y + 150), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 25, _position.Y + 175), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y + 200), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 25, _position.Y + 175), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y + 150), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 75, _position.Y + 125), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y + 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 125, _position.Y + 75), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y + 50), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 175, _position.Y + 25), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 200, _position.Y), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 175, _position.Y - 25), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y - 50), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 125, _position.Y - 75), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y - 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 75, _position.Y - 125), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y - 150), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 25, _position.Y - 175), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y - 200), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 25, _position.Y - 175), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y - 150), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 75, _position.Y - 125), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y - 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 125, _position.Y - 75), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y - 50), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 175, _position.Y - 25), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
        }
        else if (_type == 4)
        {
            int speed = 12;
            int power = 5;
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 100, enemyPosition.Y), new Vector2(enemyPosition.X + 100, enemyPosition.Y), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 100, enemyPosition.Y), new Vector2(enemyPosition.X - 100, enemyPosition.Y), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X, enemyPosition.Y + 100), new Vector2(enemyPosition.X, enemyPosition.Y - 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X, enemyPosition.Y - 100), new Vector2(enemyPosition.X, enemyPosition.Y + 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 100, enemyPosition.Y + 100), new Vector2(enemyPosition.X - 100, enemyPosition.Y - 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 100, enemyPosition.Y - 100), new Vector2(enemyPosition.X + 100, enemyPosition.Y + 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 100, enemyPosition.Y + 100), new Vector2(enemyPosition.X + 100, enemyPosition.Y - 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 100, enemyPosition.Y - 100), new Vector2(enemyPosition.X - 100, enemyPosition.Y + 100), speed, power, content.Load<Texture2D>("Sprites/bullet2")));
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
