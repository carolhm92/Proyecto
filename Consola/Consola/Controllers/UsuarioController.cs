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
    public class UsuarioController : Controller
    {
        clsBitacora bitacora = new clsBitacora();

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            ApiCall api = new ApiCall(Session);
            var response = await api.GetAsync("/api/Usuario");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(datastring);
                return View(users);
            }
            bitacora.AgregarBitacora("Usuario", "Index", "No se pudo obtener datos", Session["US"].ToString(), 2);
            return View(new List<User>());
        }

        // GET: Usuario/Details/5
        public async Task<ActionResult> Details(int IdUsuario, string Usuario, string Clave)
        {
            ApiCall api = new ApiCall(Session);
            User user = new User { IdUsuario = IdUsuario, Usuario = Usuario, Clave = Clave };
            List<int> rolesids = new List<int>();
            var result = await api.GetAsync("/api/Rol/" + IdUsuario);
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                rolesids = JsonConvert.DeserializeObject<List<int>>(datastring);
            }
            ViewBag.Roles = new SelectList(Rol.GetRoles(rolesids), "Valor", "Name");
            return View(user);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(Rol.GetRoles(), "Valor", "Name");
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                user.Clave = Seguridad.Encriptar(user.Clave);
                var result = await api.PostAsync("/api/Usuario", user);
                if (result.IsSuccessStatusCode)
                {
                    var datastring = result.Content.ReadAsStringAsync().Result;
                    var usuario = JsonConvert.DeserializeObject<User>(datastring);
                    foreach (var IdRol in user.Roles)
                        await RegistrarRol(new { usuario.IdUsuario, IdRol });
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Roles = new SelectList(Rol.GetRoles(), "Valor", "Name");
            bitacora.AgregarBitacora("Usuario", "Create", "No se creo", Session["US"].ToString(), 2);
            return View(user);
        }

        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(int IdUsuario, string Usuario, string Clave)
        {
            ApiCall api = new ApiCall(Session);
            User user = new User { IdUsuario = IdUsuario, Usuario = Usuario, Clave = Clave };
            List<int> rolesids = new List<int>();
            var result = await api.GetAsync("/api/Rol/" + IdUsuario);
            if (result.IsSuccessStatusCode)
            {
                var datastring = result.Content.ReadAsStringAsync().Result;
                rolesids = JsonConvert.DeserializeObject<List<int>>(datastring);
            }
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            Rol.GetRoles().ForEach(rol => selectListItems.Add(new SelectListItem { 
                Text = rol.Name,
                Value = "" + rol.Valor,
                Selected = rolesids.Contains(rol.Valor)
            }));
            ViewBag.Roles = selectListItems;
            return View(user);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User user)
        {
            ApiCall api = new ApiCall(Session);
            if (ModelState.IsValid)
            {
                var result = await api.PutAsync("/api/Usuario/" + user.IdUsuario, user);
                if (result.IsSuccessStatusCode && await EliminarRoles(user.IdUsuario))
                {
                    foreach (var IdRol in user.Role)
                        await RegistrarRol(new { user.IdUsuario, IdRol });
                    return RedirectToAction("Index");
                }
            }
            bitacora.AgregarBitacora("Usuario", "Edit", "No se edito", Session["US"].ToString(), 2);
            List<int> rolesids = new List<int>();
            var resultado = await api.GetAsync("/api/Rol/" + user.IdUsuario);
            if (resultado.IsSuccessStatusCode)
            {
                var datastring = resultado.Content.ReadAsStringAsync().Result;
                rolesids = JsonConvert.DeserializeObject<List<int>>(datastring);
            }
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            Rol.GetRoles().ForEach(rol => selectListItems.Add(new SelectListItem
            {
                Text = rol.Name,
                Value = "" + rol.Valor,
                Selected = rolesids.Contains(rol.Valor)
            }));
            ViewBag.Roles = selectListItems;
            return View(user);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int IdUsuario, string Usuario, string Clave)
        {
            User user = new User { IdUsuario = IdUsuario, Usuario = Usuario, Clave = Clave };
            return View(user);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int IdUsuario, string Usuario, string Clave)
        {
            ApiCall api = new ApiCall(Session);
            var result = await api.DeleteAsync("/api/Usuario/" + IdUsuario);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            bitacora.AgregarBitacora("Usuario", "Delete", "No se elimino", Session["US"].ToString(), 2);
            return HttpNotFound();
        }

        private async Task<bool> RegistrarRol(object rol)
        {
            ApiCall api = new ApiCall(Session);
            var resultclient = await api.PostAsync("/api/Rol", rol);
            return resultclient.IsSuccessStatusCode;
        }

        private async Task<bool> EliminarRoles(int Id)
        {
            ApiCall api = new ApiCall(Session);
            var resultclient = await api.DeleteAsync("/api/Rol/" + Id);
            return resultclient.IsSuccessStatusCode;
        }
    }
}
