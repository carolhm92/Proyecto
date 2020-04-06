using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsInstitucion
    {
        public List<ConsultarInstitucionResult> ConsultarInstitucion()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarInstitucionResult> data = dc.ConsultarInstitucion().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaInstitucionResult> ConsultaInstitucion(int Codigo) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaInstitucionResult> data = dc.ConsultaInstitucion(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public int AgregarInstitucion(int IdInstitucion, string Institucion,int IdTipoIdentificacion, string Identificacion,string Telefono, string Direccion) 
        {
            try
            {
                int respuesta = 0;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarInstitucion(IdInstitucion, Institucion, IdTipoIdentificacion, Identificacion, Telefono, Direccion));

                return respuesta;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ActualizarInstitucion(int IdInstitucion, string Institucion, int IdTipoIdentificacion, string Identificacion, string Telefono, string Direccion) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.ActualizarInstitucion(IdInstitucion, Institucion, IdTipoIdentificacion, Identificacion, Telefono, Direccion);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EliminarInstitucion(int IdInstitucion)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaInstitucion(IdInstitucion);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
