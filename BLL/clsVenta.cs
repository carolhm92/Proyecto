using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsVenta
    {
        public List<ConsultarVentaResult> ConsultarVenta()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarVentaResult> data = dc.ConsultarVenta().ToList();
                return data;
            }
            catch
            {
                throw;
            }

        }
        public ConsultaVentaResult ConsultaVenta(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaVentaResult data = dc.ConsultaVenta(Codigo).SingleOrDefault();
                return data;
            }
            catch
            {

                throw;
            }

        }
        public bool AgregarVenta(string cedula, string identificacion, int? idProducto, int? idCita, DateTime? fecha, double? total)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.AgregarVenta(cedula,identificacion,idProducto, idCita,fecha,total);
                return respuesta == 0;
            }
            catch
            {

                throw;
            }
        }
        public bool ActualizarVenta(int? IdVenta, string cedula, string identificacion, int? idProducto, int? idCita, DateTime? fecha, double? total)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.ActualizarVenta(IdVenta, cedula, identificacion, idProducto, idCita, fecha, total);
                return respuesta == 0;
            }
            catch
            {
                throw;
            }
        }
        public bool EliminarVenta(int IdVenta)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaVenta(IdVenta);
                return true;
            }
            catch
            {
                throw;
            }
        }

    }
}
