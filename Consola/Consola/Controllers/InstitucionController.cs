using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Consola.Models;
using Consola.Helpers;
using BLL;
using Newtonsoft.Json;

namespace Consola.Controllers
{
    [SessionManage]
    public class InstitucionController : Controller
    {
        clsBitacora bitacora = new clsBitacora();

        // GET: Institucion
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            var response = await api.GetAsync("/api/Institucion");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var instituciones = JsonConvert.DeserializeObject<List<Instituciones>>(datastring).FindAll(c => c.Estado);
                instituciones = await LlenarData(instituciones);
                return View(instituciones);
            }
            bitacora.AgregarBitacora("Institucion", "Index", "No se pudo obtener datos", Session["US"].ToString(), 2);
            return View(new List<Instituciones>());
        }

        // GET: Institucion/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Institucion/" + id);
            Instituciones institucion = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                institucion = JsonConvert.DeserializeObject<Instituciones>(datastring);
                var instituciones = await LlenarData(new List<Instituciones> { institucion });
                institucion = instituciones.First();
            }
            if (institucion == null)
            {
                bitacora.AgregarBitacora("Institucion", "Details", "No existe", Session["US"].ToString(), 2);
                return View(new Instituciones());
            }
            return View(institucion);
        }

        // GET: Institucion/Create
        public async Task<ActionResult> Create()
        {
            await ObtenerTiposdeIdentificacion();
            return View();
        }

        // POST: Institucion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Instituciones instituciones)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PostAsync("/api/Institucion", instituciones);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerTiposdeIdentificacion();
            bitacora.AgregarBitacora("Institucion", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(instituciones);
        }

        // GET: Institucion/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Institucion/" + id);
            Instituciones institucion = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                institucion = JsonConvert.DeserializeObject<Instituciones>(datastring);
            }
            if (institucion == null)
            {
                bitacora.AgregarBitacora("Institucion", "Edit", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            await ObtenerTiposdeIdentificacion();
            return View(institucion);
        }

        // POST: Institucion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Instituciones instituciones)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/Institucion/" + instituciones.IdInstitucion, instituciones);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerTiposdeIdentificacion();
            bitacora.AgregarBitacora("Institucion", "Edit", "No se edito", Session["US"].ToString(), 2);
            return View(instituciones);
        }

        // GET: Institucion/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Institucion/" + id);
            Instituciones institucion = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                institucion = JsonConvert.DeserializeObject<Instituciones>(datastring);
                var instituciones = await LlenarData(new List<Instituciones> { institucion });
                institucion = instituciones.First();
            }
            if (institucion == null)
            {
                bitacora.AgregarBitacora("Institucion", "Delete", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(institucion);
        }

        // POST: Institucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/Institucion/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("Institucion", "Delete", "No se elimino", Session["US"].ToString(), 2);
            return HttpNotFound();
        }

        private async Task<List<TipodeIdentificacion>> ObtenerTiposdeIdentificacion()
        {
            ApiCall api = new ApiCall(Session);
            List<TipodeIdentificacion> tipos = new List<TipodeIdentificacion>();
            var resultclient = await api.GetAsync("/api/TipoIdentificacion");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                tipos = JsonConvert.DeserializeObject<List<TipodeIdentificacion>>(datastring);
            }
            ViewBag.TiposIdentificaciones = new SelectList(tipos.FindAll(c => c.Estado), "IdTipoIdentificacion", "TipoIdentificacion");
            return tipos;
        }

        private async Task<List<Instituciones>> LlenarData(List<Instituciones> instituciones)
        {
            var tipos = await ObtenerTiposdeIdentificacion();
            instituciones.ForEach(
                institucion => institucion.TipoIdentificacion_Nombre = 
                tipos.First(tipo => tipo.IdTipoIdentificacion == institucion.IdTipoIdentitifcacion).TipoIdentificacion);
            return instituciones;
        }
    }
}
