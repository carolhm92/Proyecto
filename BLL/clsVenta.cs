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
        public bool AgregarVenta(string cedula, string identificacion, int? idProducto, int? idCita, DateTime? fecha, string tipo, double? impuesto, int? cantidad, double? total)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.AgregarVenta(cedula, identificacion, idProducto, idCita, fecha, tipo, impuesto, cantidad, total);
                return respuesta == 0;
            }
            catch
            {

                throw;
            }
        }
        public bool ActualizarVenta(int? IdVenta, string cedula, string identificacion, int? idProducto, int? idCita, DateTime? fecha, string tipo, double? impuesto, int? cantidad, double? total)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.ActualizarVenta(IdVenta, cedula, identificacion, idProducto, idCita, fecha, tipo, impuesto, cantidad, total);
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

        public List<ConsultarReporteVentasResult> ConsultaReporteVentas(DateTime fecha)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarReporteVentasResult> data = dc.ConsultarReporteVentas(fecha).ToList();
                return data;
            }
            catch
            {

                throw;
            }

        }
    }
}
