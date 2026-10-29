using DTOs.DTOs;
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
        private IListarCategorias findAllCatsCU;
        private IAltaHistoria altaHistoriaCU;
        public HistoriaController(      
                                    IListarCategorias findAllCatsCu,
                                    IAltaHistoria altaHistoriaCu,
                                    IListarHistorias findAllHistoriasCu)
        {
            findAllCatsCU = findAllCatsCu;
            altaHistoriaCU = altaHistoriaCu;
            findAllHistoriasCU = findAllHistoriasCu;
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
                altaHistoriaCU.Execute(dto);
                return Content("Historia creada correctamente");
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
            return View();
        }

        // POST: HistoriaControler/Edit/5
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
