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
using System.Data;
using mechanicDAO.Validations;


namespace mechanicWPF.Pages
{
    /// <summary>
    /// Interaction logic for PgServices.xaml
    /// </summary>
    public partial class PgServices : Page
    {
        public PgServices()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);

        }

        validations validations = new validations();

        //window loaded event
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Select();

            if(SessionClass.SessionRole == "7")
            {
                btnInsert.Visibility= Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                txtServiceDescription.Visibility= Visibility.Collapsed;
                txtServiceName.Visibility = Visibility.Collapsed;
                txtServicePrice.Visibility = Visibility.Collapsed;
                lblDesc.Visibility= Visibility.Collapsed;
                lblName.Visibility = Visibility.Collapsed;  
                lblPrice.Visibility = Visibility.Collapsed;
                

            }
            else
            {
                btnInsert.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
                txtServiceDescription.Visibility = Visibility.Visible;
                txtServiceName.Visibility = Visibility.Visible;
                txtServicePrice.Visibility = Visibility.Visible;
            }
        }

        #region crud
        void Select()
        {


            try
            {
                serviceImpl productCategoryImpl = new serviceImpl();
                dgvServices.ItemsSource = null;
                dgvServices.ItemsSource = productCategoryImpl.Select().DefaultView;
                dgvServices.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        } 



        void Update()
        {
            DataRowView view = (DataRowView)dgvServices.SelectedItem;
            if (view != null)
            {
                if (txtServiceDescription.Text == "" || txtServiceName.Text == "" || txtServicePrice.Text == "")
                {
                    MessageBox.Show("No se puede insertar un campo vacio");
                    return;

                }
                else
                {

                    if (validations.IsOnlyDecimalNumbers(txtServicePrice.Text) == true)
                    {
                        if (validations.IsOnlyPositiveNumbers(txtServicePrice.Text)==true)
                        {
                            if (validations.ContainsSpecialCharacters(txtServiceName.Text) == false)
                            {
                                try
                                {
                                    string serviceName = validations.EraseSpaces(txtServiceName.Text);
                                    int id = int.Parse(view.Row[0].ToString());
                                    service service = new service(serviceName, validations.EraseSpaces(txtServiceDescription.Text), double.Parse(validations.EraseSpaces(txtServicePrice.Text)), id);
                                    serviceImpl implCategory = new serviceImpl();

                                    int n = implCategory.Update(service);
                                    if (n > 0)
                                    {
                                        MessageBox.Show("Resgistro actualizado con exito - " + DateTime.Now);
                                        Select();
                                    }
                                    else MessageBox.Show("No se pudo actualizar el registro");

                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show(ex.Message);
                                }

                            }
                            else MessageBox.Show("El nombre del servicio solo puede contener letras y numeros");

                        }
                        else MessageBox.Show("El precio debe ser un numero positivo");

                    }
                    else MessageBox.Show("El precio debe ser un numero positivo");


                }
            }
               

        }
        void Delete()
        {
            DataRowView view = (DataRowView)dgvServices.SelectedItem;
            if (view != null)
            {
                if (MessageBox.Show("Desea eliminar el registro", "Advertencia", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = int.Parse(view.Row[0].ToString());
                        service service = new service(id);
                        serviceImpl implCategory = new serviceImpl();

                        int n = implCategory.Delete(service);
                        if (n > 0)
                        {
                            MessageBox.Show("Resgistro eliminado con exito - " + DateTime.Now);
                            Select();
                        }
                        else MessageBox.Show("No se pudo eliminar el registro");

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else MessageBox.Show("No se borro el servicio");
            }                   
            else MessageBox.Show("Seleccione un registro");
        }
        #endregion
        

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if(txtServiceDescription.Text == "" || txtServiceName.Text == "" || txtServicePrice.Text == "" )
            {
                MessageBox.Show("No se puede insertar un campo vacio");
                return;

            }
            else
            {

                if (validations.IsOnlyDecimalNumbers(txtServicePrice.Text) == true)
                {
                    if (validations.IsOnlyPositiveNumbers(txtServicePrice.Text)==true)
                    {
                        if (validations.ContainsSpecialCharacters(txtServiceName.Text) == false)
                        {
                            service service = new service(validations.EraseSpaces(txtServiceName.Text), validations.EraseSpaces(txtServiceDescription.Text), double.Parse(validations.EraseSpaces(txtServicePrice.Text)));
                            serviceImpl implCategory = new serviceImpl();
                            try
                            {
                                int n = implCategory.Insert(service);
                                if (n > 0)
                                {
                                    MessageBox.Show("Resgistro insertado con exito - " + DateTime.Now);
                                    Select();
                                }
                                else MessageBox.Show("No se pudo insertar el registro");
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else MessageBox.Show("El nombre del servicio solo puede contener letras y numeros");
                       
                    }
                    else MessageBox.Show("El precio debe ser un numero positivo");
                    
                }
                else MessageBox.Show("El precio debe ser un numero positivo");


            }
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Select();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Select();
        }

        private void dgvServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = (DataRowView)dgvServices.SelectedItem;
            if (view != null)
            {
                string name = (view.Row.ItemArray[1].ToString());
                string detail = (view.Row.ItemArray[2].ToString());
                string price = (view.Row.ItemArray[3].ToString());

                txtServiceDescription.Text = detail;
                txtServicePrice.Text = price;
                txtServiceName.Text = name;
                
            }
        }

    }
}
