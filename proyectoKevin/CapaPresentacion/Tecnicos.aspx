<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="proyectoKevin.CapaPresentacion.Tecnicos" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Técnicos</title>
    <link href="<%= ResolveUrl("~/Style/Style.css") %>" rel="stylesheet" />
</head>
<body>
    <div class="main-container mt-4">
        <h2>Gestión de Técnicos</h2>
        <form id="form1" runat="server">
            <asp:GridView ID="gvTecnicos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="TecnicoID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("TecnicoID") %>' OnClick="btnEditar_Click" CssClass="btn btn-warning btn-sm" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("TecnicoID") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <h3>Agregar/Editar Técnico</h3>
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control mb-2" />
            <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control mb-2">
                <asp:ListItem Text="Seleccione especialidad..." Value="" />
                <asp:ListItem Text="Hardware" Value="Hardware" />
                <asp:ListItem Text="Software" Value="Software" />
                <asp:ListItem Text="Redes" Value="Redes" />
                <asp:ListItem Text="Electrónica" Value="Electrónica" />
                <asp:ListItem Text="Diagnóstico" Value="Diagnóstico" />
            </asp:DropDownList>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnInicio" runat="server" Text="Regresar a Inicio" OnClick="btnInicio_Click" CssClass="btn btn-secondary ml-2" />
        </form>
    </div>
</body>
</html>
