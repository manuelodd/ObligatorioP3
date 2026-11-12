using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPP.Controllers
{
    public class QOLController : Controller
    {

        protected string UsuarioUsername()
        {
            return HttpContext.Session.GetString("username");
        }

        protected bool UsuarioLogeado() 
        {
            return HttpContext.Session.GetString("username") != null;
        }

        protected int UsuarioId()
        {
            return HttpContext.Session.GetInt32("usuarioid").Value;
        }

        protected int UsuarioRol()
        {
            return HttpContext.Session.GetInt32("rol").Value;
        }
    }
}
