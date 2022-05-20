using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    class Player
    {
        public bool WumpusAlive { get; set; }
        public int Arrows { get; set; }
        public int Coins { get; set; }
        public int Turns { get; set; }

        public Player(int a, int c, int t, bool wa)
        {
            Arrows = a;
            Coins = c;
            Turns = t;
            WumpusAlive = wa;
        }
        
        public void IncreaseArrows()
        {
            Arrows++;
        }
        public void DecreaseArrows()
        {
            Arrows--;
        }
        public void IncreaseCoins()
        {
            Coins++;
        }
        public void DecreaseCoins()
        {
            Coins--;
        }
        public void IncreaseTurns()
        {
            Turns++;
        }
        public int GetEndScore()
        {            
            int wumpus = 0;
            if (WumpusAlive == true) wumpus = 0;
            else  wumpus = 50;
            int endScore = 100 - Turns + Coins + (5 * Arrows) + wumpus;
            return endScore;
        }
    }
}
