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
    List<Projectile> _projectiles;

    public Tower(Vector2 position, int rate, int range, int type)
    {
        _position = position;
        _rate = rate;
        _range = range;
        _type = type;
        _projectiles = new List<Projectile>();
    }

    public void Shoot(Vector2 enemyPosition)
    {
        if (_type == 1)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, 8, 20));
        }
        else if (_type == 2)
        {
            _projectiles.Add(new Projectile(_position, enemyPosition, 15, 5));
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
    public List<Projectile> GetProjectiles()
    {
        return _projectiles;
    }
}
