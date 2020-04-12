using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Consola.Models
{
	public class User
	{
		public int IdUsuario { get; set; }
		public string Usuario { get; set; }
		public string Clave { get; set; }
		public List<int> Roles { get; set; }
		public int[] Role { get; set; }
		[ScaffoldColumn(false)]
		public bool Estado { get; set; }
	}
}