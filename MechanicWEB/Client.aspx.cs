using mechanicDAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MechanicWEB
{
    public partial class Client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        protected void productsDTG_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[1].Visible = false;

        }

        public void Select()
        {
            ClientImpl clientImpl = new ClientImpl();
            clientsDTG.DataSource = clientImpl.Select();
            clientsDTG.DataBind();
        }
    }
}