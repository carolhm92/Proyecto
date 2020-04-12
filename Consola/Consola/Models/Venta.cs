
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Consola.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public string Cedula { get; set; }
        [DisplayName("Identificación")]
        public string Identificacion { get; set; }
        [DisplayName("Id Producto")]
        public int? IdProducto { get; set; }
        [DisplayName("Id Cita")]
        public int? IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        [ScaffoldColumn(false)]
        public string Producto_Nombre { get; set; }
        [ScaffoldColumn(false)]
        public bool Estado { get; set; }
    }
}
