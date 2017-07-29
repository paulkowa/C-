﻿using System;
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
            fillBoard();
            generateMines();
            mineCount();
        }

        private void fillBoard()
        {
            for (int i = 0; i < board.Capacity; i++) { board.Add(new Tile()); }
        }

        private void generateMines()
        {
            Random rand = new Random();
            int mines = 99;

            while (mines > 0)
            {
                int i = rand.Next(0, 575);
                if (board[i].isMine == false)
                {
                    board[i].isMine = true;
                    mines--;
                }
            }
        }

        private void mineCount()
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
