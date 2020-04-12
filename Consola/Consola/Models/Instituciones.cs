
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Consola.Models
{
    public class Instituciones
    {
        public int Id { get; set; }
        [DisplayName("Id Instituci�n")]
        public int IdInstitucion { get; set; }
        [DisplayName("Instituci�n")]
        public string Institucion { get; set; }
        [DisplayName("Tipo Identitifcaci�n")]
        public int IdTipoIdentitifcacion { get; set; }
        [DisplayName("Identificaci�n")]
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        [DisplayName("Direcci�n")]
        public string Direccion { get; set; }
        [ScaffoldColumn(false)]
        public string TipoIdentificacion_Nombre { get; set; }

        [ScaffoldColumn(false)]
        public bool Estado { get; set; }
    }
}
