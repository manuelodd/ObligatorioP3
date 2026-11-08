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
            return View(findAllHistoriasCU.Execute());
        }

        // GET: HistoriaControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistoriaControler/Create
        public ActionResult Create()
        {
            return View(findAllCatsCU.Execute());
        }

        [HttpPost]
        public IActionResult Create(HistoriaDTO dto)
        {
            try
            {
                altaHistoriaCU.Execute(dto, UsuarioId());
                return RedirectToAction("Index");
            }
            catch(Exception ex)

            //ACA SALTA LA EX
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction("Index", "Historia");
        }

        // GET: HistoriaControler/Edit/5
        public ActionResult Edit(int id)
        {
            HistoriaDTO his = findByIdCU.Execute(id);
            ViewBag.Categorias = findAllCatsCU.Execute();
            return View(his);
        }

        // POST: HistoriaControler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HistoriaDTO dto)
        {
            try
            {
                editarHistoriaCU.Execute(dto, UsuarioId());
                ViewBag.Error = "Modificacion exitosa";
                return RedirectToAction("Index");
            }
            catch(HistoriaException ex)
            {
                ViewBag.Error = ex.Message;
                //si sale mal le vuelvo a recargar las cats
                ViewBag.Categorias = findAllCatsCU.Execute();
                return View(dto);
            }
        }

        public IActionResult Publicar(int id)
        {
            try
            {
                publicarHistoriaCU.Execute(id, UsuarioId());
                return RedirectToAction("Index");
            }
            catch (HistoriaException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: HistoriaControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistoriaControler/Delete/5
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
