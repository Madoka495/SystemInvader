using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MO.SystemInvader;

namespace SystemInvader
{
    public class WaveManager
    {
        int _numberWave;
        int _numberCurrentWave = 0;
        bool _spawnMore = true;
        int i = 0;

        List<Wave> _listWaves = new List<Wave>();
        List<Wave> _wave;

        public WaveManager(List<Wave> Wave)
        {
            _wave = Wave;
            _numberWave = Wave.Count;
        }

        public void AddWaves(Wave waveToBeAdd)
        {
            _listWaves.Add(waveToBeAdd);
        }

        public List<Wave> Waves
        {
            get { return _listWaves; }
        }

        //Update/////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update(GameTime gameTime)
        {
            if (_numberCurrentWave == _numberWave)
                _spawnMore = false;
            if (_spawnMore == true)
            {
                if (_listWaves.Count == 0)
                {
                    _wave[i].SpawMoreOrNot(true);
                }
                int j;
                if (i == 0)
                    j = i;
                else
                    j = i - 1;

                if (_wave[j].SpawnNewWave == true)
                {
                    Wave _waveToBeAdd;
                    if (i == 0)
                        _wave[i].SpawMoreOrNot(false);
                    _waveToBeAdd = _wave[i];
                    AddWaves(_waveToBeAdd);
                    i++;
                    _numberCurrentWave++;
                }
            }
            for (int i = 0; i < Waves.Count; i++)
            {
                Wave wave = Waves[i];
                wave.Update(gameTime);
            }
        }


        //Draw/////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Wave wave in Waves)
            {
                wave.Draw(spriteBatch);
            }

        }



    }
}
