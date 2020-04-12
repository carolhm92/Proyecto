
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Consola.Models
{
    public class Tratamiento
    {
        public int IdTratamiento { get; set; }
        [DisplayName("Nombre Tratamiento")]
        public string NombreTratamiento { get; set; }
        public double? Costo { get; set; }
        [DisplayName("Mascota")]
        public int? IdMascota { get; set; }
        [ScaffoldColumn(false)]
        public bool Estado { get; set; }
    }
}
