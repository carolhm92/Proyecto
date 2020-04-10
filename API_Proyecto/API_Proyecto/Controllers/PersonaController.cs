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
    public class PersonaController : ApiController
    {
        //private ProyectoCarolEntities db = new ProyectoCarolEntities();

        //// GET: api/Persona
        //public IQueryable<Persona> GetPersona()
        //{
        //    return db.Persona;
        //}

        //// GET: api/Persona/5
        //[ResponseType(typeof(Persona))]
        //public IHttpActionResult GetPersona(string id)
        //{
        //    Persona persona = db.Persona.Find(id);
        //    if (persona == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(persona);
        //}

        //// PUT: api/Persona/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPersona(string id, Persona persona)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != persona.Cedula)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(persona).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PersonaExists(id))
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

        //// POST: api/Persona
        //[ResponseType(typeof(Persona))]
        //public IHttpActionResult PostPersona(Persona persona)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Persona.Add(persona);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PersonaExists(persona.Cedula))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = persona.Cedula }, persona);
        //}

        //// DELETE: api/Persona/5
        //[ResponseType(typeof(Persona))]
        //public IHttpActionResult DeletePersona(string id)
        //{
        //    Persona persona = db.Persona.Find(id);
        //    if (persona == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Persona.Remove(persona);
        //    db.SaveChanges();

        //    return Ok(persona);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PersonaExists(string id)
        //{
        //    return db.Persona.Count(e => e.Cedula == id) > 0;
        //}
    }
}