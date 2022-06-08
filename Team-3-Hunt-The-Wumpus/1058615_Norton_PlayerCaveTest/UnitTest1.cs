using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team_3_Hunt_The_Wumpus;
using System.Collections.Generic;
using System;

namespace _1058615_Norton_PlayerCaveTest
{
    [TestClass]
    public class UnitTest1
    {
        Random random = new Random();
        Cave cave;
        Player player = new();
        [TestMethod]
        public void AdjacentRoomsCorrect()
        {
            cave = new(random.Next(1, 4));
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
            cave = new(random.Next(1, 4));
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
            cave = new(random.Next(1, 4));
            cave.SelectedCave = 1;
            List<int> expected = new List<int>();
            expected.Add(1);
            var connectedRooms = cave.GetConnectedRooms(30);

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
            cave = new(random.Next(1, 4));
            cave.SelectedCave = 1;
            List<int> expected = new List<int>();
            expected.Add(1);
            var connectedRooms = cave.GetConnectedRooms(30);

            bool isSame = false;

            for (var i = 0; i < expected.Count; i++)
            {
                if (connectedRooms[i] != expected[i])
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
        [TestMethod]
        public void IncreaseArrowsIncorrect()
        {
            player.Arrows = 0;
            player.IncreaseArrows();
            Assert.IsFalse(player.Arrows == 2);
        }
        [TestMethod]
        public void DecreaseArrowsCorrect()
        {
            player.Arrows = 1;
            player.DecreaseArrows();
            Assert.IsTrue(player.Arrows == 0);
        }
        [TestMethod]
        public void DecreaseArrowsIncorrect()
        {
            player.Arrows = 1;
            player.DecreaseArrows();
            Assert.IsFalse(player.Arrows == 2);
        }
        [TestMethod]
        public void IncreaseCoinsCorrect()
        {
            player.Coins = 0;
            player.IncreaseCoins();
            Assert.IsTrue(player.Coins == 1);
        }
        [TestMethod]
        public void IncreaseCoinsIncorrect()
        {
            player.Coins = 0;
            player.IncreaseCoins();
            Assert.IsFalse(player.Arrows == 2);
        }
        [TestMethod]
        public void DecreaseCoinsCorrect()
        {
            player.Coins = 1;
            player.DecreaseCoins();
            Assert.IsTrue(player.Coins == 0);
        }
        [TestMethod]
        public void DecreaseCoinsIncorrect()
        {
            player.Coins = 1;
            player.DecreaseCoins();
            Assert.IsFalse(player.Coins == 2);
        }
        [TestMethod]
        public void IncreaseTurnsCorrect()
        {
            player.Turns = 0;
            player.IncreaseTurns();
            Assert.IsTrue(player.Turns == 1);
        }
        [TestMethod]
        public void IncreaseTurnsIncorrect()
        {
            player.Turns = 0;
            player.IncreaseTurns();
            Assert.IsFalse(player.Turns == 2);
        }
        [TestMethod]
        public void GetEndScoreCorrect()
        {
            player.WumpusAlive = false;
            player.Coins = 1;
            player.Arrows = 1;
            player.Turns = 5;
            var endScore = player.GetEndScore();
            Assert.IsTrue(endScore == 151);
        }
        [TestMethod]
        public void GetEndScoreIncorrect()
        {
            player.WumpusAlive = false;
            player.Coins = 1;
            player.Arrows = 1;
            player.Turns = 5;
            var endScore = player.GetEndScore();
            Assert.IsFalse(endScore == 152);
        }

    }
}
