using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsLib
{
    public class Tile
    {
        public bool isActive { get; set; }
        public bool isMine { get; set; }
        public bool isFlagged { get; set; }
        public int nearbyMines { get; set; }
        public int index { get; private set; }

        public Tile(int index)
        {
            isActive = false;
            isMine = false;
            isFlagged = false;
            this.index = index;
        }

        public int toInt()
        {
            if(isMine) { return 1; }
            return 0;
        }
    }
}
