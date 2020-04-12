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
    public class VentaController : ApiController
    {
        private clsVenta db = new clsVenta();

        // GET: api/Venta
        public IEnumerable<ConsultarVentaResult> GetVenta()
        {
            return db.ConsultarVenta();
        }

        // GET: api/Venta/5
        [ResponseType(typeof(ConsultaVentaResult))]
        public IHttpActionResult GetVenta(int id)
        {
            ConsultaVentaResult venta = db.ConsultaVenta(id);
            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        // PUT: api/Venta/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutVenta(int id, Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venta.IdVenta)
            {
                return BadRequest();
            }
            bool result;
            try
            {
                result = db.ActualizarVenta(venta.IdVenta, venta.Cedula, venta.Identificacion, venta.IdProducto, venta.IdCita, venta.Fecha, venta.Total);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // POST: api/Venta
        [ResponseType(typeof(Venta))]
        public IHttpActionResult PostVenta(Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (db.AgregarVenta(venta.Cedula, venta.Identificacion, venta.IdProducto, venta.IdCita, venta.Fecha, venta.Total))
                    return Created(Url.Request.RequestUri, venta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound();
        }

        // DELETE: api/Venta/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteVenta(int id)
        {
            try
            {
                if (db.EliminarVenta(id))
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