using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsBitacora
    {
        public int AgregarBitacora(string Controlador,string Metodo,string Mensaje,string Usuario,int Tipo)
        {
            try
            {
                int respuesta = 0;
                DatosDataContext dc = new DatosDataContext();
                respuesta = Convert.ToInt32(dc.RegistrarBitacora(Controlador, Metodo, Mensaje, Usuario,Tipo));

                return respuesta;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
