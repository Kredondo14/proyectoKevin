using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using CapaNegocio;

namespace proyectoKevin.CapaPresentacion
{
    public partial class Asignaciones : Page
    {
        private int reparacionID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reparacionID = Convert.ToInt32(Request.QueryString["rep"]);
                ViewState["ReparacionID"] = reparacionID;
                CargarTecnicos();
                CargarAsignaciones();
            }
        }

        private void CargarTecnicos()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TecnicoID, Nombre FROM Tecnicos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlTecnicos.DataSource = dt;
                ddlTecnicos.DataTextField = "Nombre";
                ddlTecnicos.DataValueField = "TecnicoID";
                ddlTecnicos.DataBind();
                ddlTecnicos.Items.Insert(0, new ListItem("Seleccione técnico...", ""));
            }
        }

        private void CargarAsignaciones()
        {
            DataTable dtOriginal = Asignacion_Logica.ObtenerAsignaciones();
            DataTable dtExtendido = new DataTable();

            dtExtendido.Columns.Add("AsignacionID");
            dtExtendido.Columns.Add("Reparacion");
            dtExtendido.Columns.Add("Tecnico");
            dtExtendido.Columns.Add("Fecha");

            foreach (DataRow row in dtOriginal.Rows)
            {
                int reparacionID = Convert.ToInt32(row["ReparacionID"]);
                int tecnicoID = Convert.ToInt32(row["TecnicoID"]);

                string reparacion = Reparacion_Logica.ObtenerInfoReparacion(reparacionID);
                string tecnico = Tecnico_Logica.ObtenerNombreTecnico(tecnicoID);

                dtExtendido.Rows.Add(row["AsignacionID"], reparacion, tecnico, row["FechaAsignacion"]);
            }

            gvAsignaciones.DataSource = dtExtendido;
            gvAsignaciones.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int tecnicoID = int.Parse(ddlTecnicos.SelectedValue);
            DateTime fecha = DateTime.Parse(txtFecha.Text);
            int reparacionID = (int)ViewState["ReparacionID"];

            if (ViewState["AsignacionID"] == null)
            {
                Asignacion_Logica.InsertarAsignacion(reparacionID, tecnicoID, fecha);
            }
            else
            {
                int id = (int)ViewState["AsignacionID"];
                Asignacion_Logica.ActualizarAsignacion(id, reparacionID, tecnicoID, fecha);
                ViewState["AsignacionID"] = null;
            }

            Limpiar();
            CargarAsignaciones();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            DataTable dt = Asignacion_Logica.ObtenerAsignacionPorID(id);

            if (dt.Rows.Count > 0)
            {
                ddlTecnicos.SelectedValue = dt.Rows[0]["TecnicoID"].ToString();
                txtFecha.Text = DateTime.Parse(dt.Rows[0]["FechaAsignacion"].ToString()).ToString("yyyy-MM-dd");
                ViewState["AsignacionID"] = id;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Asignacion_Logica.EliminarAsignacion(id);
            CargarAsignaciones();
        }

        private void Limpiar()
        {
            ddlTecnicos.SelectedIndex = 0;
            txtFecha.Text = "";
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}
