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
            _lifeBar.Add(content.Load<Texture2D>("Sprites/green"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/yellow"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/red"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/black"));
        }

        public void AddAllEnemy() // texture, position, health, bountyGiven, strength, speed, player
        {
            _listEnemies.Add(new Enemy(EnemyTexture[0], Vector2.Zero, 200, 10, 2, 4f, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[1], Vector2.Zero, 1000, 15, 3, 0.7f, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[2], Vector2.Zero, 1500, 20, 5, 0.5f, _player, _lifeBar));
        }

        public List<Enemy> Enemy
        {
            get { return _listEnemies; }
        }
    }
}
