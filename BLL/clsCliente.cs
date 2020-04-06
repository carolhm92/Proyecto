using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsCliente
    {
        public List<ConsultarClienteResult> ConsultarCliente()
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultarClienteResult> data = dc.ConsultarCliente().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaClienteResult> ConsultaCliente(int Codigo) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ConsultaClienteResult> data = dc.ConsultaCliente(Codigo).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarCliente(int IdTipoIdentificacion,string Identificacion, string Nombre, string Apellido1, string Apellido2, string Correo, string Telefono, char Provincia, string Canton, string Distrito, bool Estado) 
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.AgregarCliente(IdTipoIdentificacion, Identificacion, Nombre,Apellido1,Apellido2,Correo, Telefono, Provincia,Canton,Distrito,Estado));

                if (respuesta==0)
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
        public bool ActualizarCliente(int IdCliente, int IdTipoIdentificacion, string Identificacion, string Nombre, string Apellido1, string Apellido2, string Correo, string Telefono, char Provincia, string Canton, string Distrito, bool Estado) 
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarCliente(IdCliente, IdTipoIdentificacion, Identificacion, Nombre, Apellido1, Apellido2, Correo, Telefono, Provincia, Canton, Distrito, Estado);
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
        public bool EliminarCliente(int IdCliente)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.EliminaCliente(IdCliente);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
