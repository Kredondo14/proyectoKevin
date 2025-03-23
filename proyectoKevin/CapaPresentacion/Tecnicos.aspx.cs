using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace proyectoKevin.CapaPresentacion
{
    public partial class Tecnicos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTecnicos();
            }
        }

        private void CargarTecnicos()
        {
            gvTecnicos.DataSource = Tecnico_Logica.ObtenerTecnicos();
            gvTecnicos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string especialidad = ddlEspecialidad.SelectedValue;


            if (ViewState["TecnicoID"] == null)
            {
                Tecnico_Logica.InsertarTecnico(nombre, especialidad);
            }
            else
            {
                int id = Convert.ToInt32(ViewState["TecnicoID"]);
                Tecnico_Logica.ActualizarTecnico(id, nombre, especialidad);
                ViewState["TecnicoID"] = null;
            }

            LimpiarCampos();
            CargarTecnicos();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);
            DataTable dt = Tecnico_Logica.ObtenerTecnicoPorID(id);

            if (dt.Rows.Count > 0)
            {
                txtNombre.Text = dt.Rows[0]["Nombre"].ToString();
                ddlEspecialidad.SelectedValue = dt.Rows[0]["Especialidad"].ToString();

                ViewState["TecnicoID"] = id;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);
            Tecnico_Logica.EliminarTecnico(id);
            CargarTecnicos();
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            ddlEspecialidad.SelectedIndex = 0;

        }
    }
}
