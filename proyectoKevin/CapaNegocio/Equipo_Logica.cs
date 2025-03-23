using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class Equipo_Logica
    {
        private static string conexionString = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

        public static DataTable ObtenerEquipos()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlDataAdapter da = new SqlDataAdapter("ObtenerEquipos", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerEquipoPorID(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerEquipoPorID", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void InsertarEquipo(string tipo, string modelo, int usuarioID)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("InsertarEquipo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoEquipo", tipo);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarEquipo(int id, string tipo, string modelo, int usuarioID)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ActualizarEquipo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EquipoID", id);
                cmd.Parameters.AddWithValue("@TipoEquipo", tipo);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarEquipo(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("EliminarEquipo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EquipoID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
