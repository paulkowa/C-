using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsLib
{
    public class Board
    {
        List<Tile> board;

        public Board()
        {
            board = new List<Tile>(576);
            Console.WriteLine(board.Count);
        }

        private void fillBoard(List<Tile> board)
        {
        }
    }
}
