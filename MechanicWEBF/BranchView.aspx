<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BranchView.aspx.cs" Inherits="MechanicWEBF.BranchView" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="mainContainer" style="margin-top:120px; margin-bottom:70px;margin-left:200px; margin-right:200px">
        <div class="row innerContainer">
            <div class="col-md-12 form-container">
    <button style="background: orange; border-width:0px; border-radius: 10px; height: 35px; width: 150px;"><a href="Branch.aspx" class="text-light">Insertar Sucursal</a></button>
                <br />
                <br />
    <formview>
         <div class="form-group">
                    <asp:GridView runat="server" ID="branchDTG" OnRowDataBound="categoriesDTG_RowDataBound" OnRowCommand="branchDTG_RowCommand"  CssClass="table table-striped table-bordered table-hover">
                        <HeaderStyle BackColor="orange" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="editBTN" CssClass="btn btn-warning" Text="Editar"  />
                                    <asp:Button runat="server" ID="deleteBTN" CssClass="btn btn-danger" Text="Eliminar" CommandName="Delete" OnClick="deleteBTN_Click"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                </div>
    </formview>
                </div>
        </div>
         </div>
</asp:Content>
