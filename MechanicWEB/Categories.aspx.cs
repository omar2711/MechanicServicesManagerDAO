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
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
            
        }

        public void Select()
        {
            try
            {
                productCategoryImpl productCategoryImpl = new productCategoryImpl();
                categoriesDTG.DataSource = productCategoryImpl.Select();
                categoriesDTG.DataBind();



                


            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }


        public void Insert()
        {
            try
            {
                if(txtCategory.Text != "")
                {
                    string name = txtCategory.Text;
                    validations.EraseSpaces(name);

                    if (validations.IsOnlyLettersNumbers(name))
                    {
                        productCategoryImpl productCategoryImpl = new productCategoryImpl();
                        productCategory productCategory = new productCategory();
                        productCategory.Name = name;
                        productCategoryImpl.Insert(productCategory);
                        Select();
                        string success = "Se Inserto";
                        ViewState["Success"] = success;

                    }
                    else
                    {
                        string error = "El nombre de la categoria solo debe tener letras";
                        ViewState["Error"] = error;



                    }
                }
                else
                {
                    string error = "Debe Insertar un nombre";
                    ViewState["Error"] = error;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void createBTN_Click(object sender, EventArgs e)
        {
            Insert();
        }

        protected void editBTN_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(categoriesDTG.SelectedRow.Cells[1].Text);
            string name = categoriesDTG.SelectedRow.Cells[2].Text;
            
            Response.Redirect("EditCategory.aspx?id=" + id + "&name=" + name);

        }

        protected void deleteBTN_Click(object sender, EventArgs e)
        {
            try
            {
               

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void categoriesDTG_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
    }
}