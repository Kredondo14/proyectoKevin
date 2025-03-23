using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace proyectoKevin.CapaPresentacion
{
    public partial class Equipos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
                CargarEquipos();
            }
        }

        private void CargarUsuarios()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT UsuarioID, Nombre FROM Usuarios", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlUsuarios.DataSource = dt;
                ddlUsuarios.DataTextField = "Nombre";
                ddlUsuarios.DataValueField = "UsuarioID";
                ddlUsuarios.DataBind();
                ddlUsuarios.Items.Insert(0, new ListItem("Seleccione usuario...", ""));
            }
        }


        private void CargarEquipos()
        {
            gvEquipos.DataSource = Equipo_Logica.ObtenerEquipos();
            gvEquipos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string tipo = ddlTipoEquipo.SelectedValue;

            string modelo = txtModelo.Text;
            int usuarioID = int.Parse(ddlUsuarios.SelectedValue);


            if (ViewState["EquipoID"] == null)
            {
                Equipo_Logica.InsertarEquipo(tipo, modelo, usuarioID);
            }
            else
            {
                int id = (int)ViewState["EquipoID"];
                Equipo_Logica.ActualizarEquipo(id, tipo, modelo, usuarioID);
                ViewState["EquipoID"] = null;
            }

            LimpiarCampos();
            CargarEquipos();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            DataTable dt = Equipo_Logica.ObtenerEquipoPorID(id);

            if (dt.Rows.Count > 0)
            {
                ddlTipoEquipo.SelectedValue = dt.Rows[0]["TipoEquipo"].ToString();
                txtModelo.Text = dt.Rows[0]["Modelo"].ToString();
                ddlUsuarios.SelectedValue = dt.Rows[0]["UsuarioID"].ToString();
                ViewState["EquipoID"] = id;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Equipo_Logica.EliminarEquipo(id);
            CargarEquipos();
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        private void LimpiarCampos()
        {
            ddlTipoEquipo.SelectedIndex = 0;
            txtModelo.Text = "";
            ddlUsuarios.SelectedIndex = 0;

        }
    }
}
