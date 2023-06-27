<%@ Page Title="Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="MechanicWEB.Categories" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainContainer" style="margin-top:120px; margin-bottom:70px; margin-left:200px; margin-right:200px">
        <div class="row innerContainer">
            <div class="col-md-12 form-container">
                <h1>Categorías</h1>
               
            
                <div class="form-group">
                    <h2>Insertar una Categoría</h2>
                    <asp:TextBox runat="server" ID="txtCategory" CssClass="form-control" placeholder="Nombre de la Categoría" />
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
                            <strong>La categoría se inserto correctamente</strong>
                        </div>
                        <script>
                            setTimeout(function () {
                                $('.alert').fadeOut();
                            }, 2000);
                        </script>

                        

                    <% } %>

                    <br />
                    <asp:Button runat="server" ID="createBTN" CssClass="btn btn-success" Text="Crear" OnClick="createBTN_Click" />


                </div>

           
                <br />

                <div class="form-group">
                    <asp:GridView runat="server" ID="categoriesDTG" OnRowDataBound="categoriesDTG_RowDataBound" OnRowCommand="categoriesDTG_RowCommand" CssClass="table table-striped table-bordered table-hover">
                        <HeaderStyle BackColor="orange" ForeColor="White" />

                        <Columns>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="editBTN" CssClass="btn btn-warning" Text="Editar" />
                                    <asp:Button runat="server" ID="deleteBTN" CssClass="btn btn-danger" CommandName="Delete" Text="Eliminar" OnClick="deleteBTN_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                </div>
                <br />               
            </div>
        </div>
    </div>
</asp:Content>
