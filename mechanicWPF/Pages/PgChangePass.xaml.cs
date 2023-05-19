using mechanicDAO.Implementation;
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

namespace mechanicWPF.Pages
{
    /// <summary>
    /// Interaction logic for PgChangePass.xaml
    /// </summary>
    public partial class PgChangePass : Page
    {
        public PgChangePass()
        {
            InitializeComponent();
        }

        bool comparePass()
        {
            if(txtNewPass.Text == txtNewPass2.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //method to verify if the new password is of 10 characters, has an upercase, numbers, and special characters
        bool verifyPasswordSecurity()
        {
            string password = txtNewPass.Text;
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


        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            worker worker = new worker();
            workerImpl workerImpl = new workerImpl();


            if(SessionClass.SessionPassword == txtOldPass.Text)
            {
                if (comparePass() == true)
                {
                    if (verifyPasswordSecurity() == true)
                    {

                        worker.Password = txtNewPass.Text;
                        worker.PersonID = SessionClass.ID;

                        workerImpl.UpdatePassword(txtNewPass2.Text);

                        MessageBox.Show("Contraseña cambiada exitosamente");




                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe tener almenos 10 caracteres, una mayuscula, miniscula, numero y un caracter especial");
                    }

                }
                else
                {
                    MessageBox.Show("Las contraseñas deben ser iguales");
                }

            }
            else
            {
                MessageBox.Show("La contraseña actual es incorrecta");
            }


           

        }
    }
}
