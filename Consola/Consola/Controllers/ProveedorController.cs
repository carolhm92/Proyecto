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
    public class ProveedorController : Controller
    {
        clsBitacora bitacora = new clsBitacora();

        // GET: Proveedor
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            var response = await api.GetAsync("/api/Proveedor");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var proveedors = JsonConvert.DeserializeObject<List<Proveedor>>(datastring).FindAll(c => c.Estado);
                proveedors = await LLenarDatos(proveedors);
                return View(proveedors);
            }
            bitacora.AgregarBitacora("Proveedor", "Index", "No se pudo obtener datos", Session["US"].ToString(), 2);
            return View(new List<Proveedor>());
        }

        // GET: Proveedor/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Proveedor/" + id);
            Proveedor proveedor = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                proveedor = JsonConvert.DeserializeObject<Proveedor>(datastring);
                List<Proveedor> proveedors = await LLenarDatos(new List<Proveedor>() { proveedor });
                proveedor = proveedors.First();
            }
            if (proveedor == null)
            {
                bitacora.AgregarBitacora("Proveedor", "Details", "No existe", Session["US"].ToString(), 2);
                return View(new Proveedor());
            }
            return View(proveedor);
        }

        // GET: Proveedor/Create
        public async Task<ActionResult> Create()
        {
            await ObtenerProvincias();
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Proveedor proveedor)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PostAsync("/api/Proveedor", proveedor);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerProvincias();
            bitacora.AgregarBitacora("Proveedor", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(proveedor);
        }

        // GET: Proveedor/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Proveedor/" + id);
            Proveedor proveedor = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                proveedor = JsonConvert.DeserializeObject<Proveedor>(datastring);
            }
            if (proveedor == null)
            {
                bitacora.AgregarBitacora("Proveedor", "Edit", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            await ObtenerProvincias();
            var cantones = await ObtenerCantones(proveedor.Provincia);
            var distritos = await ObtenerDistritos(proveedor.Provincia, proveedor.Canton);
            ViewBag.Cantones = new SelectList(cantones, "Canton", "Nombre");
            ViewBag.Distritos = new SelectList(distritos, "Distrito", "Nombre");
            return View(proveedor);
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Proveedor proveedor)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/Proveedor/" + proveedor.IdProveedor, proveedor);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerProvincias();
            var cantones = await ObtenerCantones(proveedor.Provincia);
            var distritos = await ObtenerDistritos(proveedor.Provincia, proveedor.Canton);
            ViewBag.Cantones = new SelectList(cantones, "Canton", "Nombre");
            ViewBag.Distritos = new SelectList(distritos, "Distrito", "Nombre");
            bitacora.AgregarBitacora("Proveedor", "Edit", "No se edito", Session["US"].ToString(), 2);
            return View(proveedor);
        }

        // GET: Proveedor/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Proveedor/" + id);
            Proveedor proveedor = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                proveedor = JsonConvert.DeserializeObject<Proveedor>(datastring);
            }
            if (proveedor == null)
            {
                bitacora.AgregarBitacora("Proveedor", "Delete", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            List<Proveedor> proveedors = await LLenarDatos(new List<Proveedor>() { proveedor });
            proveedor = proveedors.First();
            return View(proveedor);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/Proveedor/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("Proveedor", "Delete", "No se elimino", Session["US"].ToString(), 2);
            return HttpNotFound();
        }

        private async Task<List<Provincia>> ObtenerProvincias()
        {
            ApiCall api = new ApiCall(Session);
            List<Provincia> provincias = new List<Provincia>();
            var resultclient = await api.GetAsync("/api/Provincia");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                provincias = JsonConvert.DeserializeObject<List<Provincia>>(datastring);
            }
            var provinciastemporal = new List<Provincia>(provincias);
            provinciastemporal.Insert(0, new Provincia { Cod = '0', Nombre = "--Seleccione--" });
            ViewBag.Provincias = new SelectList(provinciastemporal, "Cod", "Nombre");
            return provincias;
        }

        private async Task<List<Cantones>> ObtenerCantones(char provincia)
        {
            ApiCall api = new ApiCall(Session);
            List<Cantones> cantones = new List<Cantones>();
            var resultclient = await api.GetAsync("/api/Canton/" + provincia);
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                cantones = JsonConvert.DeserializeObject<List<Cantones>>(datastring);
            }
            return cantones;
        }

        private async Task<List<Cantones>> ObtenerCantones()
        {
            ApiCall api = new ApiCall(Session);
            List<Cantones> cantones = new List<Cantones>();
            var resultclient = await api.GetAsync("/api/Canton");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                cantones = JsonConvert.DeserializeObject<List<Cantones>>(datastring);
            }
            return cantones;
        }

        private async Task<List<Distritos>> ObtenerDistritos()
        {
            ApiCall api = new ApiCall(Session);
            List<Distritos> distritos = new List<Distritos>();
            var resultclient = await api.GetAsync("/api/Distrito");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                distritos = JsonConvert.DeserializeObject<List<Distritos>>(datastring);
            }
            return distritos;
        }

        private async Task<List<Distritos>> ObtenerDistritos(char provincia, string canton)
        {
            ApiCall api = new ApiCall(Session);
            List<Distritos> distritos = new List<Distritos>();
            var resultclient = await api.GetAsync("/api/Distrito/" + provincia + "/" + canton);
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                distritos = JsonConvert.DeserializeObject<List<Distritos>>(datastring);
            }
            return distritos;
        }

        [HttpPost]
        public async Task<JsonResult> CargaCantones(char provincia)
        {
            var cantones = await ObtenerCantones(provincia);
            return Json(cantones);
        }

        [HttpPost]
        public async Task<JsonResult> CargaDistritos(char provincia, string canton)
        {
            var distritos = await ObtenerDistritos(provincia, canton);
            return Json(distritos);
        }

        public async Task<List<Proveedor>> LLenarDatos(List<Proveedor> proveedores)
        {
            var provincias = await ObtenerProvincias();
            var cantones = await ObtenerCantones();
            var distritos = await ObtenerDistritos();
            proveedores.ForEach(proveedor =>
            {
                proveedor.Canton_Nombre = cantones.First(c => c.Canton.Equals(proveedor.Canton)).Nombre;
                proveedor.Distrito_Nombre = distritos.First(d => d.Distrito.Equals(proveedor.Distrito)).Nombre;
                proveedor.Provincia_Nombre = provincias.First(p => p.Cod.Equals(proveedor.Provincia)).Nombre;
            });
            return proveedores;
        }
    }
}
