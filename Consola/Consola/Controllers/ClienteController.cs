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
    public class ClienteController : Controller
    {
        clsBitacora bitacora = new clsBitacora();

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            var response = await api.GetAsync("/api/Cliente");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(datastring);
                clientes = await LLenarDatos(clientes);
                return View(clientes);
            }
            bitacora.AgregarBitacora("Cliente", "Index", "No se pudo obtener datos", Session["US"].ToString(), 2);
            return View(new List<Cliente>());
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Cliente/" + id);
            Cliente cliente = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(datastring);
                List<Cliente> clientes = await LLenarDatos(new List<Cliente>() { cliente });
                cliente = clientes.First();
            }
            if (cliente == null)
            {
                bitacora.AgregarBitacora("Cliente", "Details", "No existe", Session["US"].ToString(), 2);
                return View(new Cliente());
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public async Task<ActionResult> Create()
        {
            await ObtenerProvincias();
            await ObtenerTipoIdentificaciones();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PostAsync("/api/Cliente", cliente);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerProvincias();
            await ObtenerTipoIdentificaciones();
            bitacora.AgregarBitacora("Cliente", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Cliente/" + id);
            Cliente cliente = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(datastring);
            }
            if (cliente == null)
            {
                bitacora.AgregarBitacora("Cliente", "Edit", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            await ObtenerProvincias();
            await ObtenerTipoIdentificaciones();
            var cantones = await ObtenerCantones(cliente.Provincia);
            var distritos = await ObtenerDistritos(cliente.Provincia,cliente.Canton);
            ViewBag.Cantones = new SelectList(cantones, "Canton","Nombre");
            ViewBag.Distritos = new SelectList(distritos, "Distrito", "Nombre");
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Cliente cliente)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/Cliente/" + cliente.IdCliente, cliente);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerProvincias();
            await ObtenerTipoIdentificaciones();
            var cantones = await ObtenerCantones(cliente.Provincia);
            var distritos = await ObtenerDistritos(cliente.Provincia, cliente.Canton);
            ViewBag.Cantones = new SelectList(cantones, "Canton", "Nombre");
            ViewBag.Distritos = new SelectList(distritos, "Distrito", "Nombre");
            bitacora.AgregarBitacora("Cliente", "Edit", "No se edito", Session["US"].ToString(), 2);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Cliente/" + id);
            Cliente cliente = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(datastring);
            }
            if (cliente == null)
            {
                bitacora.AgregarBitacora("Cliente", "Delete", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/Cliente/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("Cliente", "Delete", "No se elimino", Session["US"].ToString(), 2);
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

        private async Task<List<TipodeIdentificacion>> ObtenerTipoIdentificaciones()
        {
            ApiCall api = new ApiCall(Session);
            List<TipodeIdentificacion> tipoIdentificacions = new List<TipodeIdentificacion>();
            var resultclient = await api.GetAsync("/api/TipoIdentificacion");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                tipoIdentificacions = JsonConvert.DeserializeObject<List<TipodeIdentificacion>>(datastring);
            }
            ViewBag.TiposIdentificaciones = new SelectList(tipoIdentificacions, "IdTipoIdentificacion", "TipoIdentificacion");
            return tipoIdentificacions;
        }

        private async Task<List<Cantones>> ObtenerCantones(char provincia)
        {
            ApiCall api = new ApiCall(Session);
            List<Cantones> cantones = new List<Cantones>();
            var resultclient = await api.GetAsync("/api/Canton/"+ provincia);
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

        private async Task<Persona> ObtenerPersona(string identificacion)
        {
            ApiCall api = new ApiCall(Session);
            Persona persona = new Persona();
            var resultclient = await api.GetAsync("/api/Persona/" + identificacion);
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                persona = JsonConvert.DeserializeObject<Persona>(datastring);
            }
            return persona;
        }

        [HttpPost]
        public async Task<JsonResult> ConsultaPersona(string identificacion)
        {
            var persona = await ObtenerPersona(identificacion);
            return Json(persona);
        }

        public async Task<List<Cliente>> LLenarDatos(List<Cliente> clientes)
        {
            var tiposIdentificaciones = await ObtenerTipoIdentificaciones();
            var provincias = await ObtenerProvincias();
            var cantones = await ObtenerCantones();
            var distritos = await ObtenerDistritos();
            clientes.ForEach(cliente =>
            {
                cliente.Canton_Nombre = cantones.First(c => c.Canton.Equals(cliente.Canton)).Nombre;
                cliente.Distrito_Nombre = distritos.First(d => d.Distrito.Equals(cliente.Distrito)).Nombre;
                cliente.Provincia_Nombre = provincias.First(p => p.Cod.Equals(cliente.Provincia)).Nombre;
                cliente.TipoIdentificacion_Nombre = tiposIdentificaciones.First(t => t.IdTipoIdentificacion.Equals(cliente.IdTipoIdentificacion)).TipoIdentificacion;
            });
            return clientes;
        }
    }
}
