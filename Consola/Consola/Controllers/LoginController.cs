using Consola.Models;
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

namespace Consola.Controllers
{
    public class LoginController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Blank", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl="")
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    clsUsuario Objusuario = new clsUsuario();
                    var usuario = Objusuario.ConsultarUsuario(model.Usuario, model.Password).Where(x => x.Estado == true);

                    if (usuario.Count() > 0)
                    {
                        Session["US"] = model.Usuario;
                        Session["PW"] = model.Password;
                        Session["ROLES"] = "Admin";
                        FormsAuthentication.SetAuthCookie(model.Usuario, true);

                        string baseUrl = ConfigurationManager.AppSettings["URL_API"];

                        //crea el el encabezado
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri(baseUrl);
                        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);

                        Usuario userModel = new Usuario();
                        userModel.UserName = model.Usuario;
                        userModel.Password = model.Password;

                        string stringData = JsonConvert.SerializeObject(userModel);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                        HttpResponseMessage response = client.PostAsync("/api/login/authenticate", contentData).Result;
                        var stringJWT = response.Content.ReadAsStringAsync().Result;

                        JWT jwt = new JWT { Token = stringJWT.Replace("\"","") };

                        Session["token"] = jwt.Token;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(model);            
            }

        }

        //[Authorize]
        public ActionResult Salir()
        {
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