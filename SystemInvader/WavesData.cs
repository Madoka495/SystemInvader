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
    public class WavesData
    {
        List<Wave> _WaveLv1;
        List<Wave> _WaveLv2;
        List<Wave> _WaveLv3;
        EnemiesData _enemiesData;
        Level _level;

        public void AddInfor(EnemiesData enemiesData, Level level)
        {
            _enemiesData = enemiesData;
            _level = level;
        }

        private void AddInList(List<Wave> wave, int numberEnemies, Enemy enemy, Level level)
        {
            Wave newWave = new Wave(numberEnemies, enemy, level);
            wave.Add(newWave);
        }

        public void SetUpWavesData()
        {
            AddWaveLv1();
            AddWaveLv2();
            AddWaveLv3();
        }

        public void AddWaveLv1()
        {
            List<Wave> WaveLv1 = new List<Wave>();
            for (int i = 0; i < 2; i++)
            {
                AddInList(WaveLv1, 5, _enemiesData.Enemy[i], _level);
            }
            _WaveLv1 = WaveLv1;
        }

        public void AddWaveLv2()
        {
            List<Wave> WaveLv2 = new List<Wave>();
            for (int i = 1; i <= 2; i++)
            {
                AddInList(WaveLv2, 8, _enemiesData.Enemy[i], _level);
            }
            _WaveLv2 = WaveLv2;
        }

        public void AddWaveLv3()
        {
            List<Wave> WaveLv3 = new List<Wave>();
            for (int i = 0; i < 3; i++)
            {
                AddInList(WaveLv3, 10, _enemiesData.Enemy[i], _level);
            }
            _WaveLv3 = WaveLv3;
        }

        public List<Wave> WaveLv1
        {
            get { return _WaveLv1; }
        }
        public List<Wave> WaveLv2
        {
            get { return _WaveLv2; }
        }
        public List<Wave> WaveLv3
        {
            get { return _WaveLv3; }
        }
    }
}
