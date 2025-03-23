// Archivo 6: Usuario_Logica.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class Usuario_Logica
    {
        private static string conexionString = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

        public static bool ValidarUsuario(string correo, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ValidarUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public static DataTable ObtenerUsuarios()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlDataAdapter da = new SqlDataAdapter("ObtenerUsuarios", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerUsuarioPorID(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerUsuarioPorID", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioID", idUsuario);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void InsertarUsuario(string nombre, string correo, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("InsertarUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarUsuario(int idUsuario, string nombre, string correo, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ActualizarUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioID", idUsuario);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("EliminarUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioID", idUsuario);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
