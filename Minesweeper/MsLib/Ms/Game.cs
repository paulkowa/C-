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
using System.Windows.Controls.Primitives;

namespace Ms
{
    public class Game
    {
        private List<MineButton> mineButtons;
        public MainWindow window { get; private set; }
        public Board board { get; private set; }
        public bool firstClick { get; set; }
        private Queue<Tile> update;
        private const int size = 576;
        private int seconds;
        private BackgroundWorker time;

        public Game(MainWindow window)
        {
            // Initalize variables
            this.window = window;
            board = new Board(size);
            mineButtons = new List<MineButton>();
            update = new Queue<Tile>();
            firstClick = true;
            // Start game
            newGame();
        }

        /// <summary>
        /// Method called upon creating a new game or pressing the new game button
        /// </summary>
        public void newGame()
        {
            clearBoard();
            fillBoard();
            createNewGameButton(this);
            window.MineCounter.Text = Convert.ToString(board.mineTotal);
        }

        //public void newGame()
        //{
        //    BackgroundWorker worker = new BackgroundWorker();
        //    worker.WorkerReportsProgress = false;
        //    worker.RunWorkerCompleted += NewGame_RunWorkerCompleted;
        //    worker.DoWork += (sender, e) =>
        //    {
                
        //    };
        //    worker.RunWorkerAsync();
        //}

        /// <summary>
        /// Run upon CheckTiles worker completion to update GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setTiles(update);
            update = new Queue<Tile>();
        }

        /// <summary>
        /// Clear all values from the GUI board and background datastructures
        /// </summary>
        private void clearBoard()
        {
            if (window.UniGrid.Children.Count > 0)
            {
                for (int i = window.UniGrid.Children.Count - 1; i >= 0; i--)
                {
                    window.UniGrid.Children.RemoveAt(i);
                }
            }
            board = new Board(size);
            mineButtons = new List<MineButton>();
        }
        /// <summary>
        /// Fills the UI with new buttons representing the tiles for the game
        /// </summary>
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
                    mineButtons.Add(mineButton);
                    window.UniGrid.Children.Add(mineButton);
                    index++;
                }
            }
        }

        /// <summary>
        /// Add a newGameButton to the GUI
        /// </summary>
        private void createNewGameButton(Game game)
        {
            NewGameButton newGame = new NewGameButton(game);
            window.TopGrid.Children.Add(newGame);
            Grid.SetColumn(newGame, 3);
        }

        /// <summary>
        /// Create and run a new async thread to update the timer
        /// </summary>
        public void startTimer()
        {
            firstClick = false;
            time = new BackgroundWorker();
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
        public void stopTimer()
        {
            
        }
        /// <summary>
        /// GUI call for ascyn thread to update the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Time_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            window.Timer.Text = Convert.ToString(++seconds);
        }

        /// <summary>
        /// Create a worker thread to check surrounding tiles and reveal all empty tiles in a chain
        /// </summary>
        /// <param name="t"></param>
        public void checkTiles(Tile t, bool doubleClick)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = false;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            if (doubleClick)
            {
                worker.DoWork += (sender, e) =>
                {
                    update = checkQueue(checkNeighbors(t), new List<Tile>());
                };
            }
            else
            {
                worker.DoWork += (sender, e) =>
                {
                    update = checkQueue(checkNeighbors(t), new List<Tile>());
                };
            }
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Run upon CheckTiles worker completion to update GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setTiles(update);
            update = new Queue<Tile>();
        }

        /// <summary>
        /// GUI call to update buttons once asycn searching thread is completed
        /// </summary>
        /// <param name="queue"></param>
        public void setTiles(Queue<Tile> queue)
        {
            while (queue.Count > 0)
            {
                Tile t = queue.Dequeue();
                if (!t.isFlagged) {
                    mineButtons[t.index].setTile();
                }
            }
        }
        /// <summary>
        /// Check a queue of tiles for all adjacent empty tiles
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="doNotCheck"></param>
        /// <returns>A queue of tiles in a cascade chain</returns>
        private Queue<Tile> checkQueue(Queue<Tile> queue, List<Tile> doNotCheck)
        {
            int size = queue.Count;
            Queue<Tile> temp = new Queue<Tile>();

            while(size > 0)
            {
                Tile t = queue.Dequeue();
                if(t.nearbyMines == 0 && !doNotCheck.Contains(t))
                {
                    doNotCheck.Add(t);
                    temp = checkQueue(checkNeighbors(t), doNotCheck);
                    queue.Enqueue(t);
                    while (temp.Count > 0)
                    {
                        queue.Enqueue(temp.Dequeue());
                    }
                }
                if(!doNotCheck.Contains(t)) { doNotCheck.Add(t); }
                queue.Enqueue(t);
                size--;
            }
            return queue;
        }

        /// <summary>
        /// Create a queue of adjacent tiles to the given tile
        /// Needs to be updated to dynamically change with board size
        /// </summary>
        /// <param name="t"></param>
        /// <returns>A queue of neighboring tiles, and the original tile</returns>
        private Queue<Tile> checkNeighbors(Tile t)
        {
            int index = t.index;
            Queue<Tile> tiles = new Queue<Tile>();
            tiles.Enqueue(t);
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
