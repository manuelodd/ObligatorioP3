using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.CasosDeUso.Historias;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPP.Controllers
{
    public class HistoriaController : QOLController
    {
        // GET: HistoriaControler
        private IListarHistorias findAllHistoriasCU;
        private IObtenerHistoriaPorId findByIdCU;
        private IEditarHistoria editarHistoriaCU;
        private IListarCategorias findAllCatsCU;
        private IAltaHistoria altaHistoriaCU;
        private IPublicarHistoria publicarHistoriaCU;
        public HistoriaController(      
                                    IListarCategorias findAllCatsCu,
                                    IAltaHistoria altaHistoriaCu,
                                    IListarHistorias findAllHistoriasCu,
                                    IEditarHistoria editarHistoriaCu,
                                    IObtenerHistoriaPorId findByIdCu,
                                    IPublicarHistoria publicarHistoriaCu)
        {
            findAllCatsCU = findAllCatsCu;
            altaHistoriaCU = altaHistoriaCu;
            findAllHistoriasCU = findAllHistoriasCu;
            editarHistoriaCU = editarHistoriaCu;
            findByIdCU = findByIdCu;
            publicarHistoriaCU = publicarHistoriaCu;
        }

        public ActionResult Index()
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            return View(findAllHistoriasCU.Execute());
        }

        public ActionResult Create()
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            return View(findAllCatsCU.Execute());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HistoriaDTO dto)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            try
            {
                altaHistoriaCU.Execute(dto, UsuarioId());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(dto);
            }
        }

        public ActionResult Edit(int id)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            HistoriaDTO his = findByIdCU.Execute(id);
            ViewBag.Categorias = findAllCatsCU.Execute();

            return View(his);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HistoriaDTO dto)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            try
            {
                editarHistoriaCU.Execute(dto, UsuarioId());
                return RedirectToAction("Index");
            }
            catch (HistoriaException ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = findAllCatsCU.Execute();

                HistoriaDTO historia = findByIdCU.Execute(dto.Id);

                historia.Titulo = dto.Titulo;
                historia.Sinopsis = dto.Sinopsis;
                historia.TituloCapInicial = dto.TituloCapInicial;
                historia.TextoCapInicial = dto.TextoCapInicial;

                return View(historia);
            }
        }

        public IActionResult Publicar(int id)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            try
            {
                publicarHistoriaCU.Execute(id, UsuarioId());
                TempData["Mensaje"] = "Historia publicada correctamente.";
                return RedirectToAction("Index");
            }
            catch (HistoriaException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
