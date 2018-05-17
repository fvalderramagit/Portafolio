using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PortafolioFAVP.Areas.Admin.Filters
{
    //Tenemos dos class en este archivo

    // Si no estamos logeado, regresamos al login. Esto es un filtro (que permite dar comportamiento antes que el controlador actue)
    public class AutenticadoAttribute : ActionFilterAttribute   //La palabra autenticado se pega en los controladores en el punto 15.4.3.
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExistUserInSession())  //Si no estamos logueados
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new   //nos regresa al controlador Login
                {
                    controller = "Login",
                    action = "Index"
                }));
            }
        }
    }

    // Si estamos logeado ya no podemos acceder a la página de Login, deberia devolvermos a la pagina de inicio
    public class NoLoginAttribute : ActionFilterAttribute   //La palabra autenticado se pega en los controladores en el punto 15.4.4.
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (SessionHelper.ExistUserInSession())   //Si estamos logueados
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Usuario",   //nos regresa al controlador Usuario
                    action = "Index"
                }));
            }
        }
    }
}