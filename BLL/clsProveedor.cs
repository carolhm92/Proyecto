using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsProveedor
    {
        public List<ConsultarProveedorResult> ConsultarProveedor()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarProveedorResult> data = dc.ConsultarProveedor().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaProveedorResult> ConsultaProveedor(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaProveedorResult> data = dc.ConsultaProveedor(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarProveedor(int IdProveedor, string nombreProveedor, char Provincia, string Canton, string Distrito, string correo,string telefono)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarProveedor(IdProveedor,nombreProveedor,Provincia,Canton,Distrito,correo,telefono));

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
        public bool ActualizarProveedor(int IdProveedor, string nombreProveedor, char Provincia, string Canton, string Distrito, string correo, string telefono)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarProveedor(IdProveedor, nombreProveedor, Provincia, Canton, Distrito, correo, telefono);
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
        public bool EliminarProveedor(int IdProveedor)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaCliente(IdProveedor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
