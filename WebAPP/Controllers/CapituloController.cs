using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.CasosDeUso.Capitulos;
using LogicaAplicacion.CasosDeUso.Historias;
using LogicaAplicacion.InterfacesCasosDeUso.Capitulos;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAPP.Controllers
{
    public class CapituloController : QOLController
    {
        private IRepositorioCapitulos repositorioCaps;
        private IListarHistorias findAllHistoriasCU;
        private IAltaCapitulo altaCapituloCU;
        private IListarAntecedentesById findAllAntecedentesByIdCU;
        private IEditarCapitulo editarCapituloCU;

        public CapituloController(  IListarHistorias findAllHistoriasCu,
                                    IAltaCapitulo altaCapituloCu,
                                    IListarAntecedentesById findAllAntecedentesByIdCu,
                                    IEditarCapitulo editarCapituloCu,
                                    IRepositorioCapitulos repoCaps)
        {
            findAllHistoriasCU = findAllHistoriasCu;
            altaCapituloCU = altaCapituloCu;
            findAllAntecedentesByIdCU = findAllAntecedentesByIdCu;
            editarCapituloCU = editarCapituloCu;
            repositorioCaps = repoCaps;
        }

        //2 views distintas para seleccionar historia primero y despues mandar a select antecedentes y alta de cap)
        public ActionResult SeleccionarHistoria()
        {
            ViewBag.Historias = findAllHistoriasCU.Execute();
            return View();
        }

        public ActionResult Create(int historiaId)
        {
            CapituloAltaDTO dto = new CapituloAltaDTO
            {
                HistoriaId = historiaId
            };

            ViewBag.Antecedentes = findAllAntecedentesByIdCU.Execute(historiaId);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CapituloAltaDTO dto)
        {
            try
            {
                altaCapituloCU.Execute(dto, UsuarioId());
                return RedirectToAction("Index", "Historia");
            }
            catch (CapituloException ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Antecedentes = findAllAntecedentesByIdCU.Execute(dto.HistoriaId);
                return View(dto);
            }
        }

        public ActionResult Edit(int id)
        {
            Capitulo capitulo = repositorioCaps.FindById(id);
            if(capitulo == null)
            {
                return NotFound();
            }

            CapitulosToListDTO dto = new CapitulosToListDTO
            {
                CapId = capitulo.Id,
                CapTitulo = capitulo.Titulo,
                CapTexto = capitulo.Texto,
            };

            return View(dto);
        }

        // POST: CapituloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CapitulosToListDTO dto)
        {
            try
            {
                editarCapituloCU.Execute(dto, UsuarioId());
                return RedirectToAction("Index", "Historia");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(dto);
            }
        }



        public ActionResult Index()
        {
            return View();
        }

        // GET: CapituloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
