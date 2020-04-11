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
    [RoutePrefix("api/Distrito")]
    public class DistritoController : ApiController
    {
        private clsInformacion db = new clsInformacion();

        // GET: api/Distrito
        [Route("")]
        public IEnumerable<ConsultarDistritosResult> GetDistrito()
        {
            return db.ObtenerDistritos();
        }

        [Route("{provincia}/{canton}")]
        // GET: api/Distrito/{provincia}/{canton}
        public IEnumerable<DistritosResult> GetDistrito(char provincia, string canton)
        {
            return db.ObtenerDistritos(provincia, canton);
        }
    }
}