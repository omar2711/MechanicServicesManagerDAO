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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            if (txtCI.Text != "" && txtEmail.Text != "" && txtFullName.Text != "" && txtLastName.Text != "")
            {
                string name = validations.EraseSpaces(txtFullName.Text);
                string lastName = validations.EraseSpaces(txtLastName.Text);
                string secondLastName = validations.EraseSpaces(txtSecondLastName.Text);
                string email = validations.EraseSpaces(txtEmail.Text);
                string ci = validations.EraseSpaces(txtCI.Text);

                if (validations.IsOnlyLetters(name) == true)
                {
                    if (validations.IsOnlyLetters(lastName) == true)
                    {
                        if (validations.IsOnlyLetters(secondLastName) == true || txtSecondLastName.Text == "")
                        {
                            if (validations.IsValidEmail(email) == true)
                            {
                                string username = name.Substring(0, 1) + lastName.Substring(0, 2) + ci + email.Substring(0, 2);

                                ClientImpl clientImpl = new ClientImpl();
                                client Client = new client();
                                Client.Name = name;
                                Client.LastName = lastName;
                                Client.SecondLastName = secondLastName;
                                Client.CI = ci;
                                Client.Email= email;

                                string password = Guid.NewGuid().ToString().Substring(0, 10);
                                try
                                {
                                    clientImpl.InsertQ(Client, password, username);
                                    Response.Write("<script>alert('Usuario registrado con exito')</script>");
                                    clientImpl.sendMail("Bienvenido a Mecanica Isaacar" + "\n" + "El nombre de usuario es: " + username + "\n" + "La contraseña de un solo uso es: " + password, txtEmail.Text, "Credenciales de Usuario");


                                }
                                catch (Exception ex)
                                {
                                    //show the exception message
                                    Response.Write(ex.Message);

                                }

                            }
                            else
                            {
                                Response.Write("<script>alert('El email no es valido')</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('El segundo apellido solo puede contener letras')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('El primer apellido solo puede contener letras')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('El nombre solo puede contener letras')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Todos los campos a excepcion del apellido materno son obligatorios')</script>");
            }


        }




    }
    
}