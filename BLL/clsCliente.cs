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
            catch 
            {
                throw;
            }

        }
        public ConsultaClienteResult ConsultaCliente(int Codigo) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaClienteResult data = dc.ConsultaCliente(Codigo).SingleOrDefault();
                return data;
            }
            catch 
            {

                throw;
            }

        }
        public bool AgregarCliente(int? IdTipoIdentificacion,string Identificacion, string Nombre, string Apellido1, string Apellido2, string Correo, string Telefono, char Provincia, string Canton, string Distrito) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.AgregarCliente(IdTipoIdentificacion, Identificacion, Nombre,Apellido1,Apellido2,Correo, Telefono, Provincia,Canton,Distrito);

                return respuesta == 0;
            }
            catch 
            {

                throw;
            }
        }
        public bool ActualizarCliente(int? IdCliente, int? IdTipoIdentificacion, string Nombre, string Apellido1, string Apellido2, string Correo, string Telefono, char Provincia, string Canton, string Distrito) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.ActualizarCliente(IdCliente, IdTipoIdentificacion, Nombre, Apellido1, Apellido2, Correo, Telefono, Provincia, Canton, Distrito);
                return respuesta == 0;
            }
            catch 
            {
                throw;
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
            catch 
            {
                throw;
            }
        }

    }
}
