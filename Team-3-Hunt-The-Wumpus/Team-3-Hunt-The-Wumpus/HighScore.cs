using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team_3_Hunt_The_Wumpus
{
    public class HighScore
    {
        public string Name { get; set; }
        public int Cave { get; set; }
        public int Score { get; set; }
        public int NumOfTurns { get; set; }
        public int NumOfArrowsLeft { get; set; }
        public bool DefeatedWumpus { get; set; }
        public int Coins { get; set; }

        public HighScore(string n, int c, int s, int no, int al, bool dw, int coins)
        {
            Name = n;
            Cave = c;
            Score = s;
            NumOfTurns = no;
            NumOfArrowsLeft = al;
            DefeatedWumpus = dw;
            Coins = coins;
        }
    }
}
