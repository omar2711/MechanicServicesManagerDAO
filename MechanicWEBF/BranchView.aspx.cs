using mechanicDAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mechanicDAO.Model;
using mechanicDAO.Validations;

namespace MechanicWEBF
{
    public partial class BranchView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "Admin")
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
            branchImpl branchImpl = new branchImpl();
            branchDTG.DataSource = branchImpl.Select();
            branchDTG.DataBind();


        }

        protected void categoriesDTG_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void deleteBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string id;
                Button button = (Button)sender;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                id = row.Cells[1].Text;

                branchImpl branchImpl = new branchImpl();
                branch branch = new branch();
                branch.ID = Convert.ToInt32(id);
                branchImpl.Delete(branch);
                Select();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void branchDTG_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Obtener el valor del ID del registro correspondiente
                string id = branchDTG.DataKeys[rowIndex].Value.ToString();

                try
                {
                    Button button = (Button)sender;
                    GridViewRow row = (GridViewRow)button.NamingContainer;
                    id = row.Cells[1].Text;

                    branchImpl branchImpl = new branchImpl();
                    branch branch = new branch();
                    branch.ID = Convert.ToInt32(id);
                    branchImpl.Delete(branch);
                    Select();
                }
                catch (Exception)
                {

                    throw;
                }
            }

          
        }
    }
}