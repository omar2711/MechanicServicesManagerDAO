<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="MechanicWEB.EditCategory" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
                    <h2>Modificar una Categoria</h2>
                    <asp:Label runat="server" ID="lblID" Text="ID" Visible="false" />
                    <asp:TextBox runat="server" ID="txtCategory" CssClass="form-control" placeholder="Nombre de la Categoria" />
                    <% if (ViewState["Error"] != null) { %>
                        <div id="alerta" class="alert alert-danger">
                            <strong>Error!</strong> <%= ViewState["Error"] %>
                        </div>
                        <script>
                            setTimeout(function () {
                                $('.alerta').fadeOut();
                            }, 2000);
                        </script>
 


                    <% } %>

                     <% if (ViewState["Success"] != null) { %>
                        <div id="alert" class="alert alert-success">
                            <strong>La categoria se inserto correctamente</strong>
                        </div>
                        <script>
                            setTimeout(function () {
                                $('.alert').fadeOut();
                            }, 2000);
                        </script>

                        

                    <% } %>

                    <br />
                    <asp:Button runat="server" ID="editBTN" CssClass="btn btn-success" Text="Crear" OnClick="editBTN_Click" />


                </div>
</asp:Content>
