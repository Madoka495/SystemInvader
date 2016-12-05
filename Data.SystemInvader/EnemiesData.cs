using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MO.SystemInvader;

namespace Data.SystemInvader
{
    public class EnemiesData : Microsoft.Xna.Framework.Game
    {
        List<Texture2D> _enemyTextureEnemiesData;
        List<Enemy> _listEnemies = new List<Enemy>();
        List<Texture2D> _enemyTexture = new List<Texture2D>();
        Player _player;

        public List<Texture2D> EnemyTexture
        {
            get { return _enemyTextureEnemiesData; }
        }

        public void AddTextureEnemies(ContentManager content, Player player)
        {
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy1"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy2"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy3"));
            _enemyTextureEnemiesData = _enemyTexture;
            _player = player;
        }     

        public void AddAllEnemy()
        {
            _listEnemies.Add(new Enemy(EnemyTexture[0], Vector2.Zero, 200, 10, 4f, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[1], Vector2.Zero, 1000, 15, 0.7f, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[2], Vector2.Zero, 1500, 20, 0.5f, _player));
        }

        public List<Enemy> Enemy
        {
            get { return _listEnemies; }
        }
    }
}
