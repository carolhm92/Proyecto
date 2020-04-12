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
    public class ProductoController : Controller
    {
        clsBitacora bitacora = new clsBitacora();

        // GET: Producto
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            var response = await api.GetAsync("/api/Producto");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<Producto>>(datastring).FindAll(c => c.Estado);
                productos = await LLenarDatos(productos);
                return View(productos);
            }
            bitacora.AgregarBitacora("Producto", "Index", "No se pudo obtener datos", Session["US"].ToString(), 2);
            return View(new List<Producto>());
        }

        // GET: Producto/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Producto/" + id);
            Producto producto = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                producto = JsonConvert.DeserializeObject<Producto>(datastring);
                List<Producto> productos = await LLenarDatos(new List<Producto>() { producto });
                producto = productos.First();
            }
            if (producto == null)
            {
                bitacora.AgregarBitacora("Producto", "Details", "No existe", Session["US"].ToString(), 2);
                return View(new Producto());
            }
            return View(producto);
        }

        // GET: Producto/Create
        public async Task<ActionResult> Create()
        {
            await ObtenerProvedores();
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Producto producto)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PostAsync("/api/Producto", producto);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerProvedores();
            bitacora.AgregarBitacora("Producto", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Producto/" + id);
            Producto producto = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                producto = JsonConvert.DeserializeObject<Producto>(datastring);
            }
            if (producto == null)
            {
                bitacora.AgregarBitacora("Producto", "Edit", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            await ObtenerProvedores();
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Producto producto)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/Producto/" + producto.IdProducto, producto);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            await ObtenerProvedores();
            bitacora.AgregarBitacora("Producto", "Edit", "No se edito", Session["US"].ToString(), 2);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.GetAsync("/api/Producto/" + id);
            Producto producto = null;
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                producto = JsonConvert.DeserializeObject<Producto>(datastring);
                List<Producto> productos = await LLenarDatos(new List<Producto>() { producto });
                producto = productos.First();
            }
            if (producto == null)
            {
                bitacora.AgregarBitacora("Producto", "Delete", "No se encontro", Session["US"].ToString(), 2);
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/Producto/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("Producto", "Delete", "No se elimino", Session["US"].ToString(), 2);
            return HttpNotFound();
        }

        private async Task<List<Proveedor>> ObtenerProvedores()
        {
            ApiCall api = new ApiCall(Session);
            List<Proveedor> proveedores = new List<Proveedor>();
            var resultclient = await api.GetAsync("/api/Proveedor");
            if (resultclient.IsSuccessStatusCode)
            {
                var datastring = resultclient.Content.ReadAsStringAsync().Result;
                proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(datastring);
            }
            ViewBag.Proveedores = new SelectList(proveedores.FindAll(c => c.Estado), "IdProveedor", "NombreProveedor");
            return proveedores;
        }

        private async Task<List<Producto>> LLenarDatos(List<Producto> productos)
        {
            var proveedores = await ObtenerProvedores();
            productos.ForEach(producto =>
            {
                producto.Proveedor_Nombre = proveedores.First(c => c.IdProveedor == producto.IdProveedor).NombreProveedor;
            });
            return productos;
        }
    }
}
