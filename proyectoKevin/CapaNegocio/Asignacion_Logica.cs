using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class Asignacion_Logica
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

        public static DataTable ObtenerAsignaciones()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter("ObtenerAsignaciones", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerAsignacionPorID(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("ObtenerAsignacionPorID", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void InsertarAsignacion(int repID, int tecnicoID, DateTime fecha)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("InsertarAsignacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReparacionID", repID);
                cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);
                cmd.Parameters.AddWithValue("@FechaAsignacion", fecha);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarAsignacion(int id, int repID, int tecnicoID, DateTime fecha)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("ActualizarAsignacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AsignacionID", id);
                cmd.Parameters.AddWithValue("@ReparacionID", repID);
                cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);
                cmd.Parameters.AddWithValue("@FechaAsignacion", fecha);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarAsignacion(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("EliminarAsignacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AsignacionID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
