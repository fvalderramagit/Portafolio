using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortafolioFAVP.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public TablaDato tabladato = new TablaDato();

        public int index()
        {
            return tabladato.Conteo();
        }
    }
}