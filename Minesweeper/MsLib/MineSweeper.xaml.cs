using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MsLib;

namespace Ms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board b;

        public MainWindow()
        {
            InitializeComponent();
            b = new Board();
            fillGrid();
            //main.MouseUp += new MouseButtonEventHandler(main_MouseUp);
            //((MainWindow)Application.Current.MainWindow)..Text = Convert.ToString(b.board.Count);

        }

        private void fillGrid()
        {
            UniGrid.Columns = 24;
            UniGrid.Rows = 24;

            int k = 0;
            for(int i = 0; i < 24; i++)
            {
                for(int j = 0; j < 24; j++)
                {
                    MineButton mineButton = new MineButton(b.board[k]);
                    Image img = new Image();
                    if (b.board[k].isMine) { mineButton.Content = img; }
                    UniGrid.Children.Add(mineButton);
                    k++;
                }
            }
        }

        //private void main_MouseDown(object sender, MouseButtonEventArgs e)
        //{

        //}

        //private void main_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        //}
    }
}
