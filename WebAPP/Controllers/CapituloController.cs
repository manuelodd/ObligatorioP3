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

        //2 views distintas para seleccionar historia primero y
        //despues mandar a select antecedentes y alta de cap, no me complico con js
        public ActionResult SeleccionarHistoria()
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            ViewBag.Historias = findAllHistoriasCU.Execute();
            return View();
        }

        public ActionResult Create(int historiaId)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

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
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            try
            {
                altaCapituloCU.Execute(dto, UsuarioId());
                return RedirectToAction("Index", "Historia");
            }
            catch (CapituloException ex)
            {
                ViewBag.Error = ex.Message;
                //vuelvo a cargar el viewbag
                ViewBag.Antecedentes = findAllAntecedentesByIdCU.Execute(dto.HistoriaId);
                return View(dto);
            }
        }

        public ActionResult Edit(int id)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            Capitulo capitulo = repositorioCaps.FindById(id);

            if (capitulo == null)
                return NotFound();

            CapitulosToListDTO dto = new CapitulosToListDTO
            {
                CapId = capitulo.Id,
                CapTitulo = capitulo.Titulo,
                CapTexto = capitulo.Texto
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CapitulosToListDTO dto)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

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
    }
}
