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

        string _folderPath = "Sprites/Enemies/";
        public void AddTextureEnemies(ContentManager content)
        {
            for (int i = 1; i <= 23; i++)
            {
                string nameImage = "Monster" + i.ToString();
                Texture2D newTexture = content.Load<Texture2D>(_folderPath + nameImage);
                _enemyTexture.Add(newTexture);
            }

            _lifeBar.Add(content.Load<Texture2D>("Sprites/green"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/yellow"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/red"));
            _lifeBar.Add(content.Load<Texture2D>("Sprites/black"));
        }

        public void AddAllEnemy() // texture, position, health, bountyGiven, strength, speed, type, enemyWidth, enemyHeight, player, lifeBar
        {
            _listEnemies.Add(new Enemy(EnemyTexture[0], Vector2.Zero, 50, 10, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[1], Vector2.Zero, 50, 15, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[2], Vector2.Zero, 50, 20, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[3], Vector2.Zero, 50, 20, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[4], Vector2.Zero, 50, 20, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[5], Vector2.Zero, 50, 20, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[6], Vector2.Zero, 50, 20, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[7], Vector2.Zero, 50, 20, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[8], Vector2.Zero, 50, 20, 10, 0.5f, 1, 32, 32, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[9], Vector2.Zero, 50, 20, 10, 0.5f, 1, 32, 32, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[10], Vector2.Zero, 50, 20, 10, 0.5f, 1, 32, 32, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[11], Vector2.Zero, 50, 20, 10, 0.5f, 1, 32, 32, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[12], Vector2.Zero, 50, 20, 10, 1f, 1, 48, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[13], Vector2.Zero, 50, 20, 10, 0.5f, 1, 64, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[14], Vector2.Zero, 50, 20, 10, 0.5f, 1, 40, 56, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[15], Vector2.Zero, 50, 20, 10, 1f, 1, 96, 48, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[16], Vector2.Zero, 50, 20, 10, 1f, 1, 64, 80, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[17], Vector2.Zero, 50, 20, 10, 1f, 1, 40, 56, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[18], Vector2.Zero, 50, 20, 10, 1f, 1, 80, 96, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[19], Vector2.Zero, 50, 20, 10, 1f, 1, 64, 64, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[20], Vector2.Zero, 50, 20, 10, 1f, 1, 96, 96, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[21], Vector2.Zero, 50, 20, 10, 1f, 1, 48, 64, _player, _lifeBar));
            _listEnemies.Add(new Enemy(EnemyTexture[22], Vector2.Zero, 50, 20, 10, 0.5f, 1, 76, 80, _player, _lifeBar));

            /*_listEnemies.Add(new Enemy(EnemyTexture[0], Vector2.Zero, 200, 10, 3, 4f, 1, _player, _lifeBar));
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
            _listEnemies.Add(new Enemy(EnemyTexture[15], Vector2.Zero, 1000000, 10000, 1000, 4f, 3, _player, _lifeBar));*/
        }

        public List<Enemy> Enemy
        {
            get { return _listEnemies; }
        }
    }
}
