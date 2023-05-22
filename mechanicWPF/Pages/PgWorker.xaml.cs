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

namespace mechanicWPF.Pages
{
    /// <summary>
    /// Interaction logic for PgWorker.xaml
    /// </summary>
    public partial class PgWorker : Page
    {
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
            //generate a random username from the firstname, secondname and CI
            string username = txtName.Text.Substring(0, 4) + txtSecondName.Text.Substring(0, 4) + txtCi.Text.Substring(0, 4);
            //generate a random password with uppercase, lowercase, numbers and special characters of 10 characters
            string password = Guid.NewGuid().ToString().Substring(0, 10);



            try
            {
                workerImpl workerImpl = new workerImpl();
                worker worker = new worker();
                worker.Name = txtName.Text;
                worker.SecondName = txtSecondName.Text;
                worker.LastName = txtLastName.Text;
                worker.SecondLastName = txtSecondLastName.Text;
                worker.CI = txtCi.Text;
                worker.BranchID = int.Parse(txtBranchId.Text);
                worker.Mail = txtEmail.Text;
                worker.UserName = username;
                worker.Password = password;
                worker.ProfilePic = 1;
                worker.UserID = SessionClass.ID;
                worker.RoleID = int.Parse(cmbRole.SelectedValue.ToString());

                while(workerImpl.CompareUserName(username)==true)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(1000, 9999);

                    username = username + number;
                   
                }

                if(workerImpl.CompareUserName(username)==false)
                {
                    worker.UserName = username;
                    workerImpl.Insert(worker, password);

                }



                SendMail correo = new SendMail();
                correo.sendMail("El usuario se inserto con exito" + "\n" + "El nombre de usuario es: " + username + "\n" + "La contraseña de un solo uso es: " + password, txtEmail.Text, "Credenciales de Usuario");
                MessageBox.Show("Usuario creado con exito" + "\n" + "Se envio un correo con el usuario y contraseña");

                //Thread emailThread = new Thread(() =>
                //{
                //    SendMail correo = new SendMail();
                //    correo.sendMail("El usuario se inserto con exito" + "\n" + "El nombre de usuario es: " + username + "\n" + "La contraseña de un solo uso es: " + password, txtEmail.Text, "Credenciales de Usuario");
                //});

                //emailThread.Start();






            }
            catch (Exception)
            {

                throw;
            }

        }

        void Update()
        {
            DataRowView view = (DataRowView)dgtUsers.SelectedItem;

            if(view != null)
            {
                if(txtBranchId.Text == "" || txtCi.Text == "" || txtLastName.Text == "" || txtName.Text == "" || txtSecondLastName.Text == "" || txtSecondName.Text == "")
                {
                    MessageBox.Show("Please fill all the fields");
                }
                else
                {
                    try
                    {
                        int cmbValue = int.Parse(cmbRole.SelectedValue.ToString());
                        int id = int.Parse(view.Row[0].ToString());
                        worker worker = new worker(id, txtName.Text, txtSecondName.Text, txtLastName.Text, txtSecondLastName.Text, txtCi.Text, cmbValue, int.Parse(txtBranchId.Text), DateTime.Now, SessionClass.ID, txtEmail.Text.ToString());
                        //worker worker = new worker();
                        //worker.BranchID = int.Parse(txtBranchId.Text);
                        //worker.RoleID = cmbValue;

                        //person person = new person();
                        //person.ID = id;
                        //person.Name = txtName.Text;
                        //person.SecondName = txtSecondName.Text;
                        //person.LastName = txtLastName.Text;
                        //person.SecondLastName = txtSecondLastName.Text;
                        //person.CI = txtCi.Text;


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

                        throw;
                    }
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
                MessageBox.Show(ex.Message+"\n"+cmbRole.SelectedValue);
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
                txtBranchId.Text = view[7].ToString();
                cmbRole.SelectedItem = view[8].ToString();
            }

        }
    }
}
