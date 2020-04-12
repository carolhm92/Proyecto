using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Consola.Models;
using System.Text.RegularExpressions;
using DAL;
using Consola.Tools;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Consola.Helpers;

namespace Consola.Controllers
{
    [SessionManage]
    public class TratamientoController : Controller
    {
        clsBitacora bitacora = new clsBitacora();

        // GET: Tratamiento
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            var response = await api.GetAsync("/api/Tratamiento");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var tratamientos = JsonConvert.DeserializeObject<List<Tratamiento>>(datastring).FindAll(c => c.Estado);
                return View(tratamientos);
            }
            bitacora.AgregarBitacora("Tratamiento", "Index", "No se pudo obtener datos", Session["US"].ToString(), 2);
            return View(new List<Tratamiento>());
        }

        // GET: Tratamiento/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Tratamiento/" + id);
            Tratamiento tratamiento = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                tratamiento = JsonConvert.DeserializeObject<Tratamiento>(datastring);
            }
            if (tratamiento == null)
            {
                bitacora.AgregarBitacora("Tratamiento", "Details", "No existe", Session["US"].ToString(), 2);
                return View(new Tratamiento());
            }
            return View(tratamiento);
        }

        // GET: Tratamiento/Create
        public async Task<ActionResult> Create()
        {
            await ObtenerMascotas();
            return View();
        }

        // POST: Tratamiento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tratamiento tratamiento)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PostAsync("/api/Tratamiento", tratamiento);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerMascotas();
            bitacora.AgregarBitacora("Tratamiento", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(tratamiento);
        }

        // GET: Tratamiento/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Tratamiento/" + id);
            Tratamiento tratamiento = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                tratamiento = JsonConvert.DeserializeObject<Tratamiento>(datastring);
            }
            if (tratamiento == null)
            {
                bitacora.AgregarBitacora("Tratamiento", "Edit", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            await ObtenerMascotas();
            return View(tratamiento);
        }

        // POST: Tratamiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Tratamiento tratamiento)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/Tratamiento/" + tratamiento.IdTratamiento, tratamiento);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerMascotas();
            bitacora.AgregarBitacora("Tratamiento", "Edit", "No se edito", Session["US"].ToString(), 2);
            return View(tratamiento);
        }

        // GET: Tratamiento/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Tratamiento/" + id);
            Tratamiento tratamiento = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                tratamiento = JsonConvert.DeserializeObject<Tratamiento>(datastring);
            }
            if (tratamiento == null)
            {
                bitacora.AgregarBitacora("Tratamiento", "Delete", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/Tratamiento/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("Tratamiento", "Delete", "No se elimino", Session["US"].ToString(), 2);
            return HttpNotFound();
        }

        private async Task<List<Mascota>> ObtenerMascotas()
        {
            ApiCall api = new ApiCall(Session);
            List<Mascota> mascotas = new List<Mascota>();
            var resultclient = await api.GetAsync("/api/Mascota");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                mascotas = JsonConvert.DeserializeObject<List<Mascota>>(datastring);
            }
            ViewBag.Mascotas = new SelectList(mascotas.FindAll(c => c.Estado), "IdMascota", "NombreMascota");
            return mascotas;
        }
    }
}
