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
        public List<ExisteUsuarioResult> ExisteUsuario(string Usuario,string Clave)
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

        public List<ConsultarUsuarioResult> ConsultarUsuario()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarUsuarioResult> data = dc.ConsultarUsuario().ToList();
                return data;
            }
            catch
            {
                throw;
            }

        }
        public ExisteUsuarioResult ConsultaUsuario(string Usuario, string Clave)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ExisteUsuarioResult data = dc.ExisteUsuario(Usuario, Clave).FirstOrDefault();
                return data;
            }
            catch
            {

                throw;
            }

        }
        public AgregarUsuarioResult AgregarUsuario(string Usuario, string Clave)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                return dc.AgregarUsuario(Usuario, Clave).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }
        public bool ActualizarUsuario(int IdUsuario, string Usuario, string Clave)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.ActualizarUsuario(IdUsuario, Usuario, Clave);
                return respuesta == 0;
            }
            catch
            {
                throw;
            }
        }
        public bool EliminarUsuario(int IdUsuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaUsuario(IdUsuario);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
