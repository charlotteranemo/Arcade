using System;
using System.Collections.Generic;
using System.Text;

namespace Arcade
{
    class Mastermind
    {
        private readonly Random random = new Random();
        public int RandomNumber()
        {
            return random.Next(0, 9);
        }
    }
}
