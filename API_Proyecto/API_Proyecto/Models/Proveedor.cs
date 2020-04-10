
namespace API_Proyecto.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public char Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
    }
}
