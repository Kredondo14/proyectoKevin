using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace proyectoKevin.CapaPresentacion
{
    public partial class Usuarios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            gvUsuarios.DataSource = Usuario_Logica.ObtenerUsuarios();
            gvUsuarios.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario_Logica.InsertarUsuario(txtNombre.Text, txtCorreo.Text, txtTelefono.Text);
            LimpiarCampos();
            CargarUsuarios();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            int idUsuario = Convert.ToInt32(btnEditar.CommandArgument);

            DataTable dt = Usuario_Logica.ObtenerUsuarioPorID(idUsuario);

            if (dt.Rows.Count > 0)
            {
                txtNombre.Text = dt.Rows[0]["Nombre"].ToString();
                txtCorreo.Text = dt.Rows[0]["CorreoElectronico"].ToString();
                txtTelefono.Text = dt.Rows[0]["Telefono"].ToString();

                ViewState["UsuarioID"] = idUsuario;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int idUsuario = Convert.ToInt32(btnEliminar.CommandArgument);

            Usuario_Logica.EliminarUsuario(idUsuario);
            CargarUsuarios();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;

            if (ViewState["UsuarioID"] == null)
            {
                Usuario_Logica.InsertarUsuario(nombre, correo, telefono);
            }
            else
            {
                int idUsuario = Convert.ToInt32(ViewState["UsuarioID"]);
                Usuario_Logica.ActualizarUsuario(idUsuario, nombre, correo, telefono);
                ViewState["UsuarioID"] = null;
            }

            LimpiarCampos();
            CargarUsuarios();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

    }
}
