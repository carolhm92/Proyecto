using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Proyecto.Models
{
    public class User
    {
		public int IdUsuario { get; set; }
		public string Usuario { get; set; }
		public string Clave { get; set; }
		public bool Estado { get; set; }
	}
}