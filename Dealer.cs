using System;
using System.Collections.Generic;
using System.Text;

namespace Arcade
{
    class Dealer
    {
        private readonly Random random = new Random();
        public int Deal()
        {
            return random.Next(1, 13);
        }
        public string CardDealt(int card)
        {
            if (card == 11)
            {
                return "Jack";
            }
            else if (card == 12)
            {
                return "Queen";
            }
            else if (card == 13)
            {
                return "King";
            }
            else if (card == 1)
            {
                return "Ace";
            }
            else
            {
                return card.ToString();
            }
        }
    }
}
