<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="proyectoKevin.CapaPresentacion.Asignaciones" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Asignaciones de Técnicos</title>
    <link href="<%= ResolveUrl("~/Style/Style.css") %>" rel="stylesheet" />
</head>
<body>
    <div class="main-container">
        <h2>Asignaciones de Técnicos</h2>
        <form id="form1" runat="server">

            <asp:GridView ID="gvAsignaciones" runat="server" CssClass="table" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="AsignacionID" HeaderText="ID" />
                    <asp:BoundField DataField="Reparacion" HeaderText="Reparación" />
                    <asp:BoundField DataField="Tecnico" HeaderText="Técnico" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("AsignacionID") %>' OnClick="btnEditar_Click" CssClass="btn btn-warning btn-sm" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("AsignacionID") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <h3>Asignar Técnico</h3>

            <asp:DropDownList ID="ddlTecnicos" runat="server" CssClass="form-control" />
            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnInicio" runat="server" Text="Volver a Inicio" CssClass="btn btn-secondary" OnClick="btnInicio_Click" />
        </form>
    </div>
</body>
</html>
