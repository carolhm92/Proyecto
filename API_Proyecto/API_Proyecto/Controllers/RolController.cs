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
    [RoutePrefix("api/Rol")]
    public class RolController : ApiController
    {
        private clsRol db = new clsRol();

        // GET: api/Rol
        [Route("{idUsuario}")]
        [HttpGet]
        public IEnumerable<int> GetRolUsuario(int idUsuario)
        {
            return db.ConsultarRolUsuario(idUsuario).Select(rol => rol.IdRol).ToList();
        }

        // POST: api/Rol/{idUsuario}/{idRol}
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostRolUsuario(Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarRolUsuario(rol.IdUsuario, rol.IdRol))
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/Rol/5
        [Route("{id}")]
        [ResponseType(typeof(bool))]
        [HttpDelete]
        public IHttpActionResult DeleteRolUsuario(int id)
        {
            try
            {
                if (db.EliminarRolUsuario(id))
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