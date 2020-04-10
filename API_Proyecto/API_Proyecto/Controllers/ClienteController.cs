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
    public class ClienteController : ApiController
    {
        private clsCliente db = new clsCliente();

        // GET: api/Cliente
        public IEnumerable<ConsultarClienteResult> GetCliente()
        {
            return db.ConsultarCliente();
        }

        // GET: api/Cliente/5
        [ResponseType(typeof(ConsultaClienteResult))]
        public IHttpActionResult GetCliente(int id)
        {
            ConsultaClienteResult cliente = db.ConsultaCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Cliente/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarCliente(cliente.IdCliente, cliente.IdTipoIdentificacion, cliente.Nombre, cliente.Apellido1, cliente.Apellido2, cliente.Correo, cliente.Telefono, cliente.Provincia, cliente.Canton, cliente.Distrito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/Cliente
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarCliente(cliente.IdTipoIdentificacion, cliente.Identificacion, cliente.Nombre, cliente.Apellido1, cliente.Apellido2, cliente.Correo, cliente.Telefono, cliente.Provincia, cliente.Canton, cliente.Distrito))
                    return Created(Url.Request.RequestUri, cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/Cliente/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteCliente(int id)
        {
            try
            {
                if (db.EliminarCliente(id))
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