<%@ Page Title="Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Branch.aspx.cs" Inherits="MechanicWEBF.Branch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="mainContainer" style="margin-top:120px; margin-bottom:70px;margin-left:200px; margin-right:200px">
        <div class="row innerContainer">
            <div class="col-md-12 form-container">
                <h1>Inserta una Sucursal</h1>
                <div class="form-group">


                    <h3>Elegir Ubicación en el mapa</h3>
                    <button style="background: orange; border-width:0px; border-radius: 10px; height: 35px; width: 150px;" href="loadMap.aspx"><a href="loadMap.aspx" class="text-light">Elegir Ubicación</a></button>
                  <br />
                  <br />
                    <h3>Nombre de la Sucursal</h3>
                       <asp:TextBox runat="server" ID="txtBranchName" CssClass="form-control" placeholder="Nombre de la Sucursal"/>
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

                        <h4>Departamento</h4>
                        <asp:DropDownList runat="server" ID="comboCountry" CssClass="form-control" OnSelectedIndexChanged="comboCountry_SelectedIndexChanged" AutoPostBack="true" placeholder="Nombre del Departamento" ></asp:DropDownList>

                        <h4>Provincia</h4>
                        <asp:DropDownList runat="server" ID="comboProvince" CssClass="form-control" placeholder="Nombre de la Provincia" ></asp:DropDownList>
                                           
                    <h4>Latitud</h4>
                    <asp:TextBox runat="server" ID="txtLat" CssClass="form-control" Enabled="false"/>
                    <h4>Longitud</h4>
                    <asp:TextBox runat="server" ID="txtLon" CssClass="form-control" Enabled="false"/>


                    <br />
                    <asp:Button runat="server" ID="createBTN" CssClass="btn btn-success" OnClick="createBTN_Click" Text="Crear" />


                </div>

                <br />
         
            </div>
        </div>
    </div>
</asp:Content>
