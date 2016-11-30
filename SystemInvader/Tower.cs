using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemInvader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VirusInvader;

public class Tower
{
    //Parametres///////////////////////////////////////////////////////////////////////////////////////

    int _rate;
    int _range;
    int _type;
    int _towerHeight;
    int _towerWidth;

    Vector2 _position = new Vector2();
    List<Projectile> _projectiles;
    Texture2D _texture;
    List<Enemy> _listEnemies = new List<Enemy>();

    //Functions///////////////////////////////////////////////////////////////////////////////////////

    public Vector2 GetPos() => _position;
    public List<Projectile> GetProjectiles() => _projectiles;

    public int GetRange() => _range;
    public int GetRate() => _rate;
    public bool DectectedEnemy(Enemy enemy) => Inrange(enemy.GetPos());

    public Tower(Texture2D texture ,Vector2 position, int rate, int range, int type, int towerWidth, int towerHeight)
	{

        _position = position;
        _rate = rate;
        _range = range;
        _type = type;
        _texture = texture;
        _towerHeight = towerHeight;
        _towerWidth = towerWidth;

        _projectiles = new List<Projectile>();
    }

    public void Shoot(Vector2 enemyPosition)
    {
        if (_type == 1)
        {
            _projectiles.Add(new Projectile(_texture ,_position, enemyPosition, 6, 20, 50, 50));
        }
        else if (_type == 2)
        {
            _projectiles.Add(new Projectile(_texture, _position, enemyPosition, 15, 5, 50, 50));
        }
    }

    public bool Inrange(Vector2 enemy)
    {
        if (enemy.X >= _position.X - GetRange() &&
           enemy.X <= _position.X + GetRange() &&
           enemy.Y >= _position.Y - GetRange() &&
           enemy.Y <= _position.Y + GetRange())
            return true;
        return false;
    }
    

    //Update///////////////////////////////////////////////////////////////////////////////////////
    public void Update()
    {
        
    }



    //Draw///////////////////////////////////////////////////////////////////////////////////////
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, new Rectangle((int)GetPos().X, (int)GetPos().Y, _towerWidth, _towerHeight), Color.White);
    }


}
