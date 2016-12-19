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
        int nbWaves = 0;
        
        bool _sendNextWave = false;
        bool _won = false;

        List<Wave> _listWaves = new List<Wave>();
        List<Wave> _wave;

        public WaveManager(List<Wave> Wave)
        {
            _wave = Wave;
        }

        public void AddWaves(Wave waveToBeAdd)
        {
            _listWaves.Add(waveToBeAdd);
        }

        public void NextWave()
        {
            Wave _waveToBeAdd;
            if(nbWaves <= _wave.Count - 1)
            {
                _wave[nbWaves].SpawMoreOrNot(false);
                _waveToBeAdd = _wave[nbWaves];
                AddWaves(_waveToBeAdd);
                nbWaves++;
            }
            else
            {
                _won = true;
            }
        }

        public int NbWave
        {
            get { return nbWaves; }
        }

        public bool SendNextWave
        {
            get { return _sendNextWave; }
        }
        public bool Won
        {
            get { return _won; }
            set { _won =
                    value; }
        }

        public List<Wave> Waves
        {
            get { return _listWaves; }
        }

        //Update/////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update(GameTime gameTime)
        {
            if (_listWaves.Count == 0)
            {
                _wave[nbWaves].SpawMoreOrNot(true);
            }
            int j;
            if (nbWaves == 0)
                j = nbWaves;
            else
                j = nbWaves - 1;

            if (_wave[j].SpawnNewWave == true)
            {
                _sendNextWave = true;
            }
            else
            {
                _sendNextWave = false;
            }
            foreach (Wave wave in Waves)
            {
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
