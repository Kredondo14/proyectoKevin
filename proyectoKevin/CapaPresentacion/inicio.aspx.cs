using System;
using System.Web.UI;

namespace proyectoKevin.CapaPresentacion
{
    public partial class Inicio : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void btnEquipos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Equipos.aspx");
        }

        protected void btnTecnicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tecnicos.aspx");
        }

        protected void btnReparaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reparaciones.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}
