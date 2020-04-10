
namespace API_Proyecto.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double CostoProducto { get; set; }
        public int IdProveedor { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
    }
}
