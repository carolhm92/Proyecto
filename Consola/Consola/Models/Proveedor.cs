
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Consola.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        [DisplayName("Nombre Proveedor")]
        public string NombreProveedor { get; set; }
        public char Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        [ScaffoldColumn(false)]
        public string Provincia_Nombre { get; set; }
        [ScaffoldColumn(false)]
        public string Canton_Nombre { get; set; }
        [ScaffoldColumn(false)]
        public string Distrito_Nombre { get; set; }

        [ScaffoldColumn(false)]
        public bool Estado { get; set; }
    }
}
