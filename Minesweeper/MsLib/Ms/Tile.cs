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

        public Tile()
        {
            isActive = false;
            isMine = false;
            isFlagged = false;
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
    }
}
