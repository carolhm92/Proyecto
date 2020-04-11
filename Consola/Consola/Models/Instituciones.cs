
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Consola.Models
{
    public class Instituciones
    {
        public int Id { get; set; }
        [DisplayName("Id Institución")]
        public int IdInstitucion { get; set; }
        [DisplayName("Institución")]
        public string Institucion { get; set; }
        [DisplayName("Tipo Identitifcación")]
        public int IdTipoIdentitifcacion { get; set; }
        [DisplayName("Identificación")]
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [ScaffoldColumn(false)]
        public string TipoIdentificacion_Nombre { get; set; }

        [ScaffoldColumn(false)]
        public bool Estado { get; set; }
    }
}
