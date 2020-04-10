using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsPersona
    {
        public ConsultaPersonaResult ConsultaPersona(string Cedula) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                ConsultaPersonaResult data = dc.ConsultaPersona(Cedula).SingleOrDefault();
                return data;
            }
            catch
            {

                throw;
            }
 
        }
        public bool AgregarPersona(string Cedula,int Sexo, string Nombre, string ApellidoP,string ApellidoM,string Direccion) 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                dc.AgregarPersona(Cedula, Sexo, Nombre, ApellidoP, ApellidoM, Direccion);
                return true;
            }
            catch 
            {

                throw;
            }
        }
    }
}
