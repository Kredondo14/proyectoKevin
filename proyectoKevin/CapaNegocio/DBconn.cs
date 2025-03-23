using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class DBconn
    {
        public static SqlConnection ObtenerConexion()
        {
            string conexion = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;
            SqlConnection conn = new SqlConnection(conexion);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de conexión a la base de datos: " + ex.Message);
            }
        }
    }
}
