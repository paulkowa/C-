using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Gooey gui;
        public MainWindow()
        {
            InitializeComponent();
            gui = new Gooey(this);
            this.Button.Children.Add(contactButton());
            MenuItem m = new MenuItem();
        }

        private ContactTypeButton contactButton()
        {
            ContactTypeButton c = new ContactTypeButton();
            c.VerticalAlignment = VerticalAlignment.Top;
            c.HorizontalAlignment = HorizontalAlignment.Center;
            return c;
        }
    }
}
