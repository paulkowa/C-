using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsLib
{
    public class Tile
    {
        bool isActive { get; set; }
        bool isMine { get; set; }
        bool isFlagged { get; set; }
        int nearbyMines { get; set; }

        public Tile()
        {

        }

        public Tile(bool isMine)
        {
            this.isActive = false;
            this.isMine = isMine;
            this.isFlagged = false;
        }

        public int toInt()
        {
            if(isMine) { return 1; }
            return 0;
        }

        public void setMineCount(ref List<Tile> board)
        {
            int tileCount = board.Capacity;
            //Easy
            if (tileCount == 64) { }
            //Medium
            else if (tileCount == 256) { }

            //Hard difficulty
            else {
                for (int i = 0; i < tileCount; i++)
                {
                    if (i == 0 || i == 23 || i == 552 || i == 575)
                    {
                        switch (i)
                        {
                            case 0:
                                nearbyMines = board[i + 1].toInt() + board[i + 25].toInt() + board[i + 24].toInt();
                                break;
                            case 23:
                                nearbyMines = board[i - 1].toInt() + board[i + 23].toInt() + board[i + 24].toInt();
                                break;
                            case 552:
                                nearbyMines = board[i + 1].toInt() + board[i - 23].toInt() + board[i - 24].toInt();
                                break;
                            case 575:
                                nearbyMines = board[i - 1].toInt() + board[i - 25].toInt() + board[i - 24].toInt();
                                break;
                        }
                    }
                    else
                    {
                        if (i % 24 == 23) { nearbyMines = board[i + 24].toInt() + board[i + 23].toInt() + board[i - 1].toInt() + board[i - 25].toInt() + board[i - 24].toInt(); }
                        else if (i % 24 == 0) { nearbyMines = board[i + 1].toInt() + board[i + 25].toInt() + board[i + 24].toInt() + board[i - 24].toInt() + board[i - 23].toInt(); }
                        else if (i - 24 < 0) { nearbyMines = board[i + 1].toInt() + board[i + 25].toInt() + board[i + 24].toInt() + board[i + 23].toInt() + board[i - 1].toInt(); }
                        else if (i + 24 > 575) { nearbyMines = board[i + 1].toInt() + board[i - 1].toInt() + board[i - 25].toInt() + board[i - 24].toInt() + board[i - 23].toInt(); }
                        else { nearbyMines = board[i + 1].toInt() + board[i + 25].toInt() + board[i + 24].toInt() + board[i +23].toInt() + board[i - 1].toInt() + board[i - 25].toInt() + board[i - 24].toInt() + board[i - 23].toInt(); }
                    }
                }
            }
        }
    }
}
