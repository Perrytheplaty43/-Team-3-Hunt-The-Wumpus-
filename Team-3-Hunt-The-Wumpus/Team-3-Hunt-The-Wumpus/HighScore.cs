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
        public string Cave { get; set; }
        public int Score { get; set; }

        public HighScore(string n, string c, int s)
        {
            Name = n;
            Cave = c;
            Score = s;
        }
    }
}
