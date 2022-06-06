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
        public bool WinOrLose { get; set; }

        //Random rndRoom = new Random();

        //constructor
        public GameLocation(Cave cave)
        {
            RandomizeAllLocations(cave);
        }

        // functions
        // randomizes player location 
        public void RandomizePlayerLocation()
        {
            int room;
            Random rndRoom = new Random();
            room = rndRoom.Next(31);
            PlayerLocation = room;
        }

        // randomizes wumpus location to 2-4 rooms away from its current location when it runs away
        public void RunAwayWumpusLocation(Cave cave)
        {
            Random rndRoom = new Random();
            int[] possibleRooms;
            int room;

            // this returns an array with 6 possible rooms
            possibleRooms = cave.GetAdjacentRooms(WumpusLocation);
            // this selects a random room out of the 6
            room = possibleRooms[rndRoom.Next(6)];

            WumpusLocation = room;
        }

        // resets wumpus location when the game is restarted
        public void RandomizeWumpusLocation()
        {
            Random rndRoom = new Random();
            int room;

            room = rndRoom.Next(30) + 1;
            WumpusLocation = room;
        }

        // randomizes the locations of both pit rooms 
        public void RandomizePitsLocation()
        {
            Random rndRoom = new Random();
            int room1, room2;

            room1 = rndRoom.Next(30) + 1;
            room2 = rndRoom.Next(30) + 1;
            Pit1Location = room1;
            Pit2Location = room2;
        }

        // randomizes the locations of both bat rooms 
        public void RandomizeBatsLocation()
        {
            Random rndRoom = new Random();
            int room1, room2;

            room1 = rndRoom.Next(30) + 1;
            room2 = rndRoom.Next(30) + 1;
            Bat1Location = room1;
            Bat2Location = room2;
        }

        // returns a room-specific warning (probably every time player moves to a new room)
        public string GiveWarning(Cave cave)
        {
            // different outcome based on which room player is near (can give multiple warnings if necessary)
            if (cave.GetAdjacentRooms(PlayerLocation).Contains(WumpusLocation))
            {
                // wumpus
                return "I smell a Wumpus!";
            }
            if (cave.GetAdjacentRooms(PlayerLocation).Contains(Bat1Location) || cave.GetAdjacentRooms(PlayerLocation).Contains(Bat2Location))
            {
                // pits
                return "Bats nearby!";
            }
            if (cave.GetAdjacentRooms(PlayerLocation).Contains(Pit1Location) || cave.GetAdjacentRooms(PlayerLocation).Contains(Pit2Location))
            {
                // bats
                return "I feel a draft!";
            }
            return "";
        }

        // shoots an arrow to a specific room
        public void ShootArrow(int arrowLocation, Cave cave)
        {
            // different outcome based on whether the arrow hits wumpus
            if (WumpusLocation == arrowLocation)
            {
                // win game
                WinOrLose = true;
                EndGame(WinOrLose, cave);
            }
            else
            {
                // wumpus runs away
                RunAwayWumpusLocation(cave);
            }
        }

        // returns a random piece of trivia depending on questions asked (array of answers?)
        public string GetHint()
        {
            return "";
        }

        // ends game if player wins or loses (true = win, false = lose)
        public void EndGame(bool wL, Cave cave)
        {
            // based on whether the player has won or lost, sends something different to ui; also resets game -> randomizes all locations
            if (wL == true)
            {
                // win
                RandomizeAllLocations(cave);
            }
            else if (wL == false)
            {
                // lose
                RandomizeAllLocations(cave);
            }
        }

        // resets locations, regardless of whether or not a player has won
        public void RandomizeAllLocations(Cave cave)
        {
            RandomizePlayerLocation();
            RandomizeWumpusLocation();
            RandomizeBatsLocation();
            RandomizePitsLocation();
        }
    }
}
