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

                try
                {
                    if(clientImpl.Login(username.Text, password.Text).Rows.Count > 0)
                    {
                        Session["userName"] = client.Username;
                        Session["id"] = client.ID;
                        Session["rol"] = client.Role;
                        Response.Redirect("Default.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Usuario o contraseña incorrectos')</script>");
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