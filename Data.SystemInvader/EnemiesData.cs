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
    public class EnemiesData
    {
        List<Enemy> _listEnemies = new List<Enemy>();
        List<Texture2D> _enemyTexture = new List<Texture2D>();
        List<Texture2D> _lifeBar = new List<Texture2D>();
        Player _player;

        public EnemiesData(Player player)
        {
            _player = player;
        }

        public List<Texture2D> EnemyTexture
        {
            get { return _enemyTexture; }
        }

        public void AddTextureEnemies(ContentManager content)
        {
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy1"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy2"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy3"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy4"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy5"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy1-2"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy2-2"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy3-2"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy6"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy7"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy1-3"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy2-3"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy3-3"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy8"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy9"));
            _enemyTexture.Add(content.Load<Texture2D>("Sprites/enemy10"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/green"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/yellow"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/red"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/black"));
        }

        public void AddAllEnemy() // texture, position, health, bountyGiven, strength, speed, player
        {
            _listEnemies.Add(new Enemy(EnemyTexture[0], Vector2.Zero, 200, 10, 3, 4f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[1], Vector2.Zero, 1000, 15, 5, 0.7f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[2], Vector2.Zero, 2500, 50, 10, 0.5f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[3], Vector2.Zero, 10000, 1000, 80, 0.7f, 2, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[4], Vector2.Zero, 4000, 75, 25, 1f, 3, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[5], Vector2.Zero, 1000, 20, 10, 4.5f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[6], Vector2.Zero, 4500, 80, 20, 1f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[7], Vector2.Zero, 15000, 100, 30, 0.8f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[8], Vector2.Zero, 100000, 2500, 180, 0.5f, 2, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[9], Vector2.Zero, 50000, 150, 60, 1.2f, 3, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[10], Vector2.Zero, 5000, 30, 25, 5.5f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[13], Vector2.Zero, 300000, 5000, 300, 2f, 3, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[11], Vector2.Zero, 25000, 120, 45, 1.2f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[12], Vector2.Zero, 100000, 150, 60, 1f, 1, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[14], Vector2.Zero, 50000, 100, 50, 2f, 2, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[15], Vector2.Zero, 1000000, 10000, 1000, 4f, 3, _player, _lifeBar));
        }

        public List<Enemy> Enemy
        {
            get { return _listEnemies; }
        }
    }
}
