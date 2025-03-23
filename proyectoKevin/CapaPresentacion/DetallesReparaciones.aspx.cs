using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace proyectoKevin.CapaPresentacion
{
    public partial class DetallesReparaciones : Page
    {
        protected int reparacionID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reparacionID = Convert.ToInt32(Request.QueryString["rep"]);
                ViewState["ReparacionID"] = reparacionID;
                CargarDetalles();
            }
        }

        private void CargarDetalles()
        {
            DataTable dt = DetalleReparacion_Logica.ObtenerDetallesPorReparacion((int)ViewState["ReparacionID"]);
            gvDetalles.DataSource = dt;
            gvDetalles.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string desc = txtDescripcion.Text;
            DateTime inicio = DateTime.Parse(txtInicio.Text);
            DateTime? fin = string.IsNullOrEmpty(txtFin.Text) ? (DateTime?)null : DateTime.Parse(txtFin.Text);
            int reparacionID = (int)ViewState["ReparacionID"];

            if (ViewState["DetalleID"] == null)
            {
                DetalleReparacion_Logica.InsertarDetalle(reparacionID, desc, inicio, fin);
            }
            else
            {
                int id = (int)ViewState["DetalleID"];
                DetalleReparacion_Logica.ActualizarDetalle(id, reparacionID, desc, inicio, fin);
                ViewState["DetalleID"] = null;
            }

            Limpiar();
            CargarDetalles();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            DataTable dt = DetalleReparacion_Logica.ObtenerDetallePorID(id);

            if (dt.Rows.Count > 0)
            {
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtInicio.Text = Convert.ToDateTime(dt.Rows[0]["FechaInicio"]).ToString("yyyy-MM-dd");
                txtFin.Text = dt.Rows[0]["FechaFin"] == DBNull.Value ? "" : Convert.ToDateTime(dt.Rows[0]["FechaFin"]).ToString("yyyy-MM-dd");
                ViewState["DetalleID"] = id;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            DetalleReparacion_Logica.EliminarDetalle(id);
            CargarDetalles();
        }

        private void Limpiar()
        {
            txtDescripcion.Text = "";
            txtInicio.Text = "";
            txtFin.Text = "";
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}
