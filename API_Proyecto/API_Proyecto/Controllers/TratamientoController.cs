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
        //private ProyectoCarolEntities db = new ProyectoCarolEntities();

        //// GET: api/Tratamiento
        //public IQueryable<Tratamiento> GetTratamiento()
        //{
        //    return db.Tratamiento;
        //}

        //// GET: api/Tratamiento/5
        //[ResponseType(typeof(Tratamiento))]
        //public IHttpActionResult GetTratamiento(int id)
        //{
        //    Tratamiento tratamiento = db.Tratamiento.Find(id);
        //    if (tratamiento == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tratamiento);
        //}

        //// PUT: api/Tratamiento/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTratamiento(int id, Tratamiento tratamiento)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tratamiento.IdTratamiento)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tratamiento).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TratamientoExists(id))
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

        //// POST: api/Tratamiento
        //[ResponseType(typeof(Tratamiento))]
        //public IHttpActionResult PostTratamiento(Tratamiento tratamiento)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Tratamiento.Add(tratamiento);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (TratamientoExists(tratamiento.IdTratamiento))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = tratamiento.IdTratamiento }, tratamiento);
        //}

        //// DELETE: api/Tratamiento/5
        //[ResponseType(typeof(Tratamiento))]
        //public IHttpActionResult DeleteTratamiento(int id)
        //{
        //    Tratamiento tratamiento = db.Tratamiento.Find(id);
        //    if (tratamiento == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Tratamiento.Remove(tratamiento);
        //    db.SaveChanges();

        //    return Ok(tratamiento);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool TratamientoExists(int id)
        //{
        //    return db.Tratamiento.Count(e => e.IdTratamiento == id) > 0;
        //}
    }
}