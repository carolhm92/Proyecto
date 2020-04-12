
using System;

namespace API_Proyecto.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public string Cedula { get; set; }
        public string Identificacion { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public int? Cantidad { get; set; }
        public double? Impuesto { get; set; }
        public double Total { get; set; }
        public bool Estado { get; set; }
    }
}
