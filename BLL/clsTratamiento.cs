using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsTratamiento
    {
        public List<ConsultarTratamientoResult> ConsultarTratamiento()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarTratamientoResult> data = dc.ConsultarTratamiento().ToList();
                return data;
            }
            catch 
            {
                throw;
            }

        }
        public ConsultaTratamientoResult ConsultaTratamiento(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaTratamientoResult data = dc.ConsultaTratamiento(Codigo).SingleOrDefault();
                return data;
            }
            catch 
            {

                throw;
            }

        }
        public bool AgregarTratamiento(string nombreTratamiento, double? costo, int? idMascota)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.AgregarTratamiento(nombreTratamiento,costo, idMascota);

                return respuesta == 0;
            }
            catch 
            {

                throw;
            }
        }
        public bool ActualizarTratamiento(int IdTratamiento, string nombreTratamiento, double costo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.ActualizarTratamiento(IdTratamiento, nombreTratamiento, costo);
                return respuesta == 0;
            }
            catch 
            {
                throw;
            }
        }
        public bool EliminarTratamiento(int IdTratamiento)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaTratamiento(IdTratamiento);
                return true;
            }
            catch 
            {
                throw;
            }
        }

    }
}
