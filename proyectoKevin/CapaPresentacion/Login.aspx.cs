using System;
using System.Web.UI;
using CapaNegocio;

namespace proyectoKevin.CapaPresentacion
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMensaje.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text;
            string telefono = txtClave.Text;

            if (Usuario_Logica.ValidarUsuario(correo, telefono))
            {
                Session["Usuario"] = correo;
                Response.Redirect("inicio.aspx", false);
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }

    }
}
