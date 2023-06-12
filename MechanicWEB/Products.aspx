<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="MechanicWEB.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainContainer">
        <div class="row innerContainer">
            <div class="col-md-12 form-container">
                <h1>Productos</h1>

                <div class="form-group">
                    <h2>Insertar una Producto</h2>
                    <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder="Nombre"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtPrice" class="form-control" runat="server" placeholder="Precio"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtStock" class="form-control" runat="server" placeholder="Stock"></asp:TextBox>
                    <br />

                   



                    <asp:Label Text="Selecciona una Categoria: " runat="server" />
                    <asp:DropDownList class="form-control" ID="cmbCategory" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Label Text="Selecciona una Marca: " runat="server" />
                    <asp:DropDownList ID="cmbBrand" class="form-control" runat="server"></asp:DropDownList>
                    <br />
                    
                    <% if (ViewState["Error"] != null) { %>
                        <div id="alerta" class="alert alert-danger">
                            <strong>Error!</strong> <%= ViewState["Error"] %>
                        </div>
                     
                    <% }%>

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

                    <asp:Button runat="server" ID="createBTN" CssClass="btn btn-success" Text="Insertar" OnClick="createBTN_Click" />


                </div>

                <br />

                <div class="form-group">
                    <asp:GridView runat="server" ID="productsDTG" CssClass="table table-striped table-bordered table-hover">
                        <HeaderStyle BackColor="orange" ForeColor="White" />

                        <Columns>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="editBTN" CssClass="btn btn-warning" Text="Editar" />
                                    <asp:Button runat="server" ID="deleteBTN" CssClass="btn btn-danger" Text="Eliminar" />
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
