using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public int IdTipoIdentificacion { get; set; }

        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public char Provincia { get; set; }

        public string Canton { get; set; }

        public string Distrito { get; set; }

        public bool Estado { get; set; }

    }
}