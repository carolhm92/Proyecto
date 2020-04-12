using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsRol
    {

        public List<ConsultarRolUsuarioResult> ConsultarRolUsuario(int IdUsuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarRolUsuarioResult> data = dc.ConsultarRolUsuario(IdUsuario).ToList();
                return data;
            }
            catch
            {
                throw;
            }

        }
        public bool AgregarRolUsuario(int IdUsuario, int IdRol)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.AgregarRolUsuario(IdUsuario, IdRol);

                return respuesta == 0;
            }
            catch
            {

                throw;
            }
        }
        public bool EliminarRolUsuario(int IdUsuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminarRolUsuario(IdUsuario);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
