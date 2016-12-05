using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO.SystemInvader
{
    public class Player
    {
        int _life = 30;
        int _currentGold = 550;
        int _score = 0;

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