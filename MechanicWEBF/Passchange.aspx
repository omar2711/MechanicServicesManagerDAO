<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Passchange.aspx.cs" Inherits="MechanicWEB.Passchange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainContainer">
        <div class="row innerContainer">
            <div class="col-md-12 form-container">
        
        <h2>Change Password</h2>
        <div class="form-group">
            <label for="txtCurrentPassword">Contraseña Actual:</label>
            <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
            <% if (ViewState["CurrentError"] != null) { %>
                        <div id="alert" class="alert alert-danger">
                            <strong>La contraseña actual es incorrecta</strong>
                        </div>
                        <script>
                            setTimeout(function () {
                                $('.alert').fadeOut();
                            }, 2000);
                        </script>

                        

                    <% } %>

        <div class="form-group">
            <label for="txtNewPassword">Nueva Contraseña:</label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>

            <% if (ViewState["NewError"] != null) { %>
                        <div id="alert" class="alert alert-danger">
                            <strong>La nueva contraseña debe tener almenos un número, una mayúscula, un caracter especial y mínimo 10 caracteres</strong>
                        </div>
                        <script>
                            setTimeout(function () {
                                $('.alert').fadeOut();
                            }, 2000);
                        </script>

                        

                    <% } %>

        <div class="form-group">
            <label for="txtConfirmPassword">Confirmar Contraseña:</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
            <% if (ViewState["ConfirmError"] != null) { %>
                        <div id="alert" class="alert alert-danger">
                            <strong>Las contraseñas no coinciden</strong>
                        </div>
                        <script>
                            setTimeout(function () {
                                $('.alert').fadeOut();
                            }, 2000);
                        </script>

                        

                    <% } %>

        <asp:Button ID="btnChangePassword" runat="server" Text="Cambiar Contraseña" OnClick="btnChangePassword_Click" CssClass="btn btn-primary"/>
       
  </div>
            </div>
    </div>
    
</asp:Content>
