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
            catch 
            {
                throw;
            }

        }
        public ConsultaInstitucionResult ConsultaInstitucion(int Codigo) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaInstitucionResult data = dc.ConsultaInstitucion(Codigo).SingleOrDefault();
                return data;
            }
            catch 
            {

                throw;
            }

        }
        public bool AgregarInstitucion(string Institucion,int IdTipoIdentificacion, string Identificacion,string Telefono, string Direccion) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.AgregarInstitucion(Institucion, IdTipoIdentificacion, Identificacion, Telefono, Direccion);
                return true;
            }
            catch 
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
            catch 
            {
                throw;
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
            catch 
            {
                throw;
            }
        }

    }
}
