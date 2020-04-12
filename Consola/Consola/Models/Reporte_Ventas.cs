using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Reporte_Ventas
    {
        public string Cedula { get; set; }
        public string Identificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public int? Cantidad { get; set; }
        public double? Impuesto { get; set; }
        public double Total { get; set; }
        public string NombreProducto { get; set; }
        public double CostoProducto { get; set; }
    }
}