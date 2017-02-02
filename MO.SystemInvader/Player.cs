using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO.SystemInvader
{
    public class Player
    {
        int _life = 100;
        int _currentGold = 500;
        int _startLife = 100;
        int _startGold = 500;
        int _score = 0;
        int _difficulty = 2;
        int _map = 0;

        public void Rewind()
        {
            _life = _startLife;
            _currentGold = _startGold;
            _score = 0;
        }

        public int Income()
        {
            int _income = _currentGold / 10;
            _currentGold += _income;
            _score += (_income / 2) * _difficulty;
            return _income;
        }

        public void ChangeDifficulty(int difficulty)
        {
            if (difficulty == 1)
            {
                _startLife = 200;
                _startGold = 700;
            }
            else if (difficulty == 2)
            {
                _startLife = 100;
                _startGold = 500;
            }
            else if (difficulty == 3)
            {
                _startLife = 50;
                _startGold = 300;
            }
            else if (difficulty == 4)
            {
                _startLife = 1;
                _startGold = 100;
            }
            Rewind();
            _difficulty = difficulty;
        }

        public int Difficulty
        {
            get { return _difficulty; }
        }

        public int Map
        {
            get { return _map; }
            set { _map = value; }
        }

        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public int CurrentGold
        {
            get { return _currentGold; }
            set { _currentGold = value; }
        }
    }
}