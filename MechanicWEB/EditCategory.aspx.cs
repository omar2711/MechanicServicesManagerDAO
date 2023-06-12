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
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string name = Request.QueryString["name"];

            txtCategory.Text = name;
            lblID.Text = id.ToString();

        }

        protected void editBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategory.Text != "")
                {
                    if (validations.IsOnlyLetters(txtCategory.Text))
                    {
                        string name = txtCategory.Text;
                        productCategoryImpl productCategoryImpl = new productCategoryImpl();
                        productCategory productCategory = new productCategory();
                        productCategory.Name = validations.EraseSpaces(name);
                        productCategory.ID = Convert.ToInt32(lblID.Text);
                        productCategoryImpl.Update(productCategory);
                        Response.Redirect("Categories.aspx");
                    }
                    else
                    {
                        string error = "The name field must contain only letters";
                        ViewState["error"] = error;
                    }
                }
                else
                {
                    string error = "The name field cannot be empty";
                    ViewState["error"] = error;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}