using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MO.SystemInvader;

namespace Data.SystemInvader
{
    public class WavesData
    {
        List<Wave> _wave;
        EnemiesData _enemiesData;
        Level _level;
        Player _player;

        public void AddInfor(EnemiesData enemiesData, Level level, Player player)
        {
            _enemiesData = enemiesData;
            _level = level;
            _player = player;
        }

        void AddInList(List<Wave> wave, int numberEnemies, Enemy enemy, Level level)
        {
            Wave newWave = new Wave(numberEnemies, enemy, level, _player);
            wave.Add(newWave);
        }

        public void SetUpWavesData()
        {
            AddWave();
        }

        public void AddWave()
        {
            List<Wave> Wave = new List<Wave>();
            AddInList(Wave, 5, _enemiesData.Enemy[0], _level);
            AddInList(Wave, 8, _enemiesData.Enemy[0], _level);
            AddInList(Wave, 5, _enemiesData.Enemy[1], _level);
            AddInList(Wave, 3, _enemiesData.Enemy[2], _level);
            AddInList(Wave, 1, _enemiesData.Enemy[3], _level);
            AddInList(Wave, 6, _enemiesData.Enemy[2], _level);
            AddInList(Wave, 4, _enemiesData.Enemy[4], _level);
            AddInList(Wave, 24, _enemiesData.Enemy[0], _level);
            _wave = Wave;
        }

        public List<Wave> Wave
        {
            get { return _wave; }
        }
    }
}
