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
    public class ProveedorController : ApiController
    {
        private clsProveedor db = new clsProveedor();

        // GET: api/Proveedor
        public IEnumerable<ConsultarProveedorResult> GetProveedor()
        {
            return db.ConsultarProveedor();
        }

        // GET: api/Proveedor/5
        [ResponseType(typeof(ConsultaProveedorResult))]
        public IHttpActionResult GetProveedor(int id)
        {
            ConsultaProveedorResult proveedor = db.ConsultaProveedor(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // PUT: api/Proveedor/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutProveedor(int id, Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedor.IdProveedor)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarProveedor(proveedor.IdProveedor, proveedor.NombreProveedor, proveedor.Provincia, proveedor.Canton, proveedor.Distrito, proveedor.Correo, proveedor.Telefono);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/Proveedor
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult PostProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarProveedor(proveedor.NombreProveedor, proveedor.Provincia, proveedor.Canton, proveedor.Distrito, proveedor.Correo, proveedor.Telefono))
                    return Created(Url.Request.RequestUri, proveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/Proveedor/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteProveedor(int id)
        {
            try
            {
                if (db.EliminarProveedor(id))
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