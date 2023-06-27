<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MechanicWEB.Register" %>

<!DOCTYPE html>
<html>

<head>
  <title>Registration Page</title>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
  <style>
      body {
      background-color: #f7ede8;
    }

    .card-header {
      background-color: #ff6f4d;
      color: #fff;
      padding: 20px;
      font-size: 24px;
    }

    .btn-primary {
      background-color: #ff6f4d;
      border-color: #ff6f4d;
      padding: 10px 20px;
      font-size: 18px;
    }

    .btn-primary:hover {
      background-color: #ff5a36;
      border-color: #ff5a36;
    }

    .btn-secondary {
      background-color: #ffc2b4;
      border-color: #ffc2b4;
      padding: 10px 20px;
      font-size: 18px;
    }

    .btn-secondary:hover {
      background-color: #ffab93;
      border-color: #ffab93;
    }

    .card {
      width: 500px;
      margin: 0 auto;
      margin-top: 100px;
    }

    .form-group label {
      font-size: 18px;
    }

    .form-control {
      height: 40px;
      font-size: 16px;
    }

      body
       {
          background-image: url("./Assets/R.jpeg");
          background-repeat: no-repeat;
          background-size: cover; 
        }

     .overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.6); /* Ajusta el valor alfa para controlar la transparencia */
  z-index: 9999; /* Asegura que el contenedor esté en el frente de otros elementos */
}
  </style>
</head>

<body>
    <div class="overlay">
         <div class="container">
    <div class="card">
      <div class="card-header text-center">
        Regístrate
      </div>
      <div class="card-body">
        <form id="registerForm" runat="server">
        <div class="form-group">
            <label for="txtFullName">Nombre completo</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtLastName">Apellido paterno</label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtSecondLastName">Apellido materno</label>
            <asp:TextBox ID="txtSecondLastName" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtCI">CI</label>
            <asp:TextBox ID="txtCI" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>
        
            <div class="d-flex justify-content-between">      
                <button type="button" class="btn btn-secondary" href="Default.aspx">Cancel</button>        
                <asp:Button runat="server" ID="btnRegister" class="btn btn-primary" Text="Registrar" OnClick="btnRegister_Click"/>
            </div>

    </form>
        
      </div>
      <div class="card-footer text-center">
        Ya tienes una cuenta? <a href="Login.aspx">Login</a>
      </div>
    </div>
  </div>
    </div>

 
</body>

</html>
