using BLL;
using Consola.Helpers;
using Consola.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Consola.Controllers
{
    [SessionManage]
    public class TipoIdentificacionController : Controller
    {
        clsBitacora bitacora = new clsBitacora();

        // GET: TipoIdentificacion
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            var response = await api.GetAsync("/api/TipoIdentificacion");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var tipoIdentificacions = JsonConvert.DeserializeObject<List<TipodeIdentificacion>>(datastring);
                return View(tipoIdentificacions);
            }
            bitacora.AgregarBitacora("TipoIdentificacion", "Index", "No se pudo obtener datos", Session["US"].ToString(), 2);
            return View(new List<TipodeIdentificacion>());
        }

        // GET: TipoIdentificacion/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/TipoIdentificacion/" + id);
            TipodeIdentificacion tipoIdentificacion = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                tipoIdentificacion = JsonConvert.DeserializeObject<TipodeIdentificacion>(datastring);
            }
            if (tipoIdentificacion == null)
            {
                bitacora.AgregarBitacora("TipoIdentificacion", "Details", "No existe", Session["US"].ToString(), 2);
                return View(new TipodeIdentificacion());
            }
            return View(tipoIdentificacion);
        }

        // GET: TipoIdentificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoIdentificacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TipodeIdentificacion tipodeIdentificacion)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PostAsync("/api/TipoIdentificacion", tipodeIdentificacion);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            bitacora.AgregarBitacora("TipoIdentificacion", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(tipodeIdentificacion);
        }

        // GET: TipoIdentificacion/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/TipoIdentificacion/" + id);
            TipodeIdentificacion tipoIdentificacion = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                tipoIdentificacion = JsonConvert.DeserializeObject<TipodeIdentificacion>(datastring);
            }
            if (tipoIdentificacion == null)
            {
                bitacora.AgregarBitacora("TipoIdentificacion", "Edit", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(tipoIdentificacion);
        }

        // POST: TipoIdentificacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TipodeIdentificacion tipodeIdentificacion)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/TipoIdentificacion/" + tipodeIdentificacion.IdTipoIdentificacion, tipodeIdentificacion);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            bitacora.AgregarBitacora("TipoIdentificacion", "Edit", "No se edito", Session["US"].ToString(), 2);
            return View(tipodeIdentificacion);
        }

        // GET: TipoIdentificacion/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/TipoIdentificacion/" + id);
            TipodeIdentificacion tipoIdentificacion = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                tipoIdentificacion = JsonConvert.DeserializeObject<TipodeIdentificacion>(datastring);
            }
            if (tipoIdentificacion == null)
            {
                bitacora.AgregarBitacora("TipoIdentificacion", "Delete", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(tipoIdentificacion);
        }

        // POST: TipoIdentificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/TipoIdentificacion/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("TipoIdentificacion", "Delete", "No se elimino", Session["US"].ToString(), 2);
            return HttpNotFound();
        }
    }
}
