using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MsLib
{
    public class MineButton : Button
    {
        Tile tile;

        public MineButton(Tile tile)
        {
            this.tile = tile;
        }
    }
}
