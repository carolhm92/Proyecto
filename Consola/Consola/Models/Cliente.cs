using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        [DisplayName("Tipo Identificación")]
        public int IdTipoIdentificacion { get; set; }
        [DisplayName("Identificación")]
        public string Identificacion { get; set; }
        [StringLength(50,MinimumLength =3)]
        public string Nombre { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Primer Apellido")]
        public string Apellido1 { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Segundo Apellido")]
        public string Apellido2 { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        public char Provincia { get; set; }
        public string Canton { get; set; }

        public string Distrito { get; set; }

        [ScaffoldColumn(false)]
        public string TipoIdentificacion_Nombre { get; set; }
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