using mechanicDAO.Implementation;
using mechanicDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MechanicWEB
{
    public partial class Passchange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("Default.aspx");
            }

        }

        bool verifyPasswordSecurity()
        {
            string password = txtNewPassword.Text;
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasSpecialCharacter = false;
            bool hasNumber = false;
            bool hasLength = false;

            if (password.Length >= 10)
            {
                hasLength = true;
            }

            //loop to verify if the password has an uppercase, lowercase, special character and number
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (char.IsNumber(c))
                {
                    hasNumber = true;
                }
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    hasSpecialCharacter = true;
                }
            }

            //if the password has all the requirements, return true
            if (hasUpperCase == true && hasLowerCase == true && hasSpecialCharacter == true && hasNumber == true && hasLength == true)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            ClientImpl clientImpl = new ClientImpl();
            client client = new client();

           

            if (txtCurrentPassword.Text == Session["password"].ToString())
            {
                ViewState["CurrentError"] = null;
                if (verifyPasswordSecurity() == true)
                {
                    ViewState["NewError"] = null;
                    if(txtNewPassword.Text == txtConfirmPassword.Text)
                    {
                        ViewState["ConfirmError"] = null;

                        client.Password = txtNewPassword.Text;
                        client.ID = int.Parse(Session["id"].ToString());

                        clientImpl.ChangePass(client, txtNewPassword.Text);
                        Session["password"] = txtNewPassword.Text;
                        Response.Redirect("Default.aspx");


                    }
                    else
                    {
                        ViewState["ConfirmError"] = "Passwords do not match";
                    }
                }
                else
                {
                    ViewState["NewError"] = "Password does not meet the requirements";
                }
            }
            else
            {
                ViewState["CurrentError"] = "Current password is incorrect";
            }


        }
    }
}