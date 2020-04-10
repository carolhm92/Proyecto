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
            catch 
            {
                throw;
            }

        }
        public ConsultaProveedorResult ConsultaProveedor(int Codigo)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaProveedorResult data = dc.ConsultaProveedor(Codigo).SingleOrDefault();
                return data;
            }
            catch 
            {

                throw;
            }

        }
        public bool AgregarProveedor(int IdProveedor, string nombreProveedor, char Provincia, string Canton, string Distrito, string correo,string telefono)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = Convert.ToInt32(dc.AgregarProveedor(IdProveedor,nombreProveedor,Provincia,Canton,Distrito,correo,telefono));

                return respuesta == 0;
            }
            catch 
            {

                throw;
            }
        }
        public bool ActualizarProveedor(int IdProveedor, string nombreProveedor, char Provincia, string Canton, string Distrito, string correo, string telefono)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                int respuesta = dc.ActualizarProveedor(IdProveedor, nombreProveedor, Provincia, Canton, Distrito, correo, telefono);
                return respuesta == 0;
            }
            catch 
            {
                throw;
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
            catch 
            {
                throw;
            }
        }

    }
}
