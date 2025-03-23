using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class DetalleReparacion_Logica
    {
        private static string conexionString = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

        public static DataTable ObtenerDetallesPorReparacion(int reparacionID)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerDetallesPorReparacion", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReparacionID", reparacionID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerDetallePorID(int detalleID)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerDetalleReparacionPorID", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DetalleID", detalleID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void InsertarDetalle(int reparacionID, string descripcion, DateTime fechaInicio, DateTime? fechaFin)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("InsertarDetalleReparacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReparacionID", reparacionID);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarDetalle(int detalleID, int reparacionID, string descripcion, DateTime fechaInicio, DateTime? fechaFin)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("ActualizarDetalleReparacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DetalleID", detalleID);
                cmd.Parameters.AddWithValue("@ReparacionID", reparacionID);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarDetalle(int detalleID)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand("EliminarDetalleReparacion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DetalleID", detalleID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
