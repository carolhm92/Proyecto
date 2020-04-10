using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsUsuario
    {
        public List<ExisteUsuarioResult> ConsultarUsuario(string Usuario,string Clave)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ExisteUsuarioResult> data = dc.ExisteUsuario(Usuario,Clave).ToList();
                return data;
            }
            catch
            {
                throw;
            }

        }
    }
}
