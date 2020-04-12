using API_Proyecto.Models;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Proyecto.Controllers
{
    [RoutePrefix("api/Reporte")]
    public class ReporteController : ApiController
    {
        private clsVenta db = new clsVenta();
        [Route("")]
        [HttpPost]
        public IEnumerable<ConsultarReporteVentasResult> GetReporte(ViewReporteBusqueda viewReporteBusqueda)
        {
            return db.ConsultaReporteVentas(viewReporteBusqueda.Fecha);
        }
    }
}
