using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace Consola.Controllers
{
    [Authorize]
    public class InstitucionController : Controller
    {
        clsInstitucion institucion = new clsInstitucion();
        clsBitacora bitacora = new clsBitacora();
        // GET: Institucion
        public ActionResult Consultar()
        {
            string Cedula = Session["Cedula"].ToString();
            try
            {
                var resultado=institucion.ConsultarInstitucion();
                bitacora.AgregarBitacora("Institucion", "Consultar", "ConsultaExitosa", Cedula, 1);
                return View(resultado);
            }
            catch (Exception ex)
            {
                bitacora.AgregarBitacora("Institucion", "Consultar", ex.Message, Cedula,2);
                return View();
            }
            
        }
    }
}