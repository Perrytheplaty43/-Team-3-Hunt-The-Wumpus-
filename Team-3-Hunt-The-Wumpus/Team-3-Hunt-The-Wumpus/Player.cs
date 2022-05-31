using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    public class Player
    {
        public bool WumpusAlive = true;
        public int Arrows = 0;
        public int Coins = 0;
        public int Turns = 0;

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
            int wumpus;
            if (WumpusAlive == true) wumpus = 0;
            else  wumpus = 50;
            int endScore = 100 - Turns + Coins + (5 * Arrows) + wumpus;
            return endScore;
        }
    }
}
