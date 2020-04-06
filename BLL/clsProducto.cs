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
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaProductoResult> ConsultaProducto(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaProductoResult> data = dc.ConsultaProducto(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarProducto(int idProducto, string nombreProducto, double costoProducto, int idProveedor, int cantidad)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarProducto(idProducto,nombreProducto,costoProducto,idProveedor,cantidad));

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
        public bool ActualizarProducto(int IdProducto, string nombreProducto, double costoProducto, int idProveedor, int cantidad)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarProducto(IdProducto, nombreProducto, costoProducto, idProveedor, cantidad);
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
        public bool EliminarProducto(int IdProducto)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaCliente(IdProducto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
