using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsMascota
    {
        public List<ConsultarMascotaResult> ConsultarMascota()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarMascotaResult> data = dc.ConsultarMascota().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaMascotaResult> ConsultaMascota(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaMascotaResult> data = dc.ConsultaMascota(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarMascota(string nombreMascota, string especie, string raza, int idCliente)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarMascota(nombreMascota,especie,raza,idCliente));

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
        public bool ActualizarMascota(int IdMascota,string nombreMascota, string especie, string raza, int idCliente)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarMascota(IdMascota,nombreMascota, especie, raza, idCliente);
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
        public bool EliminaMascota(int IdMascota)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaMascota(IdMascota);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
