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
using mechanicDAO.Implementation;
using mechanicDAO.Model;
using mechanicDAO.Interfaces;

namespace mechanicWPF.Pages
{
    /// <summary>
    /// Interaction logic for PgProfile.xaml
    /// </summary>
    public partial class PgProfile : Page
    {
        public PgProfile()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        //create a on window loaded event

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //set the textboxes with the session values
            lblUsername.Text = SessionClass.Username;

            if(SessionClass.SessionRole == "7")
            {
                lblRole.Text = "Cliente";
            }
            else if(SessionClass.SessionRole=="6")
            {
                lblRole.Text= "Empleado";
            }
            else if (SessionClass.SessionRole == "4")
            {
                lblRole.Text = "Admin";
            }
        }

        private void btnPassChange_Click(object sender, RoutedEventArgs e)
        {
            PgChangePass pgChangePass = new PgChangePass();
            NavigationService.Navigate(pgChangePass);

        }

        private void btnUserChange_Click(object sender, RoutedEventArgs e)
        {
            PgChangeUserName pgChangeUserName = new PgChangeUserName();
            NavigationService.Navigate(pgChangeUserName);
        }
    }
}
