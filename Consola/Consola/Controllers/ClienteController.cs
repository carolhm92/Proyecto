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

namespace Consola.Controllers
{
    //[Authorize]
    public class ClienteController : Controller
    {
        clsInformacion Informacion = new clsInformacion();
        // GET: Cliente
        public ActionResult Index()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    List<Cliente> listaCliente = new List<Cliente>();
                    clsCliente cliente = new clsCliente();
                    var data = cliente.ConsultarCliente().ToList();

                    foreach (var item in data)
                    {
                        Cliente modelo = new Cliente();
                        modelo.IdCliente = item.IdCliente;
                        modelo.IdTipoIdentificacion = item.IdTipoIdentificacion;
                        modelo.Identificacion = item.Identificacion;
                        modelo.Nombre = item.Nombre;
                        modelo.Apellido1 = item.Apellido1;
                        modelo.Apellido2 = item.Apellido2;
                        modelo.Correo = item.Correo;
                        modelo.Telefono = item.Telefono;
                        modelo.Provincia = item.Provincia;
                        modelo.Canton = item.Canton;
                        modelo.Distrito = item.Distrito;
                        modelo.Estado = item.Estado;

                        listaCliente.Add(modelo);

                    }
                return View(listaCliente);
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            catch
            {
                string descMsg = "Error consultando la informacion del CLiente.";
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: Cliente/Create
        public ActionResult Crear()
        {
            try
            {
                clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "H", Text = "Hombre" },
                                   new SelectListItem { Value = "M", Text = "Mujer" }
                                                               }, "Value", "Text");
                ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                ViewBag.ListaProvincias = CargaProvincias();
                ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: Cliente/Crear
        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!Utilerias.ValidarCorreo(cliente.Correo))
                    {

                    }
                    clsCliente Objcliente = new clsCliente();
                    bool Resultado = Objcliente.AgregarCliente(cliente.IdTipoIdentificacion, cliente.Identificacion,
                        cliente.Nombre, cliente.Apellido1, cliente.Apellido2, cliente.Correo, cliente.Telefono,
                        cliente.Provincia, cliente.Canton, cliente.Distrito, cliente.Estado);

                    if (Resultado)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                        ViewBag.ListaSexo = new SelectList(new[] {
                                       new SelectListItem { Value = "H", Text = "Hombre" },
                                       new SelectListItem { Value = "M", Text = "Mujer" }
                                                                   }, "Value", "Text");
                        ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                        ViewBag.ListaProvincias = CargaProvincias();
                        ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();
                        return View("Crear");
                    }
                }
                else
                {
                    clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                    ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "H", Text = "Hombre" },
                                   new SelectListItem { Value = "M", Text = "Mujer" }
                                                               }, "Value", "Text");
                    ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                    ViewBag.ListaProvincias = CargaProvincias();
                    ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();
                    return View("Crear");
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Editar/5
        public ActionResult Editar(int id)
        {
            try
            {
                clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                clsCliente cliente = new clsCliente();
                ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "H", Text = "Hombre" },
                                   new SelectListItem { Value = "M", Text = "Mujer" }
                                                               }, "Value", "Text");
                ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                var dato = cliente.ConsultaCliente(id);

                Cliente modelo = new Cliente();
                modelo.IdCliente = dato[0].IdCliente;
                modelo.IdTipoIdentificacion = dato[0].IdTipoIdentificacion;
                modelo.Identificacion = dato[0].Identificacion;
                modelo.Nombre = dato[0].Nombre;
                modelo.Apellido1 = dato[0].Apellido1;
                modelo.Apellido2 = dato[0].Apellido2;
                modelo.Correo = dato[0].Correo;
                modelo.Telefono = dato[0].Telefono;
                modelo.Provincia = dato[0].Provincia;
                modelo.Canton = dato[0].Canton;
                modelo.Distrito = dato[0].Distrito;
                modelo.Estado = dato[0].Estado;

                ViewBag.ListaProvincias = CargaProvincias();
                ViewBag.ListaCantones = CargaCanton(dato[0].Provincia);
                ViewBag.ListaDistritos = CargaDistrito(dato[0].Provincia, dato[0].Canton);
                ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();
                return View(modelo);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        // POST: Cliente/Editar/5
        [HttpPost]
        public ActionResult Editar(int id, Cliente cliente)
        {
            try
            {

                if (!Utilerias.ValidarCorreo(cliente.Correo))
                {

                }
                clsCliente ObjCliente = new clsCliente();
                bool Resultado = ObjCliente.ActualizarCliente(cliente.IdCliente,cliente.IdTipoIdentificacion, cliente.Identificacion,
                        cliente.Nombre, cliente.Apellido1, cliente.Apellido2, cliente.Correo, cliente.Telefono,
                        cliente.Provincia, cliente.Canton, cliente.Distrito, cliente.Estado);

                if (Resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    clsTipoIdentificacion tiposIdentificacion = new clsTipoIdentificacion();
                    ViewBag.ListaSexo = new SelectList(new[] {
                                       new SelectListItem { Value = "H", Text = "Hombre" },
                                       new SelectListItem { Value = "M", Text = "Mujer" }
                                                                   }, "Value", "Text");
                    ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                    ViewBag.ListaProvincias = CargaProvincias();
                    ViewBag.ListaTiposIdentificacion = tiposIdentificacion.ConsultarTipoIdentificacion();
                    return View("Editar");
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: Cliente/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            try
            {
                clsCliente objcliente = new clsCliente();
                bool Resultado = objcliente.EliminarCliente(id);

                if (Resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }   

            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// Obtiene Provincias
        /// </summary>
        /// <returns></returns>
        public List<ProvinciasResult> CargaProvincias()
        {
            List<ProvinciasResult> provincias = Informacion.ObtenerProvincias();
            return provincias;
        }
        /// <summary>
        /// Obtiene Cantones
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        public List<CantonesResult> CargaCanton(char provincia)
        {
            List<CantonesResult> cantones = Informacion.ObtenerCantones(provincia);
            return cantones;
        }
        /// <summary>
        /// Obtiene Distritos
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="canton"></param>
        /// <returns></returns>
        public List<DistritosResult> CargaDistrito(char provincia, string canton)
        {
            List<DistritosResult> distritos = Informacion.ObtenerDistritos(provincia, canton);
            return distritos;
        }
        /// <summary>
        /// Cargar Cantones hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaCantones(char provincia)
        {
            List<CantonesResult> cantones = Informacion.ObtenerCantones(provincia);
            return Json(cantones, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Cargar Disttritos hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="canton"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaDistritos(char provincia, string canton)
        {
            List<DistritosResult> distritos = Informacion.ObtenerDistritos(provincia, canton);
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ConsultaPersona(string identificacion)
        {
            string baseUrl = ConfigurationManager.AppSettings["URL_API"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(contentType);
            JWT jwt = new JWT();
            jwt.Token=HttpContext.Session["token"].ToString();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",jwt.Token);

            DatoPersona personModel = new DatoPersona();
            personModel.Identificacion = identificacion;

            string stringData = JsonConvert.SerializeObject(personModel);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/consultas/ObtenerIdentificacion", contentData).Result;
            string stringPersona = response.Content.ReadAsStringAsync().Result;
            List<Persona> data = JsonConvert.DeserializeObject<List<Persona>>(stringPersona);

            if (!response.IsSuccessStatusCode)
            {
                string Message = "Unauthorized!";
                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


    }
}
