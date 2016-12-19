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
            for (int i = 1; i <= 8; i++)
            {
                string nameImage = "Monster" + i.ToString();
                Texture2D newTexture = content.Load<Texture2D>(_folderPath + nameImage);
                _enemyTexture.Add(newTexture);
            }
        }

        public void AddAllEnemy()
        {
            _listEnemies.Add(new Enemy(EnemyTexture[0], Vector2.Zero, 50, 10, 10, 1f, 48, 48, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[1], Vector2.Zero, 50, 15, 10, 1f, 48, 48, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[2], Vector2.Zero, 50, 20, 10, 1f, 48, 48, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[3], Vector2.Zero, 50, 20, 10, 1f, 48, 48, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[4], Vector2.Zero, 50, 20, 10, 1f, 48, 48, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[5], Vector2.Zero, 50, 20, 10, 1f, 48, 48, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[6], Vector2.Zero, 50, 20, 10, 1f, 48, 48, _player));
            _listEnemies.Add(new Enemy(EnemyTexture[7], Vector2.Zero, 50, 20, 10, 1f, 48, 48, _player));
        }

        public List<Enemy> Enemy
        {
            get { return _listEnemies; }
        }
    }
}
