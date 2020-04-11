
namespace Consola.Models
{
    public class Mascota
    {
        public int IdMascota { get; set; }
        public string NombreMascota { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public int IdCliente { get; set; }
        public double? Peso { get; set; }
        public string Identificacion { get; set; }
        public bool Estado { get; set; }
    }
}
