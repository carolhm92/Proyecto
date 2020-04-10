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
    public class ProductoController : ApiController
    {
        private clsProducto db = new clsProducto();

        // GET: api/Producto
        public IEnumerable<ConsultarProductoResult> GetProducto()
        {
            return db.ConsultarProducto();
        }

        // GET: api/Producto/5
        [ResponseType(typeof(ConsultaProductoResult))]
        public IHttpActionResult GetProducto(int id)
        {
            ConsultaProductoResult producto = db.ConsultaProducto(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/Producto/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutProducto(int id, Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.IdProducto)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarProducto(producto.IdProducto, producto.NombreProducto, producto.CostoProducto, producto.IdProveedor, producto.Cantidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/Producto
        [ResponseType(typeof(Producto))]
        public IHttpActionResult PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarProducto(producto.IdProducto, producto.NombreProducto, producto.CostoProducto, producto.IdProveedor, producto.Cantidad))
                    return Created(Url.Request.RequestUri, producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/Producto/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteProducto(int id)
        {
            try
            {
                if (db.EliminarProducto(id))
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