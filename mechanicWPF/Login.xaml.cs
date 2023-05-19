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
            workerImpl workerImpl = new workerImpl();
            DataTable table= new DataTable();

            try
            {
                table = workerImpl.Login(txtUsername.Text, txtPassword.Text);
                if(table.Rows.Count > 0)
                {
                    SessionClass.ID = int.Parse(table.Rows[0][0].ToString());
                    SessionClass.Username = table.Rows[0][1].ToString();
                    SessionClass.SessionRole = table.Rows[0][2].ToString();
                    SessionClass.SessionPassword = txtPassword.Text;

                    




                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }else
                {
                    Exception ex = new Exception();
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
