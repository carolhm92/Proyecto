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
    public class UsuarioController : ApiController
    {
        private clsUsuario db = new clsUsuario();

        // GET: api/Usuario
        public IEnumerable<ConsultarUsuarioResult> GetUsuario()
        {
            return db.ConsultarUsuario();
        }

        // GET: api/Usuario/5
        [ResponseType(typeof(ExisteUsuarioResult))]
        public IHttpActionResult GetUsuario(int id)
        {
            ExisteUsuarioResult usuario = new ExisteUsuarioResult();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuario/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutUsuario(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.IdUsuario)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarUsuario(user.IdUsuario, user.Usuario, user.Clave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/Usuario
        [ResponseType(typeof(AgregarUsuarioResult))]
        public IHttpActionResult PostUsuario(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var usuario = db.AgregarUsuario(user.Usuario, user.Clave);
                return Created(Url.Request.RequestUri, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Usuario/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            try
            {
                if (db.EliminarUsuario(id))
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