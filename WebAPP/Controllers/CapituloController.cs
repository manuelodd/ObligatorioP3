using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.CasosDeUso.Capitulos;
using LogicaAplicacion.InterfacesCasosDeUso.Capitulos;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPP.Controllers
{
    public class CapituloController : QOLController
    {
        private IListarHistorias findAllHistoriasCU;
        private IAltaCapitulo altaCapituloCU;

        public CapituloController(  IListarHistorias findAllHistoriasCu,
                                    IAltaCapitulo altaCapituloCu)
        {
            findAllHistoriasCU = findAllHistoriasCu;
            altaCapituloCU = altaCapituloCu;
        }
        // GET: CapituloController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CapituloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CapituloController/Create
        public ActionResult Create()
        {
            ViewBag.Historias = findAllHistoriasCU.Execute();
            return View();
        }

        // POST: CapituloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CapituloAltaDTO dto)
        {
            try
            {
                altaCapituloCU.Execute(dto);
                return RedirectToAction("Index", "Historia");
            }
            catch(CapituloException ex)
            {
                ViewBag.Error = ex.Message;
                return View(dto);
            }
        }

        // GET: CapituloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CapituloController/Edit/5
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

        // GET: CapituloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CapituloController/Delete/5
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
