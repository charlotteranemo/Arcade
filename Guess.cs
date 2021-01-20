using System;
using System.Collections.Generic;
using System.Text;

namespace Arcade
{
    class Guess
    {
        public int rightPlace { get; set; }
        public int wrongPlace { get; set; }

        public void DigitTest(int a, int one, int two, int three, int four)
        {
            if (a == one)
            {
                rightPlace++;
            }
            else if (a == two || a == three || a == four)
            {
                wrongPlace++;
            }
        }
    }
}
