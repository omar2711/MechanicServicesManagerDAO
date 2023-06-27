using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mechanicDAO.Implementation;
using mechanicDAO.Model;
using mechanicDAO.Validations;

namespace MechanicWEB
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
            fillDropDown();
            fillBrand();
        }
        
        public void Select()
        {
            try
            {
                productImpl productImpl = new productImpl();
                productsDTG.DataSource = productImpl.Select();
                productsDTG.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillDropDown()
        {
            try
            {
                productCategoryImpl productCategoryImpl = new productCategoryImpl();
                cmbCategory.DataSource = productCategoryImpl.SelectComboCat();
                cmbCategory.DataTextField = "name";
                cmbCategory.DataValueField = "id";
                cmbCategory.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillBrand()
        {
            try
            {
                productBrandImpl productBrandImpl = new productBrandImpl();
                cmbBrand.DataSource = productBrandImpl.SelectComboBrand();
                cmbBrand.DataTextField = "name";
                cmbBrand.DataValueField = "id";
                cmbBrand.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void createBTN_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if(txtPrice.Text != "")
                {
                    if (txtPrice.Text != "")
                    {
                        string name = validations.EraseSpaces(txtName.Text);
                        if (validations.IsOnlyLettersNumbers(name))
                        {
                            if (validations.isOnlyPositiveNumbers(txtPrice.Text) && double.Parse(txtPrice.Text) > 0)
                            {
                                if (validations.isOnlyPositiveNumbers(txtStock.Text) && int.Parse(txtStock.Text) > 0)
                                {
                                    try
                                    {
                                        productImpl productImpl = new productImpl();
                                        product product = new product();
                                        product.Name = name;
                                        product.Price = double.Parse(txtPrice.Text);
                                        product.Stock = int.Parse(txtStock.Text);
                                        product.ProductBrandID = int.Parse(cmbBrand.SelectedValue);
                                        product.ProductCategoryID = int.Parse(cmbCategory.SelectedValue);
                                        productImpl.Insert(product);
                                        Select();
                                        txtName.Text = "";
                                        txtPrice.Text = "";
                                        txtStock.Text = "";
                                        cmbBrand.SelectedIndex = 0;
                                        cmbCategory.SelectedIndex = 0;

                                        string success = "Se Inserto";
                                        ViewState["Success"] = success;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }
                                else
                                {
                                    String error = "El stock debe ser un numero positivo";
                                    ViewState["Error"] = error;
                                }
                            }
                            else
                            {
                                String error = "El precio debe ser un numero positivo";
                                ViewState["Error"] = error;
                            }
                        }
                        else
                        {
                            String error = "El nombre solo debe contener letras y numeros";
                            ViewState["Error"] = error;
                        }

                    }
                    else
                    {
                        String error = "Debe llenar todos los campos";
                        ViewState["Error"] = error;
                    }

                }
                else
                {
                    String error = "Debe llenar todos los campos";
                    ViewState["Error"] = error;
                }
            }
            else
            {
                String error = "Debe llenar todos los campos";
                ViewState["Error"] = error;
            }

        }

        protected void productsDTG_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible= false;
        }

       
    }
}