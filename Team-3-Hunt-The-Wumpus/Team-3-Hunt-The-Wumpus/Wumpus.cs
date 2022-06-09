using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    public class Wumpus
    {
        // instance variables
        public int MyProperty { get; set; }
        GameLocation gameLocation;
        public bool IsDead { get; set; }

        // constructer
        public Wumpus()
        {
            gameLocation = new GameLocation();
        }

        // functions
        // wakes wumpus
        public void WakeWumpus(Cave cave)
        {
            gameLocation.RunAwayWumpusLocation(cave);
        }
    }
}
