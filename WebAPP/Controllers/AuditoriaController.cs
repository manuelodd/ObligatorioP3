using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Auditorias;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace WebAPP.Controllers
{
    public class AuditoriaController : QOLController
    {
        private IListarAuditorias listarAuditoriasCU;
        private IListarHistorias listarHistoriasCU;
        private IListarUsuarios listarUsuariosCU;

        public AuditoriaController(     IListarAuditorias listarAuditoriasCu,
                                        IListarHistorias listarHistoriasCu,
                                        IListarUsuarios listarUsuariosCu)
        {
            listarAuditoriasCU = listarAuditoriasCu;
            listarHistoriasCU = listarHistoriasCu;
            listarUsuariosCU = listarUsuariosCu;
        }

        public IActionResult Index(int? historiaId, int? administradorId)
        {
            if (!UsuarioLogeado() || UsuarioRol() != 0)
                return RedirectToAction("Login", "Usuario");

            ViewBag.Historias = listarHistoriasCU.Execute();
            ViewBag.Administradores = listarUsuariosCU.Execute()
                                            .Where(u => u.Rol == 0)
                                            .ToList();

            List<AuditoriaDTO> auditorias = listarAuditoriasCU.Execute(historiaId, administradorId);

            return View(auditorias);
        }
    }
}
