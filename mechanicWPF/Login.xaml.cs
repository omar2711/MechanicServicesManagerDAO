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
using System.Windows.Shapes;
using mechanicDAO.Model;
using mechanicDAO.Interfaces;
using mechanicDAO.Implementation;
using System.Data;
using System.Net.Security;

namespace mechanicWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            string pass = txtPassword.Password;

            workerImpl workerImpl = new workerImpl();
            DataTable table = new DataTable();
            table = workerImpl.Login(txtUsername.Text, pass);
            if (table.Rows.Count > 0)
            {
                SessionClass.ID = int.Parse(table.Rows[0][0].ToString());
                SessionClass.Username = table.Rows[0][1].ToString();
                SessionClass.SessionRole = table.Rows[0][2].ToString();
                SessionClass.SessionPassword = txtPassword.Password;

                if(workerImpl.SelectFirstTimeAccess() == 1)
                {
                WINchangePassword wINchangePassword = new WINchangePassword();
                wINchangePassword.Show();
                this.Close();
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }

            }
            else
            {
                Exception ex = new Exception();
                MessageBox.Show("Usuario o contraseña incorrectos");
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                
                btnLogin_Click(sender, e);
            }


        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                btnLogin_Click(sender, e);
            }
        }

    }
}
