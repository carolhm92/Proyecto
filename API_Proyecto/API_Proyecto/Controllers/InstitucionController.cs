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
    public class InstitucionController : ApiController
    {
        private clsInstitucion db = new clsInstitucion();

        // GET: api/Institucion
        public IEnumerable<ConsultarInstitucionResult> GetInstitucion()
        {
            return db.ConsultarInstitucion();
        }

        // GET: api/Institucion/5
        [ResponseType(typeof(ConsultaInstitucionResult))]
        public IHttpActionResult GetInstitucion(int id)
        {
            ConsultaInstitucionResult institucion = db.ConsultaInstitucion(id);
            if (institucion == null)
            {
                return NotFound();
            }

            return Ok(institucion);
        }

        // PUT: api/Institucion/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutInstitucion(int id, Institucion institucion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != institucion.IdInstitucion)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarInstitucion(institucion.IdInstitucion, institucion.Institucion1, institucion.IdTipoIdentitifcacion, institucion.Identificacion, institucion.Telefono, institucion.Direccion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/Institucion
        [ResponseType(typeof(Institucion))]
        public IHttpActionResult PostInstitucion(Institucion institucion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarInstitucion(institucion.IdInstitucion, institucion.Institucion1, institucion.IdTipoIdentitifcacion, institucion.Identificacion, institucion.Telefono, institucion.Direccion))
                    return Created(Url.Request.RequestUri, institucion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/Institucion/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteInstitucion(int id)
        {
            try
            {
                if (db.EliminarInstitucion(id))
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