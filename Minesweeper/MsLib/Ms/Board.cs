using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsLib
{
    public class Board
    {
        private int size;
        public double mineTotal { get; private set; }
        public List<Tile> board { get; private set; }
        public Board(int size)
        {
            // Initialize values
            this.size = size;
            board = new List<Tile>();
            // Fill board, assign mines, and assign tile mine count
            fillBoard(board, this.size);
            generateMines(board, size);
            mineCount(board, size);
        }
        // Fill the board array with the correct number of tiles
        private void fillBoard(List<Tile> board, int size)
        {
            for (int i = 0; i < size; i++) { board.Add(new Tile(i)); }
        }

        // Assign tiles as mines at random
        private void generateMines(List<Tile> board, int size)
        {
            Random rand = new Random();
            double mines = Math.Round(size * 0.2);
            mineTotal = mines;
            while (mines > 0)
            {
                int i = rand.Next(0, size - 1);
                if (board[i].isMine == false)
                {
                    board[i].isMine = true;
                    mines--;
                }
            }
        }

        // Assign tiles with their correct nearby mine values
        private void mineCount(List<Tile> board, int size)
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (i == 0 || i == 23 || i == 552 || i == 575)
                {
                    switch (i)
                    {
                        case 0:
                            board[i].nearbyMines = board[i + 1].toInt() + board[i + 25].toInt() + board[i + 24].toInt();
                            break;
                        case 23:
                            board[i].nearbyMines = board[i - 1].toInt() + board[i + 23].toInt() + board[i + 24].toInt();
                            break;
                        case 552:
                            board[i].nearbyMines = board[i + 1].toInt() + board[i - 23].toInt() + board[i - 24].toInt();
                            break;
                        case 575:
                            board[i].nearbyMines = board[i - 1].toInt() + board[i - 25].toInt() + board[i - 24].toInt();
                            break;
                    }
                }
                else
                {
                    if (i % 24 == 23) { board[i].nearbyMines = board[i + 24].toInt() + board[i + 23].toInt() + board[i - 1].toInt() + board[i - 25].toInt() + board[i - 24].toInt(); }
                    else if (i % 24 == 0) { board[i].nearbyMines = board[i + 1].toInt() + board[i + 25].toInt() + board[i + 24].toInt() + board[i - 24].toInt() + board[i - 23].toInt(); }
                    else if (i < 23) { board[i].nearbyMines = board[i + 1].toInt() + board[i + 25].toInt() + board[i + 24].toInt() + board[i + 23].toInt() + board[i - 1].toInt(); }
                    else if (i > 552) { board[i].nearbyMines = board[i + 1].toInt() + board[i - 1].toInt() + board[i - 25].toInt() + board[i - 24].toInt() + board[i - 23].toInt(); }
                    else { board[i].nearbyMines = board[i + 1].toInt() + board[i + 25].toInt() + board[i + 24].toInt() + board[i + 23].toInt() + board[i - 1].toInt() + board[i - 25].toInt() + board[i - 24].toInt() + board[i - 23].toInt(); }
                }
            }
        }
    }
}

