<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="proyectoKevin.CapaPresentacion.Equipos" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Equipos</title>
    <link href="<%= ResolveUrl("~/Style/Style.css") %>" rel="stylesheet" />
</head>
<body>
    <div class="main-container">
        <h2>Gestión de Equipos</h2>
        <form id="form1" runat="server">

            <asp:GridView ID="gvEquipos" runat="server" CssClass="table" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="EquipoID" HeaderText="ID" />
                    <asp:BoundField DataField="TipoEquipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="UsuarioID" HeaderText="Usuario ID" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("EquipoID") %>' OnClick="btnEditar_Click" CssClass="btn btn-warning btn-sm" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("EquipoID") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <h3>Agregar/Editar Equipo</h3>

            <asp:DropDownList ID="ddlTipoEquipo" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione tipo..." Value="" />
                <asp:ListItem Text="Laptop" Value="Laptop" />
                <asp:ListItem Text="PC" Value="PC" />
                <asp:ListItem Text="Impresora" Value="Impresora" />
                <asp:ListItem Text="Tablet" Value="Tablet" />
                <asp:ListItem Text="Celular" Value="Celular" />
            </asp:DropDownList>

            <asp:TextBox ID="txtModelo" runat="server" Placeholder="Modelo" CssClass="form-control" />
            <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-control" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnInicio" runat="server" Text="Regresar a Inicio" OnClick="btnInicio_Click" CssClass="btn btn-secondary" />
        </form>
    </div>
</body>
</html>
