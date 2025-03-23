<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallesReparaciones.aspx.cs" Inherits="proyectoKevin.CapaPresentacion.DetallesReparaciones" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Detalles de Reparación</title>
    <link href="<%= ResolveUrl("~/Style/Style.css") %>" rel="stylesheet" />
</head>
<body>
    <div class="main-container">
        <h2>Detalles de Reparación</h2>
        <form runat="server">

            <asp:GridView ID="gvDetalles" runat="server" CssClass="table" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="DetalleID" HeaderText="ID" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Inicio" />
                    <asp:BoundField DataField="FechaFin" HeaderText="Fin" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("DetalleID") %>' OnClick="btnEditar_Click" CssClass="btn btn-warning btn-sm" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("DetalleID") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <h3>Agregar/Editar Detalle</h3>

            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Descripción" />
            <asp:TextBox ID="txtInicio" runat="server" CssClass="form-control" TextMode="Date" />
            <asp:TextBox ID="txtFin" runat="server" CssClass="form-control" TextMode="Date" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnInicio" runat="server" Text="Regresar a Inicio" CssClass="btn btn-secondary" OnClick="btnInicio_Click" />
        </form>
    </div>
</body>
</html>
