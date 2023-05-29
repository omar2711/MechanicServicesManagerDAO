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
using mechanicDAO.Interfaces;
using mechanicDAO.Implementation;
using mechanicDAO.Validations;
using System.Data;
using System.Text.RegularExpressions;

namespace mechanicWPF.Pages
{
    /// <summary>
    /// Interaction logic for PgProduct.xaml
    /// </summary>
    public partial class PgProduct : Page
    {
        public PgProduct()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Page_Loaded);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
            fillComboCategory();
            fillComboBrand();

            if (SessionClass.SessionRole == "7")
            {
                btnInsert.Visibility = Visibility.Collapsed;
                btnUpdate.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                txtName.Visibility = Visibility.Collapsed;
                txtPrice.Visibility = Visibility.Collapsed;
                txtStock.Visibility = Visibility.Collapsed;
                lblName.Visibility = Visibility.Collapsed;
                lblPrice.Visibility = Visibility.Collapsed;
                lblStock.Visibility = Visibility.Collapsed;
                lblBrand.Visibility = Visibility.Collapsed;
                lblCat.Visibility = Visibility.Collapsed;
                cmbBrand.Visibility = Visibility.Collapsed;
                cmbCategory.Visibility = Visibility.Collapsed;
            }

            
            
        }



        void fillComboCategory()
        {
            try
            {
                productCategoryImpl productCategoryImpl = new productCategoryImpl();
                cmbCategory.ItemsSource = productCategoryImpl.SelectComboCat().DefaultView;
                cmbCategory.DisplayMemberPath = "name";
                cmbCategory.SelectedValuePath = "id";
            }
            catch (Exception)
            {
                throw;
            }
        }

        void fillComboBrand()
        {
            try
            {
                productBrandImpl productBrandImpl = new productBrandImpl();
                cmbBrand.ItemsSource = productBrandImpl.SelectComboBrand().DefaultView;
                cmbBrand.DisplayMemberPath = "name";
                cmbBrand.SelectedValuePath = "id";
            }
            catch (Exception)
            {
                throw;
            }
        }






        public void Select()
        {
            productImpl productImpl = new productImpl();
            dtgProducts.ItemsSource = productImpl.Select().DefaultView;
            dtgProducts.Columns[0].Visibility = Visibility.Collapsed;


        }

        private void dtgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = (DataRowView)dtgProducts.SelectedItem;
            if (view != null)
            {

                txtName.Text = (view.Row.ItemArray[1].ToString());
                txtPrice.Text = (view.Row.ItemArray[2].ToString());
                txtStock.Text = (view.Row.ItemArray[3].ToString());
                cmbBrand.Text = view.Row.ItemArray[5].ToString();
                cmbCategory.Text = view.Row.ItemArray[4].ToString();
            }


           

        }

        int brandId = 0;
        int catId = 0;


        private void cmbBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brandId = int.Parse(cmbBrand.SelectedValue.ToString());
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            catId = int.Parse(cmbCategory.SelectedValue.ToString());
        }








        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

            
            if (txtName.Text != "")
            {
                if (txtPrice.Text != "")
                {
                    if (txtStock.Text != "")
                    {
                        if (validations.IsOnlyDecimalNumbers(txtPrice.Text) && double.Parse(txtPrice.Text) > 0)
                        {
                            if (validations.IsOnlyPositiveNumbers(txtPrice.Text))
                            {
                                if (validations.isOnlyNumber(txtStock.Text))
                                {
                                    if(catId == 0 || brandId == 0)
                                    {
                                        try
                                        {
                                            string newName = validations.EraseSpaces(txtName.Text);

                                            double price = double.Parse(txtPrice.Text);
                                            productImpl productImpl = new productImpl();
                                            product product = new product();
                                            product.Name = newName;
                                            product.Price = Double.Parse(txtPrice.Text);
                                            product.Stock = Int32.Parse(txtStock.Text);
                                            product.ProductCategoryID = Int32.Parse(cmbCategory.SelectedValue.ToString());
                                            product.ProductBrandID = Int32.Parse(cmbBrand.SelectedValue.ToString());
                                            productImpl.Insert(product);
                                            Select();


                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("El stock debe ser un numero entero");
                                        }
                                    }
                                    else MessageBox.Show("Debe seleccionar una categoria y una marca");

                                }
                                else MessageBox.Show("El Stock debe contener solo numeros");

                            }
                            else MessageBox.Show("El precio debe tener un valor positivo");

                        }
                        else MessageBox.Show("El precio debe contener solo numeros");

                    }
                    else MessageBox.Show("El Stock no puede estar vacio");

                }
                else MessageBox.Show("El Precio no puede estar vacio");

            }
            else MessageBox.Show("El Nombre no puede estar vacio");
        }

        void Update()
        {
            DataRowView view = (DataRowView)dtgProducts.SelectedItem;

            if (txtName.Text != "")
            {
                if (txtPrice.Text != "")
                {
                    if (txtStock.Text != "")
                    {
                        if (validations.ContainsSpecialCharacters(txtName.Text) == false)
                        {
                            if(catId != 0 || brandId != 0)
                            {
                                if (validations.IsOnlyDecimalNumbers(txtPrice.Text) && double.Parse(txtPrice.Text) > 0)
                                {
                                    if (validations.IsOnlyPositiveNumbers(txtPrice.Text))
                                    {
                                        if (validations.isOnlyNumber(txtStock.Text))
                                        {
                                            
                                            try
                                            {
                                                string updateName = validations.EraseSpaces(txtName.Text);

                                                productImpl productImpl = new productImpl();
                                                int id = int.Parse(view.Row[0].ToString());
                                                product product = new product(id, updateName, double.Parse(txtPrice.Text), int.Parse(cmbBrand.SelectedValue.ToString()), int.Parse(cmbCategory.SelectedValue.ToString()), int.Parse(txtStock.Text));

                                                productImpl.Update(product);
                                                MessageBox.Show("Producto actualizado con exito " + DateTime.Now);
                                                Select();
                                            }
                                            catch (Exception)
                                            {

                                                MessageBox.Show("El stock debe ser un numero entero");
                                            }
                                        }
                                        else MessageBox.Show("El Stock debe contener solo numeros");
                                    }
                                    else MessageBox.Show("El precio debe tener un valor positivo");

                                }
                                else MessageBox.Show("El precio debe estar en numeros");
                            }
                            else  MessageBox.Show("La categoria o la marca no puede estar vacia");

                        }
                        else MessageBox.Show("El nombre no puede contener caracteres especiales");

                    }
                    else MessageBox.Show("El Stock no puede estar vacio");

                }
                else MessageBox.Show("El Precio no puede estar vacio");

            }
            else MessageBox.Show("El Nombre no puede estar vacio");


            

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();

        }

        public void Delete()
        {
            DataRowView view = (DataRowView)dtgProducts.SelectedItem;
            if (view != null)
            {
                if (MessageBox.Show("Desea eliminar el registro", "Advertencia", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = int.Parse(view.Row[0].ToString());
                        product product = new product(id);
                        productImpl implProduct= new productImpl();

                        int n = implProduct.Delete(product);
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



        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        
    }
}
