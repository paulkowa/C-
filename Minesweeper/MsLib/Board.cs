using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsLib
{
    public class Board
    {
        public List<Tile> board;

        public Board()
        {
            board = new List<Tile>(576);
            fillBoard(board);
        }

        private void fillBoard(List<Tile> board)
        {
            for(int i = 0; i < board.Capacity; i++) { board.Add(new MsLib.Tile()); }
        }

        private void generateMines()
        {

        }


    }
}
