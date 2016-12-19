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
    private int _rate;
    private int _range;
    private int _type;
    private int _towerWidth;
    private int _towerHeight;
    private int _price;
    private int _upgrade;
    private int _damage;

    private Texture2D _textureTower;
    private Texture2D _textureBullet;

    List<Projectile> _projectiles;
    List<Tower> _listContient;
    Vector2 _position;
    Vector2 _posBase;


    public Tower(Texture2D textureBullet , Texture2D textureTowers , Vector2 position, int rate, int range, int type, int price, int towerWidth, int towerHeight, int upgrade, List<Tower> listContient, int damage)
    {
        _projectiles = new List<Projectile>();
        _position = position;
        _rate = rate;
        _range = range;
        _type = type;
        _price = price;
        _upgrade = upgrade;
        _listContient = listContient;
        _damage = damage;

        _towerWidth = towerWidth;
        _towerHeight = towerHeight;
        _textureTower = textureTowers;
        _textureBullet = textureBullet;

        _posBase = new Vector2(_position.X, _position.Y + _towerHeight);
        
    }

    public void Shoot(Vector2 enemyPosition)
    {
        if (_type == 1)
        {
            _projectiles.Add(new Projectile(_textureBullet, _position, enemyPosition, 8, 20, 50, 50));
        }
        else if (_type == 2)
        {
            _projectiles.Add(new Projectile(_textureBullet, _position, enemyPosition, 15, 5, 50, 50));
        }
    }

    public bool Inrange(Vector2 enemy)
    {
        if (enemy.X >= _position.X - GiveRange &&
           enemy.X <= _position.X + GiveRange &&
           enemy.Y >= _position.Y - GiveRange &&
           enemy.Y <= _position.Y + GiveRange)
            return true;
        return false;
    }

    public int GiveRange
    {
        get { return _range; }
        set { _range = value; }
    }
    public int GiveRate
    {
        get { return _rate; }
        set { _rate = value; }
    }
    public int GivePrice
    {
        get { return _price; }
        set { _price = value; }
    }
    public int GiveWidth
    {
        get { return _towerWidth; }
        set { _towerWidth = value; }
    }
    public int GiveHeight
    {
        get { return _towerHeight; }
        set { _towerHeight = value; }
    }
    public int GiveUpgrade
    {
        get { return _upgrade; }
        set { _upgrade = value; }
    }

    public int Givetype
    {
        get { return _type; }
        set { _type = value; }
    }

    public int GiveDamage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public List<Tower> GiveListContient => _listContient;

    public Texture2D GiveTextureTower
    {
        get { return _textureTower; }
        set { _textureTower = value; }
    }
    public Texture2D GiveTextureBullet
    {
        get { return _textureBullet; }
        set { _textureBullet = value; }
    }
    public Vector2 GetPos
    {
        get { return _position; }
        set { _position = value; }
    }
    public void ChangePosition(Vector2 newPosition)
    {
        _position = newPosition;
    }
    
    public List<Projectile> GetProjectiles() => _projectiles;

    public Vector2 GivePosBase => _posBase;

    //Draw///////////////////////////////////////////////////////////////////////////////////////
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_textureTower, new Rectangle((int)GetPos.X, (int)GetPos.Y, _towerWidth, _towerHeight), Color.White);
    }
}
