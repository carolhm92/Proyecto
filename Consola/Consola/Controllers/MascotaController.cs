﻿using System;
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
    public class MascotaController : Controller
    {

        clsMascota Mascota = new clsMascota();


        // GET: Mascota
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mascota/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mascota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mascota/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mascota/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mascota/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mascota/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mascota/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
