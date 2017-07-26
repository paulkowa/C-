using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsLib;

namespace Tests
{
    [TestClass]
    public class BoardTests
    {
        Board b = new Board();

        //Test the default board size
        [TestMethod]
        public void TestDefaultCon()
        {
            Assert.IsTrue(b.board.Count == 576);          
        }

        //Test that the correct number of mines are being generated
        [TestMethod]
        public void TestMines()
        {
            int i = 0;
            foreach (Tile t in b.board)
            {
                if(t.isMine) { i++; }
            }

            Assert.AreEqual(99, i);
        }

        //Test upper left corner is generating the proper mine count
        [TestMethod]
        public void Test0()
        {
            int i = 0;

            i += b.board[1].toInt();
            i += b.board[25].toInt();
            i += b.board[24].toInt();
            Assert.AreEqual(i, b.board[0].nearbyMines);
        }

        //Test upper right corner is generating the proper mine count
        [TestMethod]
        public void Test23()
        {
            int i = 0;
            i += b.board[22].toInt();
            i += b.board[46].toInt();
            i += b.board[47].toInt();
            Assert.AreEqual(i, b.board[23].nearbyMines);

        }

        //Test the bottom left corner is generating the proper mine count
        [TestMethod]
        public void Test552()
        {
            int i = 0;
            i += b.board[553].toInt();
            i += b.board[528].toInt();
            i += b.board[529].toInt();
            Assert.AreEqual(i, b.board[552].nearbyMines);
        }

        //Test the bottom right corner is generating the proper mine count 
        [TestMethod]
        public void Test575()
        {
            int i = 0;
            i += b.board[574].toInt();
            i += b.board[551].toInt();
            i += b.board[550].toInt();
            Assert.AreEqual(i, b.board[575].nearbyMines);

        }

        //Test item on the top edge is generating the proper mine count
        [TestMethod]
        public void Test12()
        {
            int i = 0;
            i += b.board[13].toInt();
            i += b.board[37].toInt();
            i += b.board[36].toInt();
            i += b.board[35].toInt();
            i += b.board[11].toInt();
            Assert.AreEqual(i, b.board[12].nearbyMines);

        }
        [TestMethod]
        public void Test1()
        {
            int i = 0;
            i += b.board[0].toInt();
            i += b.board[2].toInt();
            i += b.board[25].toInt();
            i += b.board[26].toInt();
            i += b.board[24].toInt();
            Assert.AreEqual(i, b.board[1].nearbyMines);
        }

        //Test item on the right edge is generating the proper mine count
        [TestMethod]
        public void Test71()
        {
            int i = 0;
            i += b.board[47].toInt();
            i += b.board[46].toInt();
            i += b.board[70].toInt();
            i += b.board[94].toInt();
            i += b.board[95].toInt();
            Assert.AreEqual(i, b.board[71].nearbyMines);
        }

        //Test item on the bottom edge is generating the proper mine count
        [TestMethod]
        public void Test563()
        {
            int i = 0;
            i += b.board[564].toInt();
            i += b.board[562].toInt();
            i += b.board[538].toInt();
            i += b.board[539].toInt();
            i += b.board[540].toInt();
            Assert.AreEqual(i, b.board[563].nearbyMines);
        }

        //Test item on the left edge is generating the proper mine count
        [TestMethod]
        public void Test72()
        {
            int i = 0;
            i += b.board[73].toInt();
            i += b.board[97].toInt();
            i += b.board[96].toInt();
            i += b.board[48].toInt();
            i += b.board[49].toInt();
            Assert.AreEqual(i, b.board[72].nearbyMines);
        }

        //Test item in the middle is generating the proper mine count
        [TestMethod]
        public void Test200()
        {
            int i = 0;
            i += b.board[201].toInt();
            i += b.board[225].toInt();
            i += b.board[224].toInt();
            i += b.board[223].toInt();
            i += b.board[199].toInt();
            i += b.board[175].toInt();
            i += b.board[176].toInt();
            i += b.board[177].toInt();
            Assert.AreEqual(i, b.board[200].nearbyMines);
        }
    }

    [TestClass]
    public class TileTests
    {
        Tile t = new Tile();

        [TestMethod]
        public void TestDefaultCon()
        {
            Assert.IsFalse(t.isActive || t.isFlagged || t.isMine);
        }
        [TestMethod]
        public void TestMineCon()
        {
            Tile y = new Tile(true);
            Assert.IsTrue(y.isMine && !(y.isFlagged || y.isActive));
        }

        [TestMethod]
        public void TestToIntNotSet()
        {
            Assert.AreEqual(0, t.toInt());
        }

        [TestMethod]
        public void TestToIntSet()
        {
            t.isMine = true;
            Assert.AreEqual(1, t.toInt());
        }
    }
}
