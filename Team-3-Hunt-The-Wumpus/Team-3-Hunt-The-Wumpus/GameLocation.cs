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

        Cave cave = new Cave();
        Random rndRoom = new Random();

        //constructor

        public GameLocation() 
        {
            RandomizeAllLocations();
        }

        // functions
        // randomizes player location 
        public void RandomizePlayerLocation()
        {
            int room;

            room = rndRoom.Next(30);
            PlayerLocation = room;
        }

        // randomizes wumpus location to 2-4 rooms away from its current location when it runs away
        public void RunAwayWumpusLocation()
        {
            int[] possibleRooms;
            int room;

            // finds all adjacent rooms that the wumpus could go to
            possibleRooms = cave.GetAdjacentRooms(WumpusLocation);
            
        }

        // resets wumpus location when the game is restarted
        public void RandomizeWumpusLocation()
        {
            int room;

            room = rndRoom.Next(30);
            WumpusLocation = room;
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
            if (PlayerLocation == WumpusLocation)
            {
                // wumpus
                return "I smell a Wumpus!";
            }
            else if (PlayerLocation == Bat1Location || PlayerLocation == Bat2Location)
            {
                // pits
                return "Bats nearby!";
            }
            else if (PlayerLocation == Pit1Location || PlayerLocation == Pit2Location)
            {
                // bats
                return "I feel a draft!";
            }
            return "";
        }

        // shoots an arrow to a specific room
        public void ShootArrow(int arrowLocation)
        {
            // different outcome based on whether the arrow hits wumpus
            if (WumpusLocation == arrowLocation)
            {
                // win game
                WinOrLose = true;

                EndGame(WinOrLose);
            }
            else
            {
                // wumpus runs away
                RunAwayWumpusLocation();
            }
        }

        // returns a random piece of trivia depending on questions asked (array of answers?)
        public string GetHint()
        {
            return ""; 
        }

        // ends game if player wins or loses (true = win, false = lose)
        public void EndGame(bool wL)
        {
            // based on whether the player has won or lost, sends something different to ui; also resets game -> randomizes all locations
            if (wL == true)
            {
                // win
                RandomizeAllLocations();
            }
            else if (wL == false)
            {
                // lose
                RandomizeAllLocations();
            }
        }

        // resets locations, regardless of whether or not a player has won
        public void RandomizeAllLocations()
        {
            RandomizePlayerLocation();
            RandomizeWumpusLocation();
            RandomizeBatsLocation();
            RandomizePitsLocation();
        }
    }
}
