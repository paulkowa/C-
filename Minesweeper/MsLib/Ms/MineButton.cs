using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ms
{
    public class MineButton : Button
    {
        public Tile tile { get; private set; }
        private Image flag, mine;
        private Game game;

        public MineButton(Tile tile, Game game, int index)
        {
            // Initalize values
            this.tile = tile;
            this.game = game;
            // Set flag image
            flag = new Image();
            flag.Source = new BitmapImage(new Uri(@"/Resources/flagIcon.png", UriKind.RelativeOrAbsolute));
            flag.VerticalAlignment = VerticalAlignment.Center;
            flag.HorizontalAlignment = HorizontalAlignment.Center;
            // Set Mine image
            mine = new Image();
            mine.Source = new BitmapImage(new Uri(@"/Resources/mine.png", UriKind.RelativeOrAbsolute));
            mine.VerticalAlignment = VerticalAlignment.Center;
            flag.HorizontalAlignment = HorizontalAlignment.Center;
            // Set button default background color
            Background = Brushes.LightGray;
        }
        /// <summary>
        /// Right Click event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);
            // Remove flag
            if (tile.isFlagged)
            {
                Content = null;
                Background = Brushes.LightGray;
                game.window.MineCounter.Text = Convert.ToString(Convert.ToInt32(game.window.MineCounter.Text) + 1);
                tile.isFlagged = false;
            }
            // Ignore if tile is already activated
            else if (tile.isActive) { return; }
            // Set flag
            else
            {
                Content = flag;
                Background = Brushes.Blue;
                game.window.MineCounter.Text = Convert.ToString(Convert.ToInt32(game.window.MineCounter.Text) - 1);
                tile.isFlagged = true;
            }
        }
        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e);
        }
        /// <summary>
        /// Left Click event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (game.firstClick)
            {
                if (tile.isMine) { game.board.moveMine(tile); }
                game.startTimer();
            }
            if (tile.isActive || tile.isFlagged) { return; }
            else if (tile.nearbyMines == 0 && tile.isMine == false) { game.checkTiles(tile, false); }
            else { setTile();}
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (e.ChangedButton == MouseButton.Left && tile.isActive) { game.checkTiles(tile, true); }
        }

        /// <summary>
        /// Set the button to display the proper number or mine
        /// </summary>
        public void setTile()
        {
            if (tile.isFlagged) { return; }
            else if(tile.isMine)
            {
                Content = mine;
                Background = Brushes.Red;
                tile.isActive = true;
                game.stopTimer();
            }
            else
            {
                if (tile.nearbyMines > 0)
                {
                    TextBlock t = new TextBlock();
                    t.Text = Convert.ToString(tile.nearbyMines);
                    setText(t, tile);
                    Content = t;
                    Background = Brushes.White;
                    tile.isActive = true;
                }
                else
                {
                    Background = Brushes.White;
                    tile.isActive = true;
                }
            }
        }

        /// <summary>
        /// Set the color of the text within the button to match the number of mines surrounding it
        /// </summary>
        /// <param name="t"></param>
        /// <param name="tile"></param>
        private void setText(TextBlock t, Tile tile)
        {
            t.FontWeight = FontWeights.Bold;
            t.FontSize = 14;
            t.VerticalAlignment = VerticalAlignment.Center;
            t.HorizontalAlignment = HorizontalAlignment.Center;

            switch (tile.nearbyMines)
            {
                case 0:
                    break;
                case 1:
                    t.Foreground = Brushes.Blue;
                    break;
                case 2:
                    t.Foreground = Brushes.Green;
                    break;
                case 3:
                    t.Foreground = Brushes.Red;
                    break;
                case 4:
                    t.Foreground = Brushes.DarkBlue;
                    break;
                case 5:
                    t.Foreground = Brushes.DarkRed;
                    break;
                case 6:
                    t.Foreground = Brushes.DarkCyan;
                    break;
                case 7:
                    t.Foreground = Brushes.Black;
                    break;
                case 8:
                    t.Foreground = Brushes.Orange;
                    break;
            }
        }
    }
}

