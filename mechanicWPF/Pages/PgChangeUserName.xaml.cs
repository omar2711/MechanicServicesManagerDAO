using mechanicDAO.Model;
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
using mechanicDAO.Interfaces;
using System.Data.SqlClient;

namespace mechanicWPF.Pages
{
    /// <summary>
    /// Interaction logic for PgChangeUserName.xaml
    /// </summary>
    public partial class PgChangeUserName : Page
    {
        public PgChangeUserName()
        {
            InitializeComponent();
        }

        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            worker worker = new worker();
            workerImpl workerImpl = new workerImpl();
            worker.UserName = txtNewName.Text;

            if (SessionClass.SessionPassword == txtPass.Text)
            {
                workerImpl.UpdateUserName(txtNewName.Text);
                MessageBox.Show("Nombre de usuario actualizado correctamente");
                SessionClass.Username = txtNewName.Text;
                MainWindow mainWindow = new MainWindow();
                mainWindow.lblUserName.Content = SessionClass.Username;
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta");
            }

        }
    }
}
