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
    public class TipoIdentificacionController : ApiController
    {
        private clsTipoIdentificacion db = new clsTipoIdentificacion();

        // GET: api/TipoIdentificacion
        public IEnumerable<ConsultarTiposIdentificacionResult> GetTipoIdentificacion()
        {
            return db.ConsultarTipoIdentificacion();
        }

        // GET: api/TipoIdentificacion/5
        [ResponseType(typeof(ConsultaTiposIdentificacionResult))]
        public IHttpActionResult GetTipoIdentificacion(int id)
        {
            ConsultaTiposIdentificacionResult tipoIdentificacion = db.ConsultaTipoIdentificacion(id);
            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            return Ok(tipoIdentificacion);
        }

        // PUT: api/TipoIdentificacion/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutTipoIdentificacion(int id, TipoIdentificacion tipoIdentificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoIdentificacion.IdTipoIdentificacion)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarTipoIdentificacion(tipoIdentificacion.IdTipoIdentificacion, tipoIdentificacion.TipoIdentificacion1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/TipoIdentificacion
        [ResponseType(typeof(TipoIdentificacion))]
        public IHttpActionResult PostTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarTipoIdentificacion(tipoIdentificacion.TipoIdentificacion1))
                    return Created(Url.Request.RequestUri, tipoIdentificacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/TipoIdentificacion/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteTipoIdentificacion(int id)
        {
            try
            {
                if (db.EliminarTipoIdentificacion(id))
                    return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }
    }
}