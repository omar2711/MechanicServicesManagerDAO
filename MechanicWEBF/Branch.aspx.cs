using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using mechanicDAO.Implementation;
using mechanicDAO.Model;
using mechanicDAO.Validations;


namespace MechanicWEBF
{
    public partial class Branch : System.Web.UI.Page
    {
        public static double Latitude { get; set; }
        public static double Longitude { get; set; }

        [WebMethod]
        public static string GuardarCoordenadas(double latitude, double longitude)
        {
            

            Latitude = latitude;
            Longitude = longitude;


            // Redirigir a otra página
            string url = "OtraPagina.aspx";
            return url;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //id session role != admin redirect to default
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

            if (Request.QueryString["latitude"] != null && Request.QueryString["longitude"] != null)
            {
                string Latitude = Request.QueryString["latitude"];
                string Longitude = Request.QueryString["longitude"];
                txtLat.Text = Latitude;
                txtLon.Text = Longitude;

            }

            if (string.IsNullOrEmpty(txtLon.Text) && string.IsNullOrEmpty(txtLat.Text))
            {
                DeshabilitarControles();
            }



            if (!IsPostBack)
            {
                fillCountry();
                fillProvince();
            }
        }

        private void DeshabilitarControles()
        {
            txtBranchName.Enabled = false;
            comboCountry.Enabled = false;
            comboProvince.Enabled = false;
            createBTN.Enabled = false;
        }


        public void fillCountry()
        {
            try
            {
                branchImpl branchImpl = new branchImpl();
                comboCountry.DataSource = branchImpl.SelectComboCountry();
                comboCountry.DataTextField = "name";
                comboCountry.DataValueField = "id";
                comboCountry.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void fillProvince()
        {
            try
            {
                branchImpl branchImpl = new branchImpl();
                comboProvince.DataSource = branchImpl.SelectComboProvince(int.Parse(comboCountry.SelectedValue));
                comboProvince.DataTextField = "name";
                comboProvince.DataValueField = "id";
                comboProvince.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void comboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillProvince();
        }

        protected void createBTN_Click(object sender, EventArgs e)
        {
            branchImpl branchImpl = new branchImpl();
            branch branch = new branch();

            string nombre = validations.EraseSpaces(txtBranchName.Text);

            if(nombre != "")
            {
                branch.Name = nombre;
                branch.countryId = int.Parse(comboCountry.SelectedValue);
                branch.provinceId = int.Parse(comboProvince.SelectedValue);
                branch.Lat = txtLat.Text;
                branch.Lng = txtLon.Text;

                try
                {
                    branchImpl.Insert(branch);
                    Response.Redirect("BranchView.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                string error = "El nombre de la categoria no puede estar vacio";
                ViewState["Error"] = error;
            }

        }
    }
}