using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class Reparacion_Logica
    {
        private static string conexionString = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

        public static DataTable ObtenerReparaciones()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlDataAdapter da = new SqlDataAdapter("ObtenerReparaciones", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerReparacionPorID(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerReparacionPorID", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void InsertarReparacion(int equipoID, DateTime fecha, string estado)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("InsertarReparacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EquipoID", equipoID);
                cmd.Parameters.AddWithValue("@FechaSolicitud", fecha);
                cmd.Parameters.AddWithValue("@Estado", estado);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarReparacion(int id, int equipoID, DateTime fecha, string estado)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ActualizarReparacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReparacionID", id);
                cmd.Parameters.AddWithValue("@EquipoID", equipoID);
                cmd.Parameters.AddWithValue("@FechaSolicitud", fecha);
                cmd.Parameters.AddWithValue("@Estado", estado);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarReparacion(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("EliminarReparacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReparacionID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static string ObtenerInfoReparacion(int reparacionID)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerInfoReparacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", reparacionID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return $"{reader["Modelo"]} - {reader["Estado"]}";
                }
                return "Desconocido";
            }
        }
    }
}
