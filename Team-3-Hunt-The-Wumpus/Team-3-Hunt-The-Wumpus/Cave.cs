using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    public class Cave
    {
        public int[,] connectedRooms = new int[30,6]{{0, 0, 2, 0, 6, 30 },
            {0, 0, 0,8,0,1 },
            {0,0,0,9,0,0 },
            {28,5,0,0,0,0 },
            {0,0,0,11,4,0 },
            {0,1,0,0,11,0 },
            {0,0,0,13,12,0 },
            {2,0,15,14,0,0 },
            {3,0,10,0,0,0 },
            {0,0,0,16,15,9 },
            {5,6,0,17,0,0 },
            {0,7,0,0,0,0 },
            {7,0,14,0,0,0 },
            {8,0,0,20,0,13 },
            {0,10,0,21,0,8 },
            {10,0,0,22,21,0 },
            {11,0,18,23,0,0 },
            {0,0,0,0,0,17 },
            {0,0,20,0,0,0 },
            {14,0,0,0,25,19 },
            {15,16,0,0,0,0 },
            {16,0,0,0,27,0},
            {17,0,0,29,0,0 },
            {0,0,25,0,29,0 },
            {0,20,0,0,0,24 },
            {0,27,0,0,0,0 },
            {0,22,28,0,26,0 },
            {0,0,0,4,0,27 },
            {23,24,0,0,0,0 },
            {0,0,1,0,0,0 } };

        public int[,] adjacentRooms = new int[30, 6] {{25, 26, 2, 7, 6, 30 }, 
            {26, 3, 9,8,7,1 },
            {27,28,4,9,2,26 }, 
            {28,5,11,10,9,3 }, 
            {29,30,6,11,4,28 }, 
            {30,1,7,12,11,5 }, 
            {1,2,8,13,12,6 }, 
            {2,9,15,14,13,7 }, 
            {3,4,10,15,8,2 }, 
            {4,11,17,16,15,9 },
            {5,6,12,17,10,4 }, 
            {6,7,13,18,27,11 },
            {7,8,14,19,18,12 },
            {8,15,21,20,19,13 },
            {9,10,16,21,14,8 },
            {10,17,23,22,21,15 },
            {11,12,18,23,16,10 },
            {12,13,19,24,23,17 }, 
            {13,14,20,25,24,18 },
            {14,21,27,26,25,19 },
            {15,16,22,27,20,14 },
            {16,23,29,28,27,21 },
            {17,18,24,29,22,16 },
            {18,19,25,30,29,23 },
            {19,20,26,1,30,24 },
            {20,27,3,2,1,25 },
            {21,22,28,3,26,20 },
            {22,29,5,4,3,27 },
            {23,24,30,5,28,22 },
            {24,25,1,6,5,29 } };

        GameLocation location;

        public Cave(GameLocation my)
        {
            location = my;
            
            //only for testing
            Console.WriteLine(location.PlayerLocation);
        }

        public string GetAdjacentRooms(int room)
        {
            string adjacent = "";
            for (int i = 0; i < 7; i++)
            {               
                adjacent += adjacentRooms[room, i].ToString() + ",";
            }
            return adjacent;
        }

        public string GetConnectedRooms(int room)
        {
            string connected = "";
            for(int i = 0; i < 7; i++)
            {
                connected += connectedRooms[room, i].ToString() + ",";
            }            
            connected.Replace("0,", "");
            return connected;
        }

        //room class
    }
}
