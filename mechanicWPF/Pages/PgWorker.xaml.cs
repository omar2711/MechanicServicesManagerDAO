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
using mechanicDAO.Model;
using mechanicDAO.Implementation;
using mechanicDAO.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media.TextFormatting;
using mechanicWPF.Classes;
using System.Threading;
using mechanicDAO.Validations;

namespace mechanicWPF.Pages
{
    /// <summary>
    /// Interaction logic for PgWorker.xaml
    /// </summary>
    public partial class PgWorker : Page
    {

        public int roleId = 0;
        public PgWorker()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        //window loaded
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillCombo();
            Select();
        }

        

        void fillCombo()
        {
            try
            {
                roleImpl roleImpl = new roleImpl();
                cmbRole.ItemsSource = roleImpl.SelectComboRole().DefaultView;
                cmbRole.DisplayMemberPath = "name";
                cmbRole.SelectedValuePath = "id";
            }
            catch (Exception)
            {

                throw;
            }

        }

        void Insert()
        {

            if (txtBranchId.Text == "" || txtCi.Text == "" || txtLastName.Text == "" || txtName.Text == "" || txtSecondName.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos de texto");
            }
            else
            {
                string name = validations.EraseSpaces(txtName.Text);

                if (validations.IsOnlyLetters(name) == true)
                {
                    if (validations.IsOnlyLetters(txtSecondName.Text) == true)
                    {
                        if (validations.IsOnlyLetters(txtLastName.Text) == true)
                        {
                            if(validations.IsOnlyLetters(txtSecondLastName.Text)==true || txtSecondLastName.Text == "")
                            {
                                if (validations.isOnlyPositiveNumbers(txtBranchId.Text) == true)
                                {
                                    if (roleId != 0)
                                    {
                                        bool isValid = validations.IsValidEmail(txtEmail.Text);
                                        if (isValid)
                                        {
                                            try
                                            {
                                                string username;

                                                username = txtName.Text.Substring(0, 2) + txtSecondName.Text.Substring(0, 2) + txtCi.Text.Substring(0, 4);


                                                string password = Guid.NewGuid().ToString().Substring(0, 10);

                                                string branch = validations.EraseSpaces(txtBranchId.Text);

                                                workerImpl workerImpl = new workerImpl();
                                                worker worker = new worker();
                                                worker.Name = validations.EraseSpaces(txtName.Text);
                                                worker.SecondName = validations.EraseSpaces(txtSecondName.Text);
                                                worker.LastName = validations.EraseSpaces(txtLastName.Text);
                                                worker.SecondLastName = validations.EraseSpaces(txtSecondLastName.Text);
                                                worker.CI = validations.EraseSpaces(txtCi.Text);
                                                worker.BranchID = int.Parse(branch);
                                                worker.Mail = validations.EraseSpaces(txtEmail.Text);
                                                worker.UserName = username;
                                                worker.Password = password;
                                                worker.ProfilePic = 1;
                                                worker.UserID = SessionClass.ID;
                                                worker.RoleID = int.Parse(cmbRole.SelectedValue.ToString());

                                                while (workerImpl.CompareUserName(username) == true)
                                                {
                                                    Random rnd = new Random();
                                                    int number = rnd.Next(1000, 9999);

                                                    username = username + number;

                                                }

                                                if (workerImpl.CompareUserName(username) == false)
                                                {
                                                    worker.UserName = username;
                                                    workerImpl.Insert(worker, password);

                                                }

                                                workerImpl.sendMail("El usuario se inserto con exito" + "\n" + "El nombre de usuario es: " + username + "\n" + "La contraseña de un solo uso es: " + password, txtEmail.Text, "Credenciales de Usuario");
                                                MessageBox.Show("Usuario creado con exito" + "\n" + "Se envio un correo con el usuario y contraseña");
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }

                                        }
                                        else MessageBox.Show("Debe tener");

                                    }
                                    else MessageBox.Show("Debe seleccionar un rol");
                                }
                                else MessageBox.Show("El ID de sucursal solo puede ser numeros positivos");

                            }
                            else MessageBox.Show("El segundo apellido solo puede contener letras o en caso de no tener debe estar en blanco");
                        }
                        else MessageBox.Show("El apellido solo puede contener letras");
                    }
                    else MessageBox.Show("El segundo nombre solo puede contener letras"); 
                }
                else MessageBox.Show("El nombre solo puede contener letras");
                
            }

        }

        void Update()
        {
            DataRowView view = (DataRowView)dgtUsers.SelectedItem;
            string branch = validations.EraseSpaces(txtBranchId.Text);


            if (view != null)
            {
                if (txtBranchId.Text == "" || txtCi.Text == "" || txtLastName.Text == "" || txtName.Text == "" || txtSecondLastName.Text == "" || txtSecondName.Text == "" || txtEmail.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los campos de texto");
                }
                else
                {

                    string name = validations.EraseSpaces(txtName.Text);

                    if (validations.IsOnlyLetters(name) == true)
                    {
                        if (validations.IsOnlyLetters(txtSecondName.Text) == true)
                        {
                            if (validations.IsOnlyLetters(txtLastName.Text) == true)
                            {
                                if (validations.IsOnlyLetters(txtSecondLastName.Text) == true || txtSecondLastName.Text == "")
                                {
                                    if (validations.isOnlyPositiveNumbers(txtBranchId.Text) == true)
                                    {
                                        if (roleId != 0)
                                        {
                                            bool isValid = validations.IsValidEmail(txtEmail.Text);
                                            if (isValid)
                                            {
                                                try
                                                {
                                                    int cmbValue = int.Parse(cmbRole.SelectedValue.ToString());
                                                    int id = int.Parse(view.Row[0].ToString());
                                                    worker worker = new worker(id, validations.EraseSpaces(txtName.Text), validations.EraseSpaces(txtSecondName.Text), validations.EraseSpaces(txtLastName.Text), validations.EraseSpaces(txtSecondLastName.Text), validations.EraseSpaces(txtCi.Text), cmbValue, int.Parse(branch), DateTime.Now, SessionClass.ID, validations.EraseSpaces(txtEmail.Text.ToString()));

                                                    workerImpl workerImpl = new workerImpl();

                                                    try
                                                    {
                                                        workerImpl.Update(worker);
                                                        MessageBox.Show("Cliente Actualizado");


                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show(ex.Message);
                                                        throw ex;
                                                    }

                                                }
                                                catch (Exception)
                                                {

                                                    MessageBox.Show("Error al actualizar el cliente");
                                                }

                                            }
                                            else MessageBox.Show("Debe tener");

                                        }
                                        else MessageBox.Show("Debe seleccionar un rol");
                                    }
                                    else MessageBox.Show("El ID de sucursal solo puede ser numeros positivos");

                                }
                                else MessageBox.Show("El segundo apellido solo puede contener letras o en caso de no tener debe estar en blanco");
                            }
                            else MessageBox.Show("El apellido solo puede contener letras");
                        }
                        else MessageBox.Show("El segundo nombre solo puede contener letras");
                    }
                    else MessageBox.Show("El nombre solo puede contener letras");


                }

            }



            



        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Insert();
                Select();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear al empleado");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Select();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView view = (DataRowView)dgtUsers.SelectedItem;
            if (view != null)
            {
                if(MessageBox.Show("Desea Eliminar el registro seleccionado?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = int.Parse(view.Row[0].ToString());
                        worker worker = new worker(id);
                        workerImpl workerImpl = new workerImpl();
                        workerImpl.Delete(worker);
                        MessageBox.Show("Registro eliminado correctamente");
                        Select();
                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    Select();
                }
            }


        }

        void Select()
        {
            try
            {
                workerImpl workerImpl = new workerImpl();
                dgtUsers.ItemsSource = null;
                dgtUsers.ItemsSource = workerImpl.Select().DefaultView;
                dgtUsers.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgtUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = (DataRowView)dgtUsers.SelectedItem;
            if (view != null)
            {

                txtName.Text = view[1].ToString();
                txtSecondName.Text = view[2].ToString();
                txtLastName.Text = view[3].ToString();
                txtSecondLastName.Text = view[4].ToString();
                txtCi.Text = view[5].ToString();
                txtBranchId.Text = view[8].ToString();
                txtEmail.Text = view[7].ToString();
            }

        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roleId = int.Parse(cmbRole.SelectedValue.ToString());
        }
    }
}
