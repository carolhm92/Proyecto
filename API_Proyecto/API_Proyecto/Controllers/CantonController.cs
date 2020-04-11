using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_Proyecto.Models;
using BLL;
using DAL;

namespace API_Proyecto.Controllers
{
    [Authorize]
    [RoutePrefix("api/Canton")]
    public class CantonController : ApiController
    {
        private clsInformacion db = new clsInformacion();
        // GET: api/Canton
        [Route("")]
        public IEnumerable<ConsultarCantonesResult> GetCanton()
        {
            return db.ObtenerCantones();
        }
        [Route("{provincia}")]
        // GET: api/Canton/{provincia}
        [ResponseType(typeof(IEnumerable<CantonesResult>))]
        public IHttpActionResult GetCanton(char provincia)
        {
            var cantones = db.ObtenerCantones(provincia);
            if (cantones == null)
            {
                return NotFound();
            }

            return Ok(cantones);
        }
    }
}