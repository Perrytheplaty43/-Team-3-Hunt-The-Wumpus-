using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    class Player
    {
        public int Arrows { get; set; }
        public int Coins { get; set; }
        public int Turns { get; set; }

        public Player(int a, int c, int t)
        {
            Arrows = a;
        }
    }
}
