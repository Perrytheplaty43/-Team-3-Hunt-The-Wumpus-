﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    public class Cave
    {
        public int SelectedCave { get; set; }
        public int[,] connectedRooms1 = new int[30,6]{{0, 0, 2, 0, 6, 30 },
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
            {6,7,13,18,17,11 },
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

        public int[,] connectedRooms2 = new int[30, 6] {{0, 26, 0, 7, 0, 0 },
            {0, 0, 9,0,7,0 },
            {0,0,4,0,0,0 },
            {0,5,0,0,0,3 },
            {0,0,0,11,4,0 },
            {0,0,0,12,0,0 },
            {1,2,0,0,0,0 },
            {0,9,0,14,13,0 },
            {0,0,10,0,8,2 },
            {0,11,0,0,0,9 },
            {5,0,0,17,10,0 },
            {6,0,0,18,0,0 },
            {0,8,0,19,0,0 },
            {8,0,0,0,0,0 },
            {0,0,16,21,0,0 },
            {0,17,0,0,0,15 },
            {11,0,0,23,16,0 },
            {12,0,0,24,0,0 },
            {13,0,20,0,0,0 },
            {0,0,0,26,25,19 },
            {15,0,22,0,0,0 },
            {0,23,0,28,0,21 },
            {17,0,0,29,22,0 },
            {18,0,25,0,0,0 },
            {0,20,0,0,0,24 },
            {20,0,0,0,1,0 },
            {0,0,28,0,0,0 },
            {22,29,0,0,0,27 },
            {23,0,30,0,28,0 },
            {0,0,0,0,0,29 } };

        public int[,] connectedRooms3 = new int[30, 6] {{0, 26, 0, 0, 0, 30 }, 
            {0, 0, 9,0,0,0 },
            {0,28,0,9,0,26 },
            {0,5,0,10,0,0 },
            {0,30,0,0,4,28 },
            {0,0,0,0,11,0 },
            {0,0,8,13,0,0 },
            {0,9,0,14,0,7 },
            {3,0,0,0,8,2 },
            {4,0,0,0,15,0 },
            {0,6,0,17,0,0 },
            {0,0,0,0,17,0 },
            {7,0,0,0,0,0 },
            {8,0,21,20,0,0 },
            {0,10,0,0,0,0 },
            {0,0,0,22,0,0 },
            {11,12,0,23,0,0 },
            {0,0,0,24,0,0 },
            {0,0,20,25,0,0 },
            {14,0,0,26,0,19 },
            {0,0,0,0,0,14 },
            {16,0,0,0,27,0 },
            {17,0,0,29,0,0 },
            {18,0,0,0,29,0 },
            {19,0,0,0,0,0 },
            {20,0,3,0,1,0 },
            {0,22,28,0,0,0 },
            {0,0,5,0,3,27 },
            {23,24,30,0,0,0 },
            {0,0,1,0,5,29 } };

        public int[,] connectedRooms4 = new int[30, 6] {{25, 0, 2, 0, 0, 30 }, 
            {0, 0, 9,8,0,1 },
            {27,0,0,0,0,0 },
            {0,0,0,10,0,0},
            {0,30,0,11,0,28 },
            {0,0,0,12,0,0 },
            {0,0,8,0,0,0 },
            {2,0,0,0,13,7 },
            {0,0,10,0,0,2 },
            {4,0,17,0,0,9 },
            {5,0,12,17,0,0 },
            {6,0,0,0,0,11 },
            {0,8,14,0,0,0 },
            {0,0,21,0,19,13 },
            {0,0,16,0,0,0 },
            {0,0,23,0,0,15 },
            {11,0,18,0,0,10 },
            {0,0,19,24,0,17 },
            {0,14,20,0,0,18 },
            {0,0,27,0,0,19 },
            {0,0,22,0,0,14 },
            {0,0,29,0,0,21 },
            {0,0,0,29,0,16 },
            {18,0,0,30,29,0 },
            {0,0,26,1,0,0 },
            {0,0,0,0,0,25 },
            {0,0,28,3,0,20 },
            {0,0,5,0,0,27 },
            {23,24,0,0,0,22 },
            {24,0,0,0,0,0 } };
        public int[,] connectedRooms5 = new int[30, 6] {{25, 26, 2, 7, 6, 30 }, //finish
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


        public int[] GetAdjacentRooms(int room)
        {
            int[] adjacent = new int[6];
            for (int i = 0; i < 6; i++)
            {               
                adjacent[i] = adjacentRooms[room, i];
            }
            return adjacent;
        }

        public List<int> GetConnectedRooms(int room)
        {
            List<int> connected = new List<int>();

            for(int i = 0; i < 6; i++)
            {
                connected.Add(connectedRooms1[room, i]);
                connected.Remove(0);
                //fix for all rooms
            }            
            return connected;
        }

    }
}
