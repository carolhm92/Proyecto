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
    public class VentaController : Controller
    {
        clsBitacora bitacora = new clsBitacora();

        // GET: Venta
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            var response = await api.GetAsync("/api/Venta");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var ventas = JsonConvert.DeserializeObject<List<Venta>>(datastring).FindAll(c => c.Estado);
                ventas = await LLenarDatos(ventas);
                return View(ventas);
            }
            bitacora.AgregarBitacora("Venta", "Index", "No se pudo obtener datos", Session["US"].ToString(), 2);
            return View(new List<Venta>());
        }

        // GET: Venta/Create
        public async Task<ActionResult> Create()
        {
            await ObtenerCitas();
            await ObtenerProductos();
            ObtenerTipos();
            return View();
        }

        // POST: Venta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Venta venta)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PostAsync("/api/Venta", venta);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerCitas();
            await ObtenerProductos();
            ObtenerTipos();
            bitacora.AgregarBitacora("Venta", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(venta);
        }

        private void ObtenerTipos()
        {
            ViewBag.Tipos = new SelectList(new[] {
                new SelectListItem { Text="Producto", Value="Producto" },
                new SelectListItem { Text="Servicio", Value="Servicio" }
            }, "Value", "Text");
        }

        // GET: Venta/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Venta/" + id);
            Venta venta = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                venta = JsonConvert.DeserializeObject<Venta>(datastring);
            }
            if (venta == null)
            {
                bitacora.AgregarBitacora("Venta", "Edit", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            await ObtenerCitas();
            await ObtenerProductos();
            ObtenerTipos();
            return View(venta);
        }

        // POST: Venta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Venta venta)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/Venta/" + venta.IdVenta, venta);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerCitas();
            await ObtenerProductos();
            ObtenerTipos();
            bitacora.AgregarBitacora("Venta", "Edit", "No se edito", Session["US"].ToString(), 2);
            return View(venta);
        }

        // GET: Venta/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Venta/" + id);
            Venta venta = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                venta = JsonConvert.DeserializeObject<Venta>(datastring);
                List<Venta> ventas = await LLenarDatos(new List<Venta>() { venta });
                venta = ventas.First();
            }
            if (venta == null)
            {
                bitacora.AgregarBitacora("Venta", "Delete", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/Venta/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("Venta", "Delete", "No se elimino", Session["US"].ToString(), 2);
            return HttpNotFound();
        }

        private async Task<List<Cita>> ObtenerCitas()
        {
            ApiCall api = new ApiCall(Session);
            List<Cita> citas = new List<Cita>();
            var resultclient = await api.GetAsync("/api/Cita");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                citas = JsonConvert.DeserializeObject<List<Cita>>(datastring);
            }
            ViewBag.Citas = new SelectList(citas.FindAll(c => c.Estado), "IdCita", "Asunto");
            return citas;
        }
        private async Task<List<Producto>> ObtenerProductos()
        {
            ApiCall api = new ApiCall(Session);
            List<Producto> productos = new List<Producto>();
            var resultclient = await api.GetAsync("/api/Producto");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                productos = JsonConvert.DeserializeObject<List<Producto>>(datastring);
            }
            ViewBag.Productos = new SelectList(productos.FindAll(c => c.Estado), "IdProducto", "NombreProducto");
            return productos;
        }

        public async Task<List<Venta>> LLenarDatos(List<Venta> ventas)
        {
            var productos = await ObtenerProductos();
            ventas.ForEach(venta =>
                venta.Producto_Nombre = productos.First(p => p.IdProducto == venta.IdProducto).NombreProducto
            );
            return ventas;
        }
    }
}
