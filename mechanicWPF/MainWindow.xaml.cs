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
using mechanicWPF.Pages;
using mechanicDAO.Model;
using mechanicDAO.Implementation;
using mechanicDAO.Interfaces;

namespace mechanicWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Window_Loaded);
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            lblUserName.Content = SessionClass.Username;
            lblUserId.Content = SessionClass.ID;
            lblRoleId.Content = SessionClass.SessionRole;

            if(SessionClass.SessionRole == "4")
            {
                DropdownButton.Visibility = Visibility.Visible;
                btnCategories.Visibility = Visibility.Visible;

            }else if(SessionClass.SessionRole == "6")
            {
                DropdownButton.Visibility = Visibility.Collapsed;
                grdAdmn.Visibility = Visibility.Collapsed;
                
            }else if (SessionClass.SessionRole == "7")
            {
                btnCategories.Visibility= Visibility.Collapsed;
                grdCategories.Visibility = Visibility.Collapsed;
                DropdownButton.Visibility = Visibility.Collapsed;
                grdAdmn.Visibility = Visibility.Collapsed;
                btnCategories.Visibility = Visibility.Collapsed;
                grdCategories.Visibility = Visibility.Collapsed;
            }


        }

        #region windowControlButtons
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        #region navbarButtons
        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PgCategory();
        }
        #endregion

        private void btnServices_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PgServices();
        }

        


        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void DropdownButton_Click(object sender, RoutedEventArgs e)
        {
            if (DropdownPopup.IsOpen)
                DropdownPopup.IsOpen = false;
            else
                DropdownPopup.IsOpen = true;
        }

       

        private void btnWorkers_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PgWorker();
        }

        private void lblUserName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame.Content = new PgProfile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PgProduct();
        }
    }
}
