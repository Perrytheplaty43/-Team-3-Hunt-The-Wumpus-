using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    public class GameLocation
    {
        // instance variables
        // whenever the player moves forward, PlayerLocation should be updated
        public int PlayerLocation { get; set; }
        public int WumpusLocation { get; set; }
        public int Pit1Location { get; set; }
        public int Pit2Location { get; set; }
        public int Bat1Location { get; set; }
        public int Bat2Location { get; set; }

        Random rndRoom = new Random();

        // constructor
        public GameLocation(int pL, int wL, int piL1, int pil2, int bL1, int bl2)
        {
            pL = PlayerLocation;
            wL = WumpusLocation;
            piL1 = Pit1Location;
            pil2 = Pit2Location;
            bL1 = Bat1Location;
            bl2 = Bat2Location;
        }

        // functions
        // randomizes player location 
        public void RandomizePlayerLocation()
        {
            int room;

            room = rndRoom.Next(30);
            PlayerLocation = room;
        }

        // randomizes wumpus location to 2-4 rooms away from its current location
        public void RandomizeWumpusLocation()
        {
            int room;

            room = rndRoom.Next(4);
            WumpusLocation = WumpusLocation + room;
        }

        // randomizes the locations of both pit rooms 
        public void RandomizePitsLocation()
        {
            int room1, room2;
            
            room1 = rndRoom.Next(30);
            room2 = rndRoom.Next(30);
            Pit1Location = room1;
            Pit2Location = room2;
        }

        // randomizes the locations of both bat rooms 
        public void RandomizeBatsLocation()
        {
            int room1, room2;

            room1 = rndRoom.Next(30);
            room2 = rndRoom.Next(30);
            Bat1Location = room1;
            Bat2Location = room2;
        }

        // returns a room-specific warning
        public string GiveWarning()
        {
            // different outcome based on which room player is near
            
            //commented un finished code to surpress build errors
            //feel free to uncomment to continue working
            /*if ()
            {
                // wumpus
                return "I smell a Wumpus!";
            }
            else if ()
            {
                // pits
                return "Bats nearby!";
            }
            else if ()
            {
                // bats
                return "I feel a draft!";
            }
            */
            return "";
        }

        // shoots an arrow to a specific room
        public void ShootArrow(int arrowLocation)
        {
            // different outcome based on whether the arrow hits wumpus
            if (WumpusLocation == arrowLocation)
            {
                // end game
            }
            else
            {
                // wumpus changes room
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
