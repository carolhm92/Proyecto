using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsTipoIdentificacion
    {
        public List<ConsultarTiposIdentificacionResult> ConsultarTipoIdentificacion()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarTiposIdentificacionResult> data = dc.ConsultarTiposIdentificacion().ToList();
                return data;
            }
            catch 
            {
                throw;
            }

        }
        public ConsultaTiposIdentificacionResult ConsultaTipoIdentificacion(int Codigo) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaTiposIdentificacionResult data = dc.ConsultaTiposIdentificacion(Codigo).SingleOrDefault();
                return data;
            }
            catch 
            {

                throw;
            }

        }
        public bool AgregarTipoIdentificacion(string TipoIdentificacion) 
        {
            try
            {
                int respuesta = -1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.AgregarTipoIdentificacion(TipoIdentificacion);
                return respuesta == -1;
            }
            catch 
            {

                throw;
            }
        }
        public bool ActualizarTipoIdentificacion(int IdTipoIdentificacion,string TipoIdentificacion) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.ActualizarTipoIdentificacion(IdTipoIdentificacion, TipoIdentificacion);
                return true;
            }
            catch 
            {
                throw;
            }
        }
        public bool EliminarTipoIdentificacion(int IdTipoIdentificacion)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaTiposIdentificacion(IdTipoIdentificacion);
                return true;
            }
            catch 
            {
                throw;
            }
        }

    }
}
