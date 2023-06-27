<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="MechanicWEB.Client" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <formview>
        <div class="mainContainer" style="margin-top:120px; margin-bottom:70px;margin-left:200px; margin-right:200px">
        <div class="row innerContainer">
        <div class="form-group">
                    <asp:GridView runat="server" ID="clientsDTG" OnRowDataBound="productsDTG_RowDataBound" CssClass="table table-striped table-bordered table-hover">
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
            </div>
            </div>
    </formview>
</asp:Content>
