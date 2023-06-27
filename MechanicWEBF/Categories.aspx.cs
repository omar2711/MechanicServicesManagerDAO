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
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() == "Cliente")
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

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
                        string error = "El nombre de la categoría solo debe tener letras";
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

      

        protected void categoriesDTG_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void categoriesDTG_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Obtener el valor del ID del registro correspondiente
                string id = categoriesDTG.DataKeys[rowIndex].Value.ToString();

                try
                {
                    productCategoryImpl productCategoryImpl = new productCategoryImpl();
                    productCategory productCategory = new productCategory();
                    productCategory.ID = int.Parse(id);
                    productCategoryImpl.Delete(productCategory);
                    
                    



                    Select();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        protected void deleteBTN_Click(object sender, EventArgs e)
        {
            string id;

            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            id = row.Cells[1].Text;

            try
            {
                productCategoryImpl productCategoryImpl = new productCategoryImpl();
                productCategory productCategory = new productCategory();
                productCategory.ID = int.Parse(id);
                productCategoryImpl.Delete(productCategory);
                Select();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}