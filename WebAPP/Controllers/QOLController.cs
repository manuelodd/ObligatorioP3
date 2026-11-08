using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPP.Controllers
{
    public class QOLController : Controller
    {

        // puedo ponerlo protected porque solo lo van a usar los hijos
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
    }
}
