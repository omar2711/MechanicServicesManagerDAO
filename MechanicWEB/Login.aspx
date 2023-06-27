<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MechanicWEB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Login</title>

</head>
<body>
    
</body>
</html><!DOCTYPE html>
<html>

<head>
    <title>Login Page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
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
    </style>
</head>

<body>
    <div class="container">
        <div class="card">
            <div class="card-header text-center">
                Login
            </div>
            <div class="card-body">
                <form runat="server" method="post">
                    <div class="form-group">
                        <label for="username">Nombre de Usuario</label>
                        <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="Introduce tu nombre de usuario"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="password">Contraseña</label>
                        <asp:TextBox ID="password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Introduce tu contraseña"></asp:TextBox>
                    </div>
                    <div class="d-flex justify-content-between">
                        <button type="button" class="btn btn-secondary"><a href="Default.aspx">Cancelar</a></button>
                        <asp:Button ID="loginButton" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="loginButton_Click"  />
                        
                    </div>
                </form>
            </div>
            <div class="card-footer text-center">
                No tienes una cuenta? <a href="Register.aspx">Regístrate</a>
            </div>
        </div>
    </div>
</body>

</html>

