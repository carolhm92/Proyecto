using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsProducto
    {
        public List<ConsultarProductoResult> ConsultarProducto()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarProductoResult> data = dc.ConsultarProducto().ToList();
                return data;
            }
            catch 
            {
                throw;
            }

        }
        public ConsultaProductoResult ConsultaProducto(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaProductoResult data = dc.ConsultaProducto(Codigo).SingleOrDefault();
                return data;
            }
            catch
            {

                throw;
            }

        }
        public bool AgregarProducto(int idProducto, string nombreProducto, double costoProducto, int idProveedor, int cantidad)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = Convert.ToInt32(dc.AgregarProducto(idProducto,nombreProducto,costoProducto,idProveedor,cantidad));

                return respuesta == 0;
            }
            catch
            {

                throw;
            }
        }
        public bool ActualizarProducto(int IdProducto, string nombreProducto, double costoProducto, int idProveedor, int cantidad)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.ActualizarProducto(IdProducto, nombreProducto, costoProducto, idProveedor, cantidad);
                return respuesta == 0;
            }
            catch 
            {
                throw;
            }
        }
        public bool EliminarProducto(int IdProducto)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaProducto(IdProducto);
                return true;
            }
            catch 
            {
                throw;
            }
        }

    }
}
