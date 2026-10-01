using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPP.Controllers
{
    public class UsuarioController : QOLController
    {
        private IListarUsuarios listarUsuariosCU;
        private IObtenerUsuarioPorId obtenerUsuarioPorIdCU;
        private IAltaUsuario altaUsuarioCU;

        public UsuarioController(   IListarUsuarios listarUsuariosCu, 
                                    IObtenerUsuarioPorId obtenerUsuarioPorIdCu,
                                    IAltaUsuario altaUsuarioCu)
        {
            this.listarUsuariosCU = listarUsuariosCu;
            this.obtenerUsuarioPorIdCU = obtenerUsuarioPorIdCu;
            this.altaUsuarioCU = altaUsuarioCu;
        }

        public ActionResult Index()
        {
            return View(listarUsuariosCU.Execute());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View(obtenerUsuarioPorIdCU.Execute(id));
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO dto)
        {
            try
            {
                altaUsuarioCU.Execute(dto);
                return RedirectToAction("Index", "Usuario");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
