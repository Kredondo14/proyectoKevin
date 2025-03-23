<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="proyectoKevin.CapaPresentacion.Inicio" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>Inicio</title>
    <link href="<%= ResolveUrl("~/Style/Style.css") %>" rel="stylesheet" />
</head>
<body class="center-screen">
    <form runat="server" class="container">
        <h2>Bienvenido al sistema</h2>
        <p>Selecciona una opción:</p>

        <div class="d-grid">
            <asp:Button ID="btnUsuarios" runat="server" Text="Gestión de Usuarios" CssClass="btn btn-primary" OnClick="btnUsuarios_Click" />
            <asp:Button ID="btnEquipos" runat="server" Text="Gestión de Equipos" CssClass="btn btn-primary" OnClick="btnEquipos_Click" />
            <asp:Button ID="btnTecnicos" runat="server" Text="Gestión de Técnicos" CssClass="btn btn-primary" OnClick="btnTecnicos_Click" />
            <asp:Button ID="btnReparaciones" runat="server" Text="Gestión de Reparaciones" CssClass="btn btn-primary" OnClick="btnReparaciones_Click" />
        </div>

        <hr />

        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-danger" OnClick="btnCerrarSesion_Click" />
    </form>
</body>
</html>
