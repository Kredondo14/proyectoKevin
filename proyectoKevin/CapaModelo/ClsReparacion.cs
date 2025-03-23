using System;

namespace CapaModelo
{
    public class ClsReparacion
    {
        public int ReparacionID { get; set; }
        public int EquipoID { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; }
    }
}
