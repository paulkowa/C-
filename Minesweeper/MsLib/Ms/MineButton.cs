﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MsLib
{
    public class MineButton : Button
    {
        private Tile tile;
        private Image flag, mine;
        private List<MineButton> buttons;
        int index;

        public MineButton(Tile tile, List<MineButton> buttons, int index)
        {
            //initalize globals
            this.tile = tile;
            this.index = index;
            this.buttons = buttons;

            //Set flag
            flag = new Image();
            flag.Source = new BitmapImage(new Uri(@"/Resources/flagIcon.png", UriKind.RelativeOrAbsolute));
            flag.VerticalAlignment = VerticalAlignment.Center;
            //Set Mine
            mine = new Image();
            mine.Source = new BitmapImage(new Uri(@"/Resources/mine.png", UriKind.RelativeOrAbsolute));
            mine.VerticalAlignment = VerticalAlignment.Center;

            Background = Brushes.LightGray;
        }
        //Right Click
        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);
            //Set flags
            if (tile.isFlagged)
            {
                Content = null;
                tile.isFlagged = false;
            }

            else if (tile.isActive) { return; }

            else
            {
                Content = flag;
                tile.isFlagged = true;
            }
        }
        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e);
        }
        //Left Click
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (tile.isFlagged) { return; }
            else
            {
                if (tile.isMine)
                {
                    this.Content = mine;
                    this.Background = Brushes.White;
                    tile.isActive = true;
                }

                else if (tile.isActive == false)
                {
                    TextBlock t = new TextBlock();
                    if (tile.nearbyMines > 0) { t.Text = Convert.ToString(tile.nearbyMines); }
                    else { checkNeighbors(this); }
                    setText(t, this.tile);
                    this.Content = t;
                    this.Background = Brushes.White;
                    tile.isActive = true;
                }
                else { return; }
            }
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if(tile.isActive == true) { checkNeighbors(this); }
        }

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
        private void checkNeighbors(MineButton mine)
        {
            Queue<MineButton> neigh = new Queue<MineButton>();
            if (index == 0 || index == 23 || index == 552 || index == 575)
            {
                switch (index)
                {
                    case 0:
                        neigh.Enqueue(buttons[index + 1]);
                        neigh.Enqueue(buttons[index + 25]);
                        neigh.Enqueue(buttons[index + 24]);
                        break;
                    case 23:
                        neigh.Enqueue(buttons[index - 1]);
                        neigh.Enqueue(buttons[index + 23]);
                        neigh.Enqueue(buttons[index + 24]);
                        break;
                    case 552:
                        neigh.Enqueue(buttons[index + 1]);
                        neigh.Enqueue(buttons[index - 23]);
                        neigh.Enqueue(buttons[index - 24]);
                        break;
                    case 575:
                        neigh.Enqueue(buttons[index - 1]);
                        neigh.Enqueue(buttons[index - 25]);
                        neigh.Enqueue(buttons[index - 24]);
                        break;
                }
            }
            else if (index % 24 == 0)
            {
                neigh.Enqueue(buttons[index + 1]);
                neigh.Enqueue(buttons[index + 25]);
                neigh.Enqueue(buttons[index + 24]);
                neigh.Enqueue(buttons[index - 24]);
                neigh.Enqueue(buttons[index - 23]);
            }
            else if (index % 24 == 23)
            {
                neigh.Enqueue(buttons[index + 24]);
                neigh.Enqueue(buttons[index + 23]);
                neigh.Enqueue(buttons[index - 1]);
                neigh.Enqueue(buttons[index - 25]);
                neigh.Enqueue(buttons[index - 24]);
            }
            else if (index < 23)
            {
                neigh.Enqueue(buttons[index + 1]);
                neigh.Enqueue(buttons[index + 25]);
                neigh.Enqueue(buttons[index + 24]);
                neigh.Enqueue(buttons[index + 23]);
                neigh.Enqueue(buttons[index - 1]);
            }
            else if (index > 552)
            {
                neigh.Enqueue(buttons[index + 1]);
                neigh.Enqueue(buttons[index - 1]);
                neigh.Enqueue(buttons[index - 25]);
                neigh.Enqueue(buttons[index - 24]);
                neigh.Enqueue(buttons[index - 23]);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    neigh.Enqueue(buttons[index + 1]);
                    neigh.Enqueue(buttons[index + 25]);
                    neigh.Enqueue(buttons[index + 24]);
                    neigh.Enqueue(buttons[index + 23]);
                    neigh.Enqueue(buttons[index - 1]);
                    neigh.Enqueue(buttons[index - 25]);
                    neigh.Enqueue(buttons[index - 24]);
                    neigh.Enqueue(buttons[index - 23]);
                }
            }
            checkQueue(ref neigh);
        }

        private void checkQueue(ref Queue<MineButton> queue)
        {
            while (queue.Count > 0)
            {
                MineButton mb = queue.Dequeue();
                setTile(mb);
                //if (mb.tile.nearbyMines == 0) { checkNeighbors(mb); }
            }
        }

        private void setTile(MineButton button)
        {
            if (button.tile.isFlagged || button.tile.isMine) { return; }
            else
            {
                if(button.tile.nearbyMines > 0)
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
    }
}

