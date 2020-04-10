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
    public class MascotaController : Controller
    {
        clsBitacora bitacora = new clsBitacora();
        // GET: Mascota
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            try
            {
                var response = await api.GetAsync("/api/Mascota");
                if (response.IsSuccessStatusCode)
                {
                    var datastring = await response.Content.ReadAsStringAsync();
                    var mascotas = JsonConvert.DeserializeObject<List<Mascota>>(datastring);
                    return View(mascotas);
                }
            }
            catch (Exception ex)
            {
                bitacora.AgregarBitacora("Mascota", "Index", ex.Message, Session["US"].ToString(), 2);
                return View(new List<Mascota>());
            }
            // errores
            return View(new List<Mascota>());
        }

        // GET: Mascota/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Mascota/" + id);
            Mascota mascota = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                mascota = JsonConvert.DeserializeObject<Mascota>(datastring);
            }
            if (mascota == null)
            {
                bitacora.AgregarBitacora("Mascota", "Details", "No existe", Session["US"].ToString(), 2);
                return View(new Mascota());
            }
            return View(mascota);
        }

        // GET: Mascota/Create
        public async Task<ActionResult> Create()
        {
            ApiCall api = new ApiCall(Session);
            List<Cliente> clientes = new List<Cliente>();
            var resultclient = await api.GetAsync("/api/Client");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(datastring);
            }
            ViewBag.Clientes = new SelectList(clientes, "IdCliente", "Identificacion");
            return View();
        }

        // POST: Mascota/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Mascota mascota)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PostAsync("/api/Mascota", mascota);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            List<Cliente> clientes = new List<Cliente>();
            var resultclient = await api.GetAsync("/api/Client");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(datastring);
            }
            ViewBag.Clientes = new SelectList(clientes, "IdCliente", "Identificacion");
            bitacora.AgregarBitacora("Mascota", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(mascota);
        }

        // GET: Mascota/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Mascota/" + id);
            Mascota mascota = null;
            List<Cliente> clientes = new List<Cliente>();
            var resultclient = await api.GetAsync("/api/Client");
            string datastring;
            if (resultclient.IsSuccessStatusCode)
            {
                datastring = resultclient.Content.ReadAsStringAsync().Result;
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(datastring);
            }
            ViewBag.Clientes = new SelectList(clientes, "IdCliente", "Identificacion");
            if (result.IsSuccessStatusCode)
            {
                datastring = result.Content.ReadAsStringAsync().Result;
                mascota = JsonConvert.DeserializeObject<Mascota>(datastring);
            }
            if (mascota == null)
            {
                bitacora.AgregarBitacora("Mascota", "Edit", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascota/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Mascota mascota)
        {
            List<Cliente> clientes = new List<Cliente>();
            ApiCall api = new ApiCall(Session);
            string datastring;
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/Mascota/" + mascota.IdMascota, mascota);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            var resultclient = await api.GetAsync("/api/Client");
            if (resultclient.IsSuccessStatusCode)
            {
                datastring = resultclient.Content.ReadAsStringAsync().Result;
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(datastring);
            }
            ViewBag.Clientes = new SelectList(clientes, "IdCliente", "Identificacion");
            bitacora.AgregarBitacora("Mascota", "Edit", "No se edito", Session["US"].ToString(), 2);
            return View(mascota);
        }

        // GET: Mascota/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Mascota/" + id);
            Mascota mascota = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                mascota = JsonConvert.DeserializeObject<Mascota>(datastring);
            }
            if (mascota == null)
            {
                bitacora.AgregarBitacora("Mascota", "Delete", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/Mascota/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("Mascota", "Delete", "No se elimino", Session["US"].ToString(), 2);
            return HttpNotFound();
        }
    }
}
