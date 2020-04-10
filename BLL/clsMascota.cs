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
            catch
            {
                throw;
            }

        }
        public ConsultaMascotaResult ConsultaMascota(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaMascotaResult data = dc.ConsultaMascota(Codigo).SingleOrDefault();
                return data;
            }
            catch
            {

                throw;
            }

        }
        public bool AgregarMascota(string identificacion, string nombreMascota, string especie, string raza, int? idCliente,double? peso)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.AgregarMascota(identificacion,nombreMascota, especie,raza,idCliente,peso);
                return respuesta == 0;
            }
            catch
            {

                throw;
            }
        }
        public bool ActualizarMascota(int? IdMascota,string nombreMascota, string especie, string raza, int idCliente, double? peso)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.ActualizarMascota(IdMascota,nombreMascota, especie, raza, idCliente, peso);
                return respuesta == 0;
            }
            catch
            {
                throw;
            }
        }
        public bool EliminarMascota(int IdMascota)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaMascota(IdMascota);
                return true;
            }
            catch
            {
                throw;
            }
        }

    }
}
