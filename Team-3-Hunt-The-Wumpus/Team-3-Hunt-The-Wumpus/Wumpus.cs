using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    class Wumpus
    {
        // instance variables
        public int MyProperty { get; set; }
        GameLocation gameLocation = new GameLocation();

        // constructer
        public Wumpus()
        {

        }

        // functions
        // wakes wumpus
        public void WakeWumpus()
        {
            gameLocation.RunAwayWumpusLocation();
        }
    }
}
