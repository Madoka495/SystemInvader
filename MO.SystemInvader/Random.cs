using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemInvader
{
    public class RandomNum
    {
        private Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomNum"/> class.
        /// </summary>
        internal RandomNum()
        {
            _random = new Random();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomNum"/> class.
        /// </summary>
        /// <param name="randomSeed">The random seed.</param>
        internal RandomNum(int randomSeed)
        {
            _random = new Random(randomSeed);
        }

        /// <summary>
        /// Gets a random number between min and max value.
        /// min value is inclusive, max value is exclusive.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum plus one.</param>
        /// <returns></returns>
        internal int GetRandom(int min, int max) => _random.Next(min, max);

        /// <summary>
        /// Use the percent given and roll a random number between 1 and 100,
        /// if the number is bigger than the percent it return false.
        /// </summary>
        /// <param name="percentChance">The percent chance.</param>
        /// <returns></returns>
        internal bool RollChancePercent(int percentChance) => (GetRandom(1, 101) <= percentChance);
    }
}

