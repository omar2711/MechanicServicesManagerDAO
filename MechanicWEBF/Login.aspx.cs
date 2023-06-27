using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mechanicDAO.Implementation;
using mechanicDAO.Model;
using mechanicDAO.Validations;

namespace MechanicWEB
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if(password.Text!=""&& username.Text != "")
            {

                ClientImpl clientImpl = new ClientImpl();
                client client = new client();
                client.Username= username.Text;


                try
                {

                    if (clientImpl.Login(client, password.Text).Rows.Count > 0)
                    {

                        Session["id"] = clientImpl.Login(client, password.Text ).Rows[0]["personId"].ToString();

                        categoriesDTG.DataSource = clientImpl.Login(client, password.Text);

                        Session["role"] = clientImpl.Login(client, password.Text).Rows[0]["role"].ToString();
                        Session["password"] = password.Text;
                        Response.Redirect("Default.aspx");

                    }
                    else
                    {
                        string error = "1";
                        ViewState["Error"] = error;
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }
    }
}