using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class Tecnico_Logica
    {
        private static string conexionString = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

        public static DataTable ObtenerTecnicos()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlDataAdapter da = new SqlDataAdapter("ObtenerTecnicos", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerTecnicoPorID(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerTecnicoPorID", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static string ObtenerNombreTecnico(int tecnicoID)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerNombreTecnico", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tecnicoID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return $"{reader["Nombre"]} ({reader["Especialidad"]})";
                }
                return "Desconocido";
            }
        }

        public static void InsertarTecnico(string nombre, string especialidad)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("InsertarTecnico", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Especialidad", especialidad);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarTecnico(int id, string nombre, string especialidad)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ActualizarTecnico", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TecnicoID", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Especialidad", especialidad);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarTecnico(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("EliminarTecnico", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TecnicoID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
