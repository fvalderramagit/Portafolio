﻿
using PortafolioFAVP.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortafolioFAVP.Areas.Admin.Controllers
{
    [Autenticado]   //Y se carga el using proyecto.areas.admin.filters;
    public class TestimonioController : Controller
    {
        // GET: Admin/Testimonio
        public ActionResult Index()
        {
            return View();
        }
    }
}