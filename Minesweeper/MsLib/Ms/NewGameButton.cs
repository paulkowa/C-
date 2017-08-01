using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ms
{
    public class NewGameButton : Button
    {
        private Game game;
        public NewGameButton(Game game)
        {
            // Link to game class
            this.game = game;
            // Set button values
            setProperties();
        }

        private void setProperties()
        {
            Background = Brushes.LightGray;
            BorderBrush = Brushes.Gray;
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
            Height = 40;
            Width = 40;

            Image i = new Image();
            i.Source = new BitmapImage(new Uri(@"/Resources/smile.png", UriKind.RelativeOrAbsolute));
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            Content = i;

        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            //game.newGame();

        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e);
        }
    }
}
