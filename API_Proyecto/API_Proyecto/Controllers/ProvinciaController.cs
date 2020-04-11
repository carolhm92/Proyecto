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
    public class ProvinciaController : ApiController
    {
        private clsInformacion db = new clsInformacion();

        // GET: api/Provincia
        public IEnumerable<ProvinciasResult> GetProvincia()
        {
            return db.ObtenerProvincias();
        }
    }
}