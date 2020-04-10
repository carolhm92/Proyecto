
namespace API_Proyecto.Models
{
    public class Tratamiento
    {
        public int IdTratamiento { get; set; }
        public string NombreTratamiento { get; set; }
        public double Costo { get; set; }
        public int IdMascota { get; set; }
        public bool Estado { get; set; }
    }
}
