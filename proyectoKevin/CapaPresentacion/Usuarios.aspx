<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="proyectoKevin.CapaPresentacion.Usuarios" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Usuarios</title>
    <link href="<%= ResolveUrl("~/Style/Style.css") %>" rel="stylesheet" />
</head>
<body>
    <div class="main-container">
        <h2>Gestión de Usuarios</h2>
        <form runat="server">
            <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="UsuarioID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("UsuarioID") %>' OnClick="btnEditar_Click" CssClass="btn btn-warning btn-sm" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("UsuarioID") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <h3>Agregar/Editar Usuario</h3>
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="txtCorreo" runat="server" Placeholder="Correo" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="txtTelefono" runat="server" Placeholder="Teléfono" CssClass="form-control"></asp:TextBox>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnInicio" runat="server" Text="Regresar a Inicio" CssClass="btn btn-secondary mt-3" OnClick="btnInicio_Click" />
        </form>
    </div>
</body>

</html>
