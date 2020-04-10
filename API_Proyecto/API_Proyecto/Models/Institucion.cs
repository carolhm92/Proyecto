
namespace API_Proyecto.Models
{
    public class Institucion
    {
        public int Id { get; set; }
        public int IdInstitucion { get; set; }
        public string Institucion1 { get; set; }
        public int IdTipoIdentitifcacion { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}
