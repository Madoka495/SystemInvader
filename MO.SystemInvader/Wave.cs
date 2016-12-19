using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MO.SystemInvader
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
        Player _player;

        //Fonctions/////////////////////////////////////////////////////////////////////////
        public bool SpawnNewWave => _spawnNewWave;

        public Wave(int numberEnemies, Enemy enemy, Level level, Player player)
        {
            _numberEnemies = numberEnemies;
            _enemy = enemy;
            _currentLevel = level;
            _player = player;
        }

        public void AddEnemies()
        {
            Enemy newEnemy = new Enemy(_enemy.GiveTexture, Vector2.Zero, _enemy.GiveHealth, _enemy.BountyGiven, _enemy.GiveStrength, _enemy.GiveSpeed, _enemy.GiveWidth, _enemy.GiveHeight, _player);
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

            if(Enemies.Count > 0)
            {
                _spawnNewWave = true;
                foreach (Enemy enemy in Enemies)
                {
                    enemy.Update(gameTime);

                    if (enemy.InGame == true)
                    {
                        if (enemy.GetPos() == _currentLevel.AtTheEnd)
                        {
                            enemy.AtTheEnd();
                        }
                        _spawnNewWave = false;
                    }
                }
            }
        }


        //Draw/////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}