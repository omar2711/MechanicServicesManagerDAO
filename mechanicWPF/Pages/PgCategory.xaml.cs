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
    /// Interaction logic for PgCategory.xaml
    /// </summary>
    public partial class PgCategory : Page
    {
        public PgCategory()
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
                productCategoryImpl productCategoryImpl = new productCategoryImpl();
                dgvCategories.ItemsSource = null;
                dgvCategories.ItemsSource = productCategoryImpl.Select().DefaultView;
                dgvCategories.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        void Update()
        {
            DataRowView view = (DataRowView)dgvCategories.SelectedItem;
            if (view != null)
            {
                if(txtCategory.Text == "")
                {
                    MessageBox.Show("No se puede modificar un campo vacio");
                    return;
                }
                else
                {
                    if (validations.IsOnlyLettersAndNumbers(txtCategory.Text))
                    {
                        try
                        {

                            int id = int.Parse(view.Row.ItemArray[0].ToString());
                            productCategory productCategory = new productCategory(validations.EraseSpaces(txtCategory.Text), id);
                            productCategoryImpl productCategoryImpl = new productCategoryImpl();

                            productCategoryImpl.Update(productCategory);
                            MessageBox.Show("Resgistro modificado con exito - " + DateTime.Now);


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo insertar el registro - " + DateTime.Now + "\n" + ex.Message);


                        }
                    } else MessageBox.Show("No se puede insertar caracteres especiales en el nombre del servicio");
                   
                }


            }
            else
            {
                MessageBox.Show("Seleccione un registro para modificar");
            }

        }
        void Delete()
        {
            DataRowView view = (DataRowView)dgvCategories.SelectedItem;
            if (view != null)
            {
                if(MessageBox.Show("Desea eliminar el registro", "Advertencia", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    try
                    {
                        int id = int.Parse(view.Row.ItemArray[0].ToString());
                        productCategory productCategory = new productCategory(id);
                        productCategoryImpl productCategoryImpl = new productCategoryImpl();

                        productCategoryImpl.Delete(productCategory);
                        MessageBox.Show("Registro eliminado correctamente - " + DateTime.Now);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("No se pudo eliminar el registro - " + DateTime.Now + "\n" + ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminarlo");
            }
        }
        #endregion


        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if(txtCategory.Text == "")
            {
                MessageBox.Show("No se puede insertar un campo vacio");
                return;
            }
            else
            {
                if (validations.IsOnlyLettersAndNumbers(txtCategory.Text))
                {
                    productCategory category = new productCategory(validations.EraseSpaces(txtCategory.Text));
                    productCategoryImpl implCategory = new productCategoryImpl();
                    try
                    {
                        int n = implCategory.Insert(category);
                        if (n > 0)
                        {
                            MessageBox.Show("Resgistro insertado con exito - " + DateTime.Now);
                            Select();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo insertar el registro - " + DateTime.Now);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    txtCategory.Clear();
                }else MessageBox.Show("No se puede insertar caracteres especiales en el nombre del servicio");

            }

        }

        

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Select();

        }

       

        private void dgvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = (DataRowView)dgvCategories.SelectedItem;
            if (view != null)
            {
                string changed = (view.Row.ItemArray[1].ToString());
                txtCategory.Text = changed;
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Select();

        }

        
    }
}
