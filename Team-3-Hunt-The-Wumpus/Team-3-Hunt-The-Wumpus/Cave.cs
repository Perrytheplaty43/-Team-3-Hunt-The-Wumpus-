using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Hunt_The_Wumpus
{
    public class Cave
    {
        public int SelectedCave { get; set; }
        public int[,] connectedRooms1 = new int[30, 6];
        public string[][] connectedRooms1String;
        public string[][] connectedRooms2String;
        public string[][] connectedRooms3String;
        public string[][] connectedRooms4String;
        public string[][] connectedRooms5String;
        public string[][] adjacentRoomsString;


        public int[,] adjacentRooms = new int[30, 6];

        public int[,] connectedRooms2 = new int[30, 6];

        public int[,] connectedRooms3 = new int[30, 6];

        public int[,] connectedRooms4 = new int[30, 6];
        public int[,] connectedRooms5 = new int[30, 6];

        public Cave(int selectedRoom) {
            SelectedCave = selectedRoom;
            string text1 = File.ReadAllText(".\\cave" + SelectedCave + ".txt");
            connectedRooms1String = text1.Split('\n').Select(x => x.Replace("\r", "").Split(',')).ToArray();

            for (int i = 0; i < connectedRooms1String.GetLength(0); i++)
            {
                for (int y = 0; y < connectedRooms1String[i].Length; y++)
                {
                    connectedRooms1[i, y] = int.Parse(connectedRooms1String[i][y]);
                }
            }
            string text2 = File.ReadAllText(".\\caveAdj.txt");
            adjacentRoomsString = text2.Split('\n').Select(x => x.Replace("\r", "").Split(',')).ToArray();

            for (int i = 0; i < adjacentRoomsString.GetLength(0); i++)
            {
                for (int y = 0; y < adjacentRoomsString[i].Length; y++)
                {
                    adjacentRooms[i, y] = int.Parse(adjacentRoomsString[i][y]);
                }
            }
        }
        public int[] GetAdjacentRooms(int room)
        {
            int[] adjacent = new int[6];
            for (int i = 0; i < 6; i++)
            {
                adjacent[i] = adjacentRooms[room - 1, i];
            }
            return adjacent;
        }

        public List<int> GetConnectedRooms(int room)
        {
            List<int> connected = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                connected.Add(connectedRooms1[room -1, i]);
                connected.Remove(0);
            }                     
            return connected;
        }

    }
}
