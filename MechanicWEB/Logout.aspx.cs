using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MechanicWEB
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //empty the session id, username and role

            
                Session["userName"] = null;
                Session["id"] = null;
                Session["rol"] = null;
                Response.Redirect("Default.aspx");
            

        }
    }
}