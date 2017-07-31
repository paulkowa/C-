using Ms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Threading;

namespace MsLib
{
    public class Game
    {
        public List<MineButton> buttons { get; private set; }
        public MainWindow window { get; private set; }
        public Board board { get; private set; }
        public BackgroundWorker time;
        private const int size = 576;
        private int seconds;

        public Game(MainWindow window)
        {
            // Initalize variables
            this.window = window;
            board = new Board(size);
            buttons = new List<MineButton>();
            // Create thread for timer
            time = new BackgroundWorker();
            int seconds = 0;
            // Start game
            newGame();
        }

        private void newGame()
        {
            fillBoard();
            startTimer();
            window.MineCounter.Text = Convert.ToString(board.mineTotal);
        }
        // Fills the UI with new buttons representing the tiles for the game
        private void fillBoard()
        {
            window.UniGrid.Columns = 24;
            window.UniGrid.Rows = 24;

            int index = 0;
            for (int row = 0; row < 24; row++)
            {
                for (int column = 0; column < 24; column++)
                {
                    MineButton mineButton = new MineButton(board.board[index], this, index);
                    buttons.Add(mineButton);
                    window.UniGrid.Children.Add(mineButton);
                    index++;
                }
            }
        }

        private void startTimer()
        {
            time.WorkerReportsProgress = true;
            time.ProgressChanged += Time_ProgressChanged;
            time.DoWork += (sender, e) =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    time.ReportProgress(500);
                }
            };


            time.RunWorkerAsync(seconds);

        }
        private void Time_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            window.Timer.Text = Convert.ToString(++seconds);
        }



        //public void checkQueue(Queue<MineButton> queue)
        //{
        //    while (queue.Count > 0)
        //    {
        //        MineButton mb = queue.Dequeue();
        //        setTile(mb);
        //        if (mb.tile.nearbyMines == 0) { runInBackground(mb); }
        //    }
        //}

        private void runInBackground(MineButton mb)
        {
            Worker thread = new MsLib.Worker(mb.tile);

        }

        //Create a queue of adjacent tiles to the given tile
        public Queue<Tile> checkNeighbors(Tile t)
        {
            int index = t.index;
            Queue<Tile> tiles = new Queue<Tile>();
            if (index == 0 || index == 23 || index == 552 || index == 575)
            {
                switch (index)
                {
                    case 0:
                        tiles.Enqueue(board.board[index + 1]);
                        tiles.Enqueue(board.board[index + 25]);
                        tiles.Enqueue(board.board[index + 24]);
                        break;
                    case 23:
                        tiles.Enqueue(board.board[index - 1]);
                        tiles.Enqueue(board.board[index + 23]);
                        tiles.Enqueue(board.board[index + 24]);
                        break;
                    case 552:
                        tiles.Enqueue(board.board[index + 1]);
                        tiles.Enqueue(board.board[index - 23]);
                        tiles.Enqueue(board.board[index - 24]);
                        break;
                    case 575:
                        tiles.Enqueue(board.board[index - 1]);
                        tiles.Enqueue(board.board[index - 25]);
                        tiles.Enqueue(board.board[index - 24]);
                        break;
                }
            }
            else if (index % 24 == 0)
            {
                tiles.Enqueue(board.board[index + 1]);
                tiles.Enqueue(board.board[index + 25]);
                tiles.Enqueue(board.board[index + 24]);
                tiles.Enqueue(board.board[index - 24]);
                tiles.Enqueue(board.board[index - 23]);
            }
            else if (index % 24 == 23)
            {
                tiles.Enqueue(board.board[index + 24]);
                tiles.Enqueue(board.board[index + 23]);
                tiles.Enqueue(board.board[index - 1]);
                tiles.Enqueue(board.board[index - 25]);
                tiles.Enqueue(board.board[index - 24]);
            }
            else if (index < 23)
            {
                tiles.Enqueue(board.board[index + 1]);
                tiles.Enqueue(board.board[index + 25]);
                tiles.Enqueue(board.board[index + 24]);
                tiles.Enqueue(board.board[index + 23]);
                tiles.Enqueue(board.board[index - 1]);
            }
            else if (index > 552)
            {
                tiles.Enqueue(board.board[index + 1]);
                tiles.Enqueue(board.board[index - 1]);
                tiles.Enqueue(board.board[index - 25]);
                tiles.Enqueue(board.board[index - 24]);
                tiles.Enqueue(board.board[index - 23]);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    tiles.Enqueue(board.board[index + 1]);
                    tiles.Enqueue(board.board[index + 25]);
                    tiles.Enqueue(board.board[index + 24]);
                    tiles.Enqueue(board.board[index + 23]);
                    tiles.Enqueue(board.board[index - 1]);
                    tiles.Enqueue(board.board[index - 25]);
                    tiles.Enqueue(board.board[index - 24]);
                    tiles.Enqueue(board.board[index - 23]);
                }
            }
            return tiles;
        }
    }
}
