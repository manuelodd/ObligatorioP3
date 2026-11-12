using Dominio.Enums;
using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebAPP.Controllers
{
    public class UsuarioController : QOLController
    {
        private ILoginUsuarios loginUsuariosCU;
        private IAltaUsuario altaUsuarioCU;

        public UsuarioController(
                                    IAltaUsuario altaUsuarioCu,
                                    ILoginUsuarios loginUsuariosCu)
        {
            this.altaUsuarioCU = altaUsuarioCu;
            this.loginUsuariosCU = loginUsuariosCu;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDTO dto)
        {
            try
            {
                UsuarioDTO usuario = loginUsuariosCU.Execute(dto);

                if (usuario.Rol != 0)
                {
                    ViewBag.Error = "Solo pueden acceder admins.";
                    return View(dto);
                }

                HttpContext.Session.SetInt32("usuarioid", usuario.Id);
                HttpContext.Session.SetString("username", usuario.Username);
                HttpContext.Session.SetInt32("rol", (int)usuario.Rol);

                return RedirectToAction("Index");
            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = ex.Message;
                return View(dto);
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
            {
                return RedirectToAction("Login", "Usuario");
            }

            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Index()
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
            {
                return RedirectToAction("Login", "Usuario");
            }

            return View();
        }

        public IActionResult Create()
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
            {
                return RedirectToAction("Login", "Usuario");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioDTO dto)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
            {
                return RedirectToAction("Login", "Usuario");
            }
            try
            {
                altaUsuarioCU.Execute(dto);
                return RedirectToAction("Index");
            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = ex.Message;
            }
            {
                return View(dto);
            }
        }
    }
}
