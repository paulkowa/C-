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

namespace MsLib
{
    public class MineButton : Button
    {
        public Tile tile { get; private set; }
        public int index { get; private set; }
        private Image flag, mine;
        private Game game;

        public MineButton(Tile tile, Game game, int index)
        {
            // Initalize values
            this.tile = tile;
            this.index = index;
            this.game = game;

            // Set flag image
            flag = new Image();
            flag.Source = new BitmapImage(new Uri(@"/Resources/flagIcon.png", UriKind.RelativeOrAbsolute));
            flag.VerticalAlignment = VerticalAlignment.Center;
            // Set Mine image
            mine = new Image();
            mine.Source = new BitmapImage(new Uri(@"/Resources/mine.png", UriKind.RelativeOrAbsolute));
            mine.VerticalAlignment = VerticalAlignment.Center;
            // Set button default background color
            Background = Brushes.LightGray;
        }
        // Right Click
        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);
            // Remove flag
            if (tile.isFlagged)
            {
                Content = null;
                game.window.MineCounter.Text = Convert.ToString(Convert.ToInt32(game.window.MineCounter.Text) + 1);
                tile.isFlagged = false;
            }
            // Ignore if tile is already activated
            else if (tile.isActive) { return; }
            // Set flag
            else
            {
                Content = flag;
                game.window.MineCounter.Text = Convert.ToString(Convert.ToInt32(game.window.MineCounter.Text) - 1);
                tile.isFlagged = true;
            }
        }
        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e);
        }
        // Left Click
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            setTile(this);
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);
        }

        // Set the button to display the proper number or mine
        private void setTile(MineButton button)
        {
            if (button.tile.isFlagged) { return; }
            else if(button.tile.isMine)
            {
                button.Content = mine;
                button.Background = Brushes.White;
                button.tile.isActive = true;
            }
            else
            {
                if (button.tile.nearbyMines > 0)
                {
                    TextBlock t = new TextBlock();
                    t.Text = Convert.ToString(button.tile.nearbyMines);
                    setText(t, button.tile);
                    button.Content = t;
                    button.Background = Brushes.White;
                    button.tile.isActive = true;
                }
                else
                {
                    button.Background = Brushes.White;
                    button.tile.isActive = true;
                }
            }
        }

        // Set the color of the text within the button to match the number of mines surrounding it
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

