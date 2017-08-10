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


namespace AddressBook
{
    class ContactTypeButton : Button
    {
        private Image arrow;
        private DockPanel defDock, friendDock, workDock, companyDock;
        public ContactTypeButton()
        {
            // Set Image
            arrow = new Image();
            setImage(ref arrow);

            // Set Dropdown menu
            setUpMenu();
            setUpDocks();
            Content = defDock;

        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            ContextMenu.IsEnabled = true;
            ContextMenu.PlacementTarget = this;
            ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            ContextMenu.IsOpen = true;
        }

        private void setUpMenu()
        {
            ContextMenuService.SetIsEnabled(this, true);
            Height = 25;
            Width = 150;
            ContextMenu menu = new ContextMenu();
            MenuItem friend = new MenuItem();
            friend.Header = "Friend";
            friend.Name = "friend";
            friend.Click += (sender, e) =>
            {
                Content = friendDock;
            };

            MenuItem work = new MenuItem();
            work.Header = "Work";
            work.Name = "work";
            work.Click += (sender, e) =>
            {
                Content = workDock;
            };

            MenuItem company = new MenuItem();
            company.Header = "Company";
            company.Name = "company";
            company.Click += (sender, e) =>
            {
                Content = companyDock;
            };

            menu.Items.Add(friend);
            menu.Items.Add(work);
            menu.Items.Add(company);

            this.ContextMenu = menu;
        }

        private void setUpDocks()
        {
            // Set def
            defDock = new DockPanel();
            TextBlock t = new TextBlock();
            t.Text = "Select Contact Type";
            defDock.Children.Add(t);
            defDock.Children.Add(arrow);

            // Set friend
            friendDock = new DockPanel();
            TextBlock t1 = new TextBlock();
            t1.Text = "Friend";
            friendDock.Children.Add(t1);

            // Set work
            workDock = new DockPanel();
            TextBlock t2 = new TextBlock();
            t2 = new TextBlock();
            t2.Text = "Work";
            workDock.Children.Add(t2);

            // Set company
            companyDock = new DockPanel();
            TextBlock t3 = new TextBlock();
            t3.Text = "Company";
            companyDock.Children.Add(t3);
        }

        private void setImage(ref Image img)
        {
            img = new Image();
            img.Source = new BitmapImage(new Uri(@"Properties/Resources/arrow-small-down.png", UriKind.RelativeOrAbsolute));
            img.VerticalAlignment = VerticalAlignment.Bottom;
            img.HorizontalAlignment = HorizontalAlignment.Right;
            img.Height = 10;
            img.Width = 10;
        }
    }
}
