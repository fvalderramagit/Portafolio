/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortafolioFAVP.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
    }
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioFAVP.Areas.Admin.Filters;
using Modelo;
using PortafolioFAVP.Areas.Admin.Controllers;
using Helper;

namespace PortafolioFAVP.Areas.Admin.Controllers
{
    [NoLogin]  //Y se carga el using proyecto.areas.admin.filters;
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();  //Este objeto se crea para la accion del punto 15.3.4.

        // GET: Admin/Login
        [NoLogin]     //Esta anotacion se crea en el punto 15.4.4. esta relacionada con los filtros. tambien se puede colocar a nivel de la accion o metodo
        public ActionResult Index()
        {
            return View();
        }


        //Esta accion se crea en el punto 15.3.4.
        public JsonResult Acceder(string Email, string Password)  //se crea de tipo JsonResult ya que en este caso lo vamos a hacer de tipo AJAX
        {
            var rm = usuario.Acceder(Email, Password);   //metodo acceder de la class Usuario para que rm lo retorne

            if (rm.response)   //Validar si rm.response es true. si el logueo fue exitoso
            {
                rm.href = Url.Content("~/admin/usuario");  //que realice un redirect al controlador usuario que esta en el area admin para que muestre la vista de index usuario 
            }

            return Json(rm);   //retorne el json con la respuesta
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();   //Se implementa luego de haber creado el JsonResult Acceder. Eliminar (destruir) la sesion actual
            return Redirect("~/");  //redireccionar a la vista del usuario (a la hoja de vida, no al area)
        }
    }
}