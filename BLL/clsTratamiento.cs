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
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaTratamientoResult> ConsultaTratamiento(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaTratamientoResult> data = dc.ConsultaTratamiento(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarTratamiento(int IdTratamiento, string nombreTratamiento, double costo)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarTratamiento(IdTratamiento, nombreTratamiento,costo));

                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ActualizarTratamiento(int IdTratamiento, string nombreTratamiento, double costo)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarTratamiento(IdTratamiento, nombreTratamiento, costo);
                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EliminaTratamiento(int IdTratamiento)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaTratamiento(IdTratamiento);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
