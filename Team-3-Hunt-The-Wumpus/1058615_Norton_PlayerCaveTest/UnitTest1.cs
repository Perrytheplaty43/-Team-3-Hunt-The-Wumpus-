using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team_3_Hunt_The_Wumpus;
using System.Collections.Generic;

namespace _1058615_Norton_PlayerCaveTest
{
    [TestClass]
    public class UnitTest1
    {
        Cave cave = new();
        Player player = new();
        [TestMethod]
        public void AdjacentRoomsCorrect()
        { 
            int[] expected = new int[6] { 25, 26, 2, 7, 6, 30 };
            var adjacentRooms = cave.GetAdjacentRooms(1);

            bool isSame = true;

            for(var i = 0; i < expected.Length; i++)
            {
                if (adjacentRooms[i] != expected[i])
                    isSame = false;
            }

            Assert.IsTrue(isSame);
        }
        [TestMethod]
        public void AdjacentRoomsIncorrect()
        {
            int[] expected = new int[6] { 25, 26, 2, 7, 6, 30 };
            var adjacentRooms = cave.GetAdjacentRooms(1);

            bool isSame = false;

            for (var i = 0; i < expected.Length; i++)
            {
                if (adjacentRooms[i] != expected[i])
                    isSame = true;
            }

            Assert.IsFalse(isSame);
        }
        [TestMethod]
        public void ConnectedRoomsCorrect()
        {
            cave.SelectedCave = 1;
            List<int> expected = new List<int>();
            var connectedRooms = cave.GetConnectedRooms(1);

            bool isSame = true;

            for (var i = 0; i < expected.Count; i++)
            {
                if (connectedRooms[i] != expected[i])
                    isSame = false;
            }

            Assert.IsTrue(isSame);
        }
        [TestMethod]
        public void ConnectedRoomsIncorrect()
        {
            int[] expected = new int[6] { 25, 26, 2, 7, 6, 30 };
            var adjacentRooms = cave.GetAdjacentRooms(1);

            bool isSame = false;

            for (var i = 0; i < expected.Length; i++)
            {
                if (adjacentRooms[i] != expected[i])
                    isSame = true;
            }

            Assert.IsFalse(isSame);
        }
        [TestMethod]
        public void IncreaseArrowsCorrect()
        {
            player.Arrows = 0;
            player.IncreaseArrows();
            Assert.IsTrue(player.Arrows == 1);
        }

    }
}
