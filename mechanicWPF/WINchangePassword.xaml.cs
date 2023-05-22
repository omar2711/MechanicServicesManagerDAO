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
using mechanicDAO.Implementation;
using mechanicDAO.Interfaces;

namespace mechanicWPF
{
    /// <summary>
    /// Interaction logic for WINchangePassword.xaml
    /// </summary>
    public partial class WINchangePassword : Window
    {
        public WINchangePassword()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            workerImpl workerImpl = new workerImpl();
            worker worker = new worker();

            if(SessionClass.SessionPassword == txtFirstPass.Password)
            {
                try
                {
                    workerImpl.UpdatePassword(txtNewPass.Password);
                    MessageBox.Show("Contraseña actualizada");
                    workerImpl.UpdateFirstTimeAccess(int.Parse(SessionClass.ID.ToString()));
                    SessionClass.SessionPassword = txtNewPass.Password;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error al actualizar la contraseña");
                }


            }
            else
            {
                MessageBox.Show("La contraseña inicial no es correcta");

            }

        }
    }
}
