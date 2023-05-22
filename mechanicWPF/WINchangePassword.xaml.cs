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

        bool verifyPasswordSecurity()
        {
            string password = txtPassConf.Password;
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasSpecialCharacter = false;
            bool hasNumber = false;
            bool hasLength = false;

            if (password.Length >= 10)
            {
                hasLength = true;
            }

            //loop to verify if the password has an uppercase, lowercase, special character and number
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (char.IsNumber(c))
                {
                    hasNumber = true;
                }
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    hasSpecialCharacter = true;
                }
            }

            //if the password has all the requirements, return true
            if (hasUpperCase == true && hasLowerCase == true && hasSpecialCharacter == true && hasNumber == true && hasLength == true)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            workerImpl workerImpl = new workerImpl();
            worker worker = new worker();

            if(SessionClass.SessionPassword == txtFirstPass.Password)
            {
                if(txtNewPass.Password == txtPassConf.Password)
                {
                    if(verifyPasswordSecurity() == true)
                    {
                        try
                        {
                            workerImpl.UpdatePassword(txtPassConf.Password);
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
                        MessageBox.Show("La contraseña no cumple con los requisitos de seguridad");
                    }

                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }


            }
            else
            {
                MessageBox.Show("La contraseña inicial no es correcta");

            }

        }
    }
}
