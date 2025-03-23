<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="proyectoKevin.CapaPresentacion.Login" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>Login</title>
   <link href="<%= ResolveUrl("~/Style/Style.css") %>" rel="stylesheet" />
</head>
<body class="center-screen">

    <form id="form1" runat="server">
        <div class="container">
            <h2>Inicio de Sesión</h2>

            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Correo electrónico"></asp:TextBox>
            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" placeholder="Teléfono"></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </form>
</body>
</html>
