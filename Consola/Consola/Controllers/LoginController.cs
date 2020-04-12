﻿using Consola.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using Consola.Tools;

namespace Consola.Controllers
{
    public class LoginController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Usuario o Password Incorrectos");
                    return View();
                }
                else
                {
                    clsUsuario Objusuario = new clsUsuario();

                    //var Encriptado = Seguridad.Encriptar(model.Password);
                    //var Desencriptado = Seguridad.Desencriptar(Encriptado);
                    var contraseña = Seguridad.Encriptar(model.Password);
                    var usuario = Objusuario.ExisteUsuario(model.Usuario, contraseña).Where(x => x.Estado == true);

                    if (usuario.Count() > 0)
                    {
                        Session["US"] = model.Usuario;
                        Session["PW"] = model.Password;
                        Session["ROLES"] = "Admin";


                        string baseUrl = ConfigurationManager.AppSettings["URL_API"];

                        //crea el el encabezado
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri(baseUrl);
                        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);

                        Usuario userModel = new Usuario();
                        userModel.UserName = model.Usuario;
                        userModel.Password = Seguridad.Encriptar(model.Password);

                        string stringData = JsonConvert.SerializeObject(userModel);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                        HttpResponseMessage response = client.PostAsync("/api/login/authenticate", contentData).Result;
                        var stringJWT = response.Content.ReadAsStringAsync().Result;

                        JWT jwt = new JWT { Token = stringJWT.Replace("\"", "") };

                        //Aca se crea la sesion
                        Session["token"] = jwt.Token;
                        Session["US"] = model.Usuario.ToUpper();

                        string userData = "Datos específicos de aplicación para este usuario.";

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        model.Usuario.ToUpper(),
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        model.RememberMe,
                        userData,
                        FormsAuthentication.FormsCookiePath);

                        // Encryptar el ticket.
                        string encTicket = FormsAuthentication.Encrypt(ticket);

                        // Crea la cookie.
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Error de Autenticación", "Usuario o Contaseña Invalida");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error de Autenticación", "Usuario o Contaseña Invalida");
            }
            return View(model);
        }

        //[Authorize]
        public ActionResult Salir()
        {
            Session.Remove("US");
            Session["token"] = null;
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cache.SetNoServerCaching();
            Request.Cookies.Clear();
            return RedirectToAction("Login", "Login");
        }

    }
}