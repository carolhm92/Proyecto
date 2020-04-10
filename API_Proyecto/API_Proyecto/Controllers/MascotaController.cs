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
    public class MascotaController : ApiController
    {
        private clsMascota db = new clsMascota();

        // GET: api/Mascota
        public IEnumerable<ConsultarMascotaResult> GetMascota()
        {
            return db.ConsultarMascota();
        }

        // GET: api/Mascota/5
        [ResponseType(typeof(ConsultaMascotaResult))]
        public IHttpActionResult GetMascota(int id)
        {
            ConsultaMascotaResult mascota = db.ConsultaMascota(id);
            if (mascota == null)
            {
                return NotFound();
            }

            return Ok(mascota);
        }

        // PUT: api/Mascota/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutMascota(int id, Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mascota.IdMascota)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarMascota(mascota.IdMascota,mascota.NombreMascota,mascota.Especie,mascota.Raza,mascota.IdCliente,mascota.Peso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/Mascota
        [ResponseType(typeof(Mascota))]
        public IHttpActionResult PostMascota(Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarMascota(mascota.Identificacion,mascota.NombreMascota, mascota.Especie, mascota.Raza, mascota.IdCliente, mascota.Peso))
                    return Created(Url.Request.RequestUri, mascota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/Mascota/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteMascota(int id)
        {
            try
            {
                if (db.EliminarMascota(id))
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