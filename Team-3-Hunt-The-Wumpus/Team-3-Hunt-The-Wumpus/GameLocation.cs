using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    class GameLocation
    {
        // instance variables
        public int PlayerLocation { get; set; }
        public int WumpusLocation { get; set; }
        public int PitsLocation { get; set; }
        public int BatsLocation { get; set; }

        // constructor
        public GameLocation(int pL, int wL, int piL, int bL)
        {
            pL = PlayerLocation;
            wL = WumpusLocation;
            piL = PitsLocation;
            bL = BatsLocation;
        }

        // functions
        // randomizes player location and updates
        public void RandomizePlayerLocation()
        {
            PlayerLocation = 0;
        }

        // randomizes wumpus location to 2-4 rooms away and updates
        public void RandomizeWumpusLocation()
        {
            WumpusLocation = 0;
        }

        // randomizes the locations of both pit rooms and updates
        public void RandomizePitsLocation()
        {
            PitsLocation = 0;
        }

        // randomizes the locations of both bat rooms and updates
        public void RandomizeBatsLocation()
        {
            BatsLocation = 0;
        }

        // returns a room-specific warning
        public string GiveWarning()
        {
            // different outcome based on which room player is near

            return "";
        }

        // shoots an arrow to a specific room
        public void ShootArrow(int arrowLocation)
        {
            // different outcome based on whether the arrow hits wumpus
            if (WumpusLocation == arrowLocation)
            {

            }
            else
            {
                RandomizeWumpusLocation();
            }
        }

        // returns a random piece of trivia
        public string GetHint()
        {
            return "";
        }
    }
}
