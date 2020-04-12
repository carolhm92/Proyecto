
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Consola.Models
{
    public class Producto
    {
        [DisplayName("Id Producto")]
        public int IdProducto { get; set; }
        [DisplayName("Producto")]
        public string NombreProducto { get; set; }
        [DisplayName("Costo")]
        public double CostoProducto { get; set; }
        [DisplayName("Proveedor")]
        public int IdProveedor { get; set; }
        public int Cantidad { get; set; }
        [ScaffoldColumn(false)]
        public string Proveedor_Nombre { get; set; }
        [ScaffoldColumn(false)]
        public bool Estado { get; set; }
    }
}
