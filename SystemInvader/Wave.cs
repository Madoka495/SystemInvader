using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VirusInvader;

namespace SystemInvader
{
    public class Wave
    {
        //Paramtres/////////////////////////////////////////////////////////////////////////
        int _numberEnemies;
        int _numberCurrentEnemies = 0;
        float _timeSpawnEnemies = 0;
        bool _spawnMore = true;
        bool _spawnNewWave = false;

        Enemy _enemy;
        List<Enemy> _enemies = new List<Enemy>();
        Level _currentLevel;

        //Fonctions/////////////////////////////////////////////////////////////////////////
        public bool SpawnNewWave => _spawnNewWave;

        public Wave(int numberEnemies, Enemy enemy, Level level)
        {
            _numberEnemies = numberEnemies;
            _enemy = enemy;
            _currentLevel = level;
        }

        public void AddEnemies()
        {
            Enemy newEnemy = new Enemy(_enemy.GiveTexture, Vector2.Zero, _enemy.GiveHealth, _enemy.GiveBounty, _enemy.GiveSpeed, _enemy.GiveWidth, _enemy.GiveHeight);
            newEnemy.SetWaypoints(_currentLevel.Waypoints);
            _enemies.Add(newEnemy);

            _numberCurrentEnemies++;
            _timeSpawnEnemies = 0;
        }

        public List<Enemy> Enemies
        {
            get { return _enemies; }
        }
        public void SpawMoreOrNot(bool choice)
        {
            _spawnNewWave = choice;
        }
        //Update/////////////////////////////////////////////////////////////////////////
        public void Update(GameTime gameTime)
        {
            if (_numberCurrentEnemies == _numberEnemies)
                _spawnMore = false;

            if (_spawnMore)
            {
                _timeSpawnEnemies += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_timeSpawnEnemies > 1)
                {
                    AddEnemies();
                }
            }
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemy enemy = Enemies[i];
                enemy.Update();

                if (enemy.IsDead == false && enemy.GiveCurrentHealth > 0)
                {
                    if (enemy.GetPos() == _currentLevel.AtTheEnd)
                    {
                        if (i == Enemies.Count - 1)
                            _spawnNewWave = true;
                        enemy.AtTheEnd();
                    }
                }

                if (enemy.IsDead)
                {
                    Enemies.Remove(enemy);
                    i--;
                }
                    
            }
        }


        //Draw/////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

    }
}
