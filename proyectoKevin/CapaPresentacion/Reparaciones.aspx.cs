using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace proyectoKevin.CapaPresentacion
{
    public partial class Reparaciones : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipos();
                CargarReparaciones();
            }
        }

        private void CargarEquipos()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT e.EquipoID, 
                   CONCAT(e.Modelo, ' - ', u.Nombre) AS Descripcion 
            FROM Equipos e
            INNER JOIN Usuarios u ON e.UsuarioID = u.UsuarioID", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlEquipos.DataSource = dt;
                ddlEquipos.DataTextField = "Descripcion";
                ddlEquipos.DataValueField = "EquipoID";
                ddlEquipos.DataBind();

                ddlEquipos.Items.Insert(0, new ListItem("Seleccione equipo...", ""));
            }
        }


        private void CargarReparaciones()
        {
            gvReparaciones.DataSource = Reparacion_Logica.ObtenerReparaciones();
            gvReparaciones.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int equipoID = int.Parse(ddlEquipos.SelectedValue);
            DateTime fecha = DateTime.Parse(txtFecha.Text);
            string estado = ddlEstado.SelectedValue;


            if (ViewState["ReparacionID"] == null)
            {
                Reparacion_Logica.InsertarReparacion(equipoID, fecha, estado);
            }
            else
            {
                int id = (int)ViewState["ReparacionID"];
                Reparacion_Logica.ActualizarReparacion(id, equipoID, fecha, estado);
                ViewState["ReparacionID"] = null;
            }

            LimpiarCampos();
            CargarReparaciones();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            DataTable dt = Reparacion_Logica.ObtenerReparacionPorID(id);

            if (dt.Rows.Count > 0)
            {
                ddlEquipos.SelectedValue = dt.Rows[0]["EquipoID"].ToString();
                txtFecha.Text = DateTime.Parse(dt.Rows[0]["FechaSolicitud"].ToString()).ToString("yyyy-MM-dd");
                ddlEstado.SelectedValue = dt.Rows[0]["Estado"].ToString();

                ViewState["ReparacionID"] = id;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Reparacion_Logica.EliminarReparacion(id);
            CargarReparaciones();
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        private void LimpiarCampos()
        {
            ddlEquipos.SelectedIndex = 0;
            txtFecha.Text = "";
            ddlEstado.SelectedIndex = 0;
        }
    }
}
