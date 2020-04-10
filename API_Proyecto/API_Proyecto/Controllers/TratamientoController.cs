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
    public class TratamientoController : ApiController
    {
        private clsTratamiento db = new clsTratamiento();

        // GET: api/Tratamiento
        public IEnumerable<ConsultarTratamientoResult> GetTratamiento()
        {
            return db.ConsultarTratamiento();
        }

        // GET: api/Tratamiento/5
        [ResponseType(typeof(ConsultaTratamientoResult))]
        public IHttpActionResult GetTratamiento(int id)
        {
            ConsultaTratamientoResult tratamiento = db.ConsultaTratamiento(id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            return Ok(tratamiento);
        }

        // PUT: api/Tratamiento/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutTratamiento(int id, Tratamiento tratamiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tratamiento.IdTratamiento)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarTratamiento(tratamiento.IdTratamiento, tratamiento.NombreTratamiento, tratamiento.Costo.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/Tratamiento
        [ResponseType(typeof(Tratamiento))]
        public IHttpActionResult PostTratamiento(Tratamiento tratamiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarTratamiento(tratamiento.NombreTratamiento, tratamiento.Costo, tratamiento.IdMascota))
                    return Created(Url.Request.RequestUri, tratamiento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/Tratamiento/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteTratamiento(int id)
        {
            try
            {
                if (db.EliminarTratamiento(id))
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