
namespace API_Proyecto.Models
{
    using System;
    
    public class Cita
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTratamiento { get; set; }
        public bool Estado { get; set; }
    }
}
