<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Passchange.aspx.cs" Inherits="MechanicWEB.Passchange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <formview>
        <form id="formChangePassword" runat="server" class="container">
        <h2>Change Password</h2>
        <div class="form-group">
            <label for="txtCurrentPassword">Contraseña Actual:</label>
            <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtNewPassword">Nueva Contraseña:</label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtConfirmPassword">Confirmar Contraseña:</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Button ID="btnChangePassword" runat="server" Text="Cambiar Contraseña" OnClick="btnChangePassword_Click" CssClass="btn btn-primary"/>
        </form>
    </formview>
    
</asp:Content>
