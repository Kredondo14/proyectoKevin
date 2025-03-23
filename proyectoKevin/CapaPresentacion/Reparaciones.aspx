<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reparaciones.aspx.cs" Inherits="proyectoKevin.CapaPresentacion.Reparaciones" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Reparaciones</title>
    <link href="<%= ResolveUrl("~/Style/Style.css") %>" rel="stylesheet" />
</head>
<body>
    <div class="main-container">
        <h2>Gestión de Reparaciones</h2>
        <form id="form1" runat="server">

            <asp:GridView ID="gvReparaciones" runat="server" CssClass="table" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ReparacionID" HeaderText="ID" />
                    <asp:BoundField DataField="EquipoID" HeaderText="Equipo ID" />
                    <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("ReparacionID") %>' OnClick="btnEditar_Click" CssClass="btn btn-warning btn-sm" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("ReparacionID") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm" />
                            <asp:HyperLink ID="hlAsignar" runat="server" CssClass="btn btn-info btn-sm" Text="Asignar" NavigateUrl='<%# Eval("ReparacionID", "Asignaciones.aspx?rep={0}") %>' />
                            <asp:HyperLink ID="hlDetalles" runat="server" CssClass="btn btn-secondary btn-sm" Text="Detalles" NavigateUrl='<%# Eval("ReparacionID", "DetallesReparaciones.aspx?rep={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <h3>Agregar/Editar Reparación</h3>
            <asp:DropDownList ID="ddlEquipos" runat="server" CssClass="form-control" />

            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date" />

            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione estado..." Value="" />
                <asp:ListItem Text="Pendiente" Value="Pendiente" />
                <asp:ListItem Text="En Proceso" Value="En Proceso" />
                <asp:ListItem Text="Completado" Value="Completado" />
            </asp:DropDownList>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnInicio" runat="server" Text="Regresar a Inicio" OnClick="btnInicio_Click" CssClass="btn btn-secondary" />
        </form>
    </div>
</body>
</html>
