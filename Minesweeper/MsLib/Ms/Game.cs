using Ms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MsLib
{
    class Game
    {
        public List<MineButton> buttons;
        private MainWindow window;
        private Board board;

        public Game(MainWindow window)
        {
            this.window = window;
            board = new Board();
            buttons = new List<MineButton>();
            newGame();
        }

        private void newGame()
        {
            fillBoard();
        }

        private void fillBoard()
        {
            window.UniGrid.Columns = 24;
            window.UniGrid.Rows = 24;

            int index = 0;
            for (int row = 0; row < 24; row++)
            {
                for (int column = 0; column < 24; column++)
                {
                    MineButton mineButton = new MineButton(board.board[index], buttons, index);
                    buttons.Add(mineButton);
                    window.UniGrid.Children.Add(mineButton);
                    index++;

                    //Button mineButton = new Button();
                    //Image mine = new Image();
                    //mine.Source = new BitmapImage(new Uri(@"/Resources/mine.png", UriKind.RelativeOrAbsolute));
                    //mine.VerticalAlignment = VerticalAlignment.Center;
                    //mineButton.Content = mine;
                    //buttons.Add(mineButton);
                    //window.UniGrid.Children.Add(mineButton);
                    //index++;
                }
            }
        }
    }
}
