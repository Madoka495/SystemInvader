using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using VirusInvader;

namespace SystemInvader
{
    public class EnemiesData : Microsoft.Xna.Framework.Game
    {
        List<Texture2D> _enemyTextureEnemiesData;
        List<Enemy> _listEnemies = new List<Enemy>();

        public List<Texture2D> EnemyTexture
        {
            get { return _enemyTextureEnemiesData; }
        }

        public void AddTextureEnemies(ContentManager content)
        {
            List<Texture2D> _enemyTexture = new List<Texture2D>();
            Texture2D newtexture1 = content.Load<Texture2D>("Enemies/enemy1");
            _enemyTexture.Add(newtexture1);
            Texture2D newtexture2 = content.Load<Texture2D>("Enemies/enemy2");
            _enemyTexture.Add(newtexture2);
            Texture2D newtexture3 = content.Load<Texture2D>("Enemies/enemy3");
            _enemyTexture.Add(newtexture3);
            _enemyTextureEnemiesData = _enemyTexture;
        }     

        public void AddAllEnemy()
        {
            Enemy enemy1 = new Enemy(EnemyTexture[0], Vector2.Zero, 50, 10, 4f, 32, 32);
            Enemy.Add(enemy1);
            Enemy enemy2 = new Enemy(EnemyTexture[1], Vector2.Zero, 100, 15, 0.7f, 32, 32);
            Enemy.Add(enemy2);
            Enemy enemy3 = new Enemy(EnemyTexture[2], Vector2.Zero, 200, 20, 0.5f, 32, 32);
            Enemy.Add(enemy3);
        }

        public List<Enemy> Enemy
        {
            get { return _listEnemies; }
        }
    }
}
