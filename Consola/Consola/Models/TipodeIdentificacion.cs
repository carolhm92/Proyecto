
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Consola.Models
{
    public class TipodeIdentificacion
    {
        public int IdTipoIdentificacion { get; set; }
        [DisplayName("Tipo de Identificación")]
        public string TipoIdentificacion { get; set; }
        [ScaffoldColumn(false)]
        public bool Estado { get; set; }
    }
}
