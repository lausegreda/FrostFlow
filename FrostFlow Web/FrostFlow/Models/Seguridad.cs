using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

/*  Filtro personalizado para que todo a todo método que se le aplique debe tener sí o sí una sesión activa, se aplica a los  métodos más delicados 
    como CRUDS o toda función que se realice dentro del sistema.
    Por default redirecciona a Iniciar Sesión.
 */

namespace FrostFlow.Models
{
    public class Seguridad : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home"},
                    {"action", "Login" }
                });
            }
            base.OnActionExecuting(context);
        }

    }
}
