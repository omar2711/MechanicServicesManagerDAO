<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="MechanicWEB.Categories" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainContainer">
        <div class="row innerContainer">
            <div class="col-md-12 form-container">
                <h1>Categorias</h1>
                <div class="form-group">
                    <h2>Insertar una Categoria</h2>
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
                    <asp:Button runat="server" ID="createBTN" CssClass="btn btn-success" Text="Crear" OnClick="createBTN_Click" />


                </div>

                <br />

                <div class="form-group">
                    <asp:GridView runat="server" ID="categoriesDTG" OnRowDataBound="categoriesDTG_RowDataBound" CssClass="table table-striped table-bordered table-hover">
                        <HeaderStyle BackColor="orange" ForeColor="White" />

                        <Columns>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="editBTN" CssClass="btn btn-warning" Text="Editar" OnClick="editBTN_Click" />
                                    <asp:Button runat="server" ID="deleteBTN" CssClass="btn btn-danger" Text="Eliminar"  OnClick="deleteBTN_Click"/>
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
