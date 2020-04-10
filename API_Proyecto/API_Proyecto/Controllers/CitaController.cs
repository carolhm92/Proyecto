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
    public class CitaController : ApiController
    {
        //private ProyectoCarolEntities db = new ProyectoCarolEntities();

        //// GET: api/Cita
        //public IQueryable<Cita> GetCita()
        //{
        //    return db.Cita;
        //}

        //// GET: api/Cita/5
        //[ResponseType(typeof(Cita))]
        //public IHttpActionResult GetCita(int id)
        //{
        //    Cita cita = db.Cita.Find(id);
        //    if (cita == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cita);
        //}

        //// PUT: api/Cita/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCita(int id, Cita cita)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != cita.IdCita)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(cita).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CitaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Cita
        //[ResponseType(typeof(Cita))]
        //public IHttpActionResult PostCita(Cita cita)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Cita.Add(cita);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CitaExists(cita.IdCita))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = cita.IdCita }, cita);
        //}

        //// DELETE: api/Cita/5
        //[ResponseType(typeof(Cita))]
        //public IHttpActionResult DeleteCita(int id)
        //{
        //    Cita cita = db.Cita.Find(id);
        //    if (cita == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Cita.Remove(cita);
        //    db.SaveChanges();

        //    return Ok(cita);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CitaExists(int id)
        //{
        //    return db.Cita.Count(e => e.IdCita == id) > 0;
        //}
    }
}