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

        //window loaded event
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
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
                    try
                    {
                        int id = int.Parse(view.Row[0].ToString());
                        service service = new service(txtServiceName.Text, txtServiceDescription.Text, double.Parse(txtServicePrice.Text), id);
                        serviceImpl implCategory = new serviceImpl();

                        int n = implCategory.Update(service);
                        if (n > 0)
                        {
                            MessageBox.Show("Resgistro actualizado con exito - " + DateTime.Now);
                            Select();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el registro");
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
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
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro");
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No se borro el servicio");
                }
            }                   
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
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
                //make an if txtServicePrice is not a number
                service service = new service(txtServiceName.Text, txtServiceDescription.Text, double.Parse(txtServicePrice.Text));
                serviceImpl implCategory = new serviceImpl();
                try
                {
                    int n = implCategory.Insert(service);
                    if (n > 0)
                    {
                        MessageBox.Show("Resgistro insertado con exito - " + DateTime.Now);
                        Select();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar el registro");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


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

        #region data validation
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        public static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }
        #endregion
    }
}
