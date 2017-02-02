using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
    int _power;
    int _speed;
    int _price;
    string _comment;
    bool _inGame = true;
    Vector2 _position = new Vector2();
    Texture2D _sprite;
    List<Projectile> _projectiles;
    List<Tower> _evolutions;
    Player _player;
    SoundEffect _shoot;

    public Tower(Vector2 position, Texture2D sprite, List<Tower> evolutions, int rate, int range, int power, int speed, int price, int type, string comment, SoundEffect shoot, Player player)
    {
        _position = position;
        _rate = rate;
        _range = range;
        _type = type;
        _sprite = sprite;
        _projectiles = new List<Projectile>();
        _power = power;
        _speed = speed;
        _price = price;
        _comment = comment;
        _player = player;
        _evolutions = evolutions;
        _shoot = shoot;
    }

    public void Shoot(Vector2 enemyPosition, ContentManager content)
    {
        if (_type == 1)
        {
            Texture2D texture1 = content.Load<Texture2D>("Sprites/bullet2");
            Texture2D texture2 = content.Load<Texture2D>("Sprites/bullet3");
            Texture2D texture3 = content.Load<Texture2D>("Sprites/bullet4");
            Texture2D texture4 = content.Load<Texture2D>("Sprites/bullet6");

            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 200, _position.Y), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 175, _position.Y + 25), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y + 50), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 125, _position.Y + 75), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y + 100), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 75, _position.Y + 125), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y + 150), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 25, _position.Y + 175), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y + 200), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 25, _position.Y + 175), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y + 150), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 75, _position.Y + 125), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y + 100), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 125, _position.Y + 75), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y + 50), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 175, _position.Y + 25), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 200, _position.Y), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 175, _position.Y - 25), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y - 50), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 125, _position.Y - 75), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y - 100), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 75, _position.Y - 125), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y - 150), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 25, _position.Y - 175), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y - 200), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 25, _position.Y - 175), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y - 150), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 75, _position.Y - 125), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y - 100), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 125, _position.Y - 75), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y - 50), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 175, _position.Y - 25), _speed, _power, texture2, 1));
            _shoot.Play(0.05f, 0.0f, 0.0f);
        }
        else if (_type == 2)
        {
            Texture2D texture = content.Load<Texture2D>("Sprites/bullet7");
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 200, enemyPosition.Y), new Vector2(enemyPosition.X, enemyPosition.Y), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 200, enemyPosition.Y), new Vector2(enemyPosition.X, enemyPosition.Y), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X, enemyPosition.Y + 200), new Vector2(enemyPosition.X, enemyPosition.Y), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X, enemyPosition.Y - 200), new Vector2(enemyPosition.X, enemyPosition.Y), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 200, enemyPosition.Y + 200), new Vector2(enemyPosition.X, enemyPosition.Y), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 200, enemyPosition.Y - 200), new Vector2(enemyPosition.X, enemyPosition.Y), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X - 200, enemyPosition.Y + 200), new Vector2(enemyPosition.X, enemyPosition.Y), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(enemyPosition.X + 200, enemyPosition.Y - 200), new Vector2(enemyPosition.X, enemyPosition.Y), _speed, _power, texture, 1));
            _shoot.Play(0.05f, 0.0f, 0.0f);
        }
        else if (_type == 3)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, _speed, _power, content.Load<Texture2D>("Sprites/bullet8"), 2));
            _shoot.Play(0.03f, -0.3f, 0.0f);
        }
        else if (_type == 4)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, _speed, _power, content.Load<Texture2D>("Sprites/bullet10"), 3));
            _shoot.Play(0.03f, 0.3f, 0.0f);
        }
        else if (_type == 5)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, _speed, _power, content.Load<Texture2D>("Sprites/bullet9"), 4));
            _shoot.Play(0.03f, 0.0f, 0.0f);
        }
        else if (_type == 6)
        {
            Texture2D texture = content.Load<Texture2D>("Sprites/bullet7");
            _projectiles.Add(new Projectile(new Vector2(1900, 1100), new Vector2(250, 1700), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 1000), new Vector2(200, 1600), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 900), new Vector2(150, 1500), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 800), new Vector2(100, 1400), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 700), new Vector2(50, 1300), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 600), new Vector2(0, 1200), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 500), new Vector2(-50, 1100), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 400), new Vector2(-100, 1000), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 300), new Vector2(-150, 900), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 200), new Vector2(-200, 800), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 100), new Vector2(-250, 700), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1900, 0), new Vector2(-300, 600), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1800, 0), new Vector2(-350, 500), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1700, 0), new Vector2(-400, 400), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1600, 0), new Vector2(-450, 300), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1500, 0), new Vector2(-500, 200), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1400, 0), new Vector2(-550, 100), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1300, 0), new Vector2(-600, 0), _speed, _power, texture, 1));
            _projectiles.Add(new Projectile(new Vector2(1200, 0), new Vector2(-650, -100), _speed, _power, texture, 1));
            _shoot.Play(0.1f, 0.0f, 0.0f);
        }
        else if (_type == 7)
        {
            Texture2D texture1 = content.Load<Texture2D>("Sprites/bullet2");
            Texture2D texture2 = content.Load<Texture2D>("Sprites/bullet3");
            Texture2D texture3 = content.Load<Texture2D>("Sprites/bullet4");
            Texture2D texture4 = content.Load<Texture2D>("Sprites/bullet6");

            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 400, _position.Y), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 350, _position.Y + 50), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 300, _position.Y + 100), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 250, _position.Y + 150), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 200, _position.Y + 200), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y + 250), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y + 300), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y + 350), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y + 400), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y + 350), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y + 300), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y + 250), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 200, _position.Y + 200), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 250, _position.Y + 150), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 300, _position.Y + 100), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 350, _position.Y + 50), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 400, _position.Y), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 350, _position.Y - 50), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 300, _position.Y - 100), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 250, _position.Y - 150), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 200, _position.Y - 200), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y - 250), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y - 300), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y - 350), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y - 400), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y - 350), _speed, _power, texture2, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y - 300), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y - 250), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 200, _position.Y - 200), _speed, _power, texture1, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 250, _position.Y - 150), _speed, _power, texture4, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 300, _position.Y - 100), _speed, _power, texture3, 1));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 350, _position.Y - 50), _speed, _power, texture2, 1));
            _shoot.Play(0.05f, 0.0f, 0.0f);
        }
        else if (_type == 8)
        {
            Texture2D texture1 = content.Load<Texture2D>("Sprites/bullet5");
            Texture2D texture2 = content.Load<Texture2D>("Sprites/bullet8");
            Texture2D texture3 = content.Load<Texture2D>("Sprites/bullet10");
            Texture2D texture4 = content.Load<Texture2D>("Sprites/bullet9");

            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 400, _position.Y), _speed, _power, texture1, 5));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 350, _position.Y + 50), _speed, _power, texture2, 2));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 300, _position.Y + 100), _speed, _power, texture3, 3));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 250, _position.Y + 150), _speed, _power, texture4, 4));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 200, _position.Y + 200), _speed, _power, texture1, 5));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y + 250), _speed, _power, texture4, 4));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y + 300), _speed, _power, texture3, 3));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y + 350), _speed, _power, texture2, 2));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y + 400), _speed, _power, texture1, 5));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y + 350), _speed, _power, texture2, 2));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y + 300), _speed, _power, texture3, 3));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y + 250), _speed, _power, texture4, 4));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 200, _position.Y + 200), _speed, _power, texture1, 5));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 250, _position.Y + 150), _speed, _power, texture4, 4));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 300, _position.Y + 100), _speed, _power, texture3, 3));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 350, _position.Y + 50), _speed, _power, texture2, 2));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 400, _position.Y), _speed, _power, texture1, 5));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 350, _position.Y - 50), _speed, _power, texture2, 2));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 300, _position.Y - 100), _speed, _power, texture3, 3));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 250, _position.Y - 150), _speed, _power, texture4, 4));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 200, _position.Y - 200), _speed, _power, texture1, 5));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 150, _position.Y - 250), _speed, _power, texture4, 4));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 100, _position.Y - 300), _speed, _power, texture3, 3));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X - 50, _position.Y - 350), _speed, _power, texture2, 2));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X, _position.Y - 400), _speed, _power, texture1, 5));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 50, _position.Y - 350), _speed, _power, texture2, 2));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 100, _position.Y - 300), _speed, _power, texture3, 3));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 150, _position.Y - 250), _speed, _power, texture4, 4));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 200, _position.Y - 200), _speed, _power, texture1, 5));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 250, _position.Y - 150), _speed, _power, texture4, 4));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 300, _position.Y - 100), _speed, _power, texture3, 3));
            _projectiles.Add(new Projectile(_position, new Vector2(_position.X + 350, _position.Y - 50), _speed, _power, texture2, 2));
            _shoot.Play(0.05f, 0.0f, 0.0f);
        }
        else if (_type == 9)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, _speed, _power, content.Load<Texture2D>("Sprites/bullet11"), 1));
            _shoot.Play(0.1f, 0.0f, 0.0f);
        }
        else if (_type == 10)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, _speed, _power, content.Load<Texture2D>("Sprites/bullet5"), 5));
            _shoot.Play(0.03f, 0.0f, 0.0f);
        }
    }

    public void Evolve(Tower evolution)
    {
        if(evolution.Price() <= _player.CurrentGold)
        {
            _player.CurrentGold -= evolution.Price();
            _rate = evolution.GetRate();
            _range = evolution.GetRange();
            _type = evolution.Type();
            _sprite = evolution.Sprite;
            _power = evolution.GetPower();
            _speed = evolution.GetSpeed();
            _price += evolution.Price();
            _comment = evolution.GetComment();
            _evolutions = evolution.Evolutions;
            _shoot = evolution.ShootSound;
        }
    }

    public void Sell()
    {
        _inGame = false;
        _player.CurrentGold += (_price / 4) * 3;
    }

    public bool InGame()
    {
        return _inGame;
    }

    public int Type()
    {
        return _type;
    }

    public int Price()
    {
        return _price;
    }

    public int GetRange()
    {
        return _range;
    }

    public int GetRate()
    {
        return _rate;
    }

    public int GetSpeed()
    {
        return _speed;
    }

    public int GetPower()
    {
        return _power;
    }

    public string GetComment()
    {
        return _comment;
    }

    public Vector2 GetPos()
    {
        return _position;
    }

    public SoundEffect ShootSound
    {
        get { return _shoot; }
    }

    public List<Tower> Evolutions
    {
        get { return _evolutions; }
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
