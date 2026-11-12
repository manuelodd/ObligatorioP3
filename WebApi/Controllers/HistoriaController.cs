using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoriaController : ControllerBase
    {
        private IObtenerRankingsHistorias obtenerRankingsHistoriasCU;
        private IListarHistoriasPublicadas listarHistoriasPublicadasCU;
        private IObtenerFinalesAlcanzadosHistoria obtenerFinalesCU;
        public HistoriaController(  IObtenerRankingsHistorias obtenerRankingsHistoriasCu,
                                        IListarHistoriasPublicadas listarHistoriasPublicadasCu,
                                        IObtenerFinalesAlcanzadosHistoria obtenerFinalesMasAlcanzadosCu)
            {
                obtenerRankingsHistoriasCU = obtenerRankingsHistoriasCu;
                listarHistoriasPublicadasCU = listarHistoriasPublicadasCu;
                obtenerFinalesCU = obtenerFinalesMasAlcanzadosCu;
            }


        [HttpGet("Rankings")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<List<HistoriaRankingsDTO>> Rankings()
            {
                try
                {
                    List<HistoriaRankingsDTO> lista = obtenerRankingsHistoriasCU.Execute();
                    return Ok(lista);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Error al intentar devolver los rankings");
                }
            }

        [HttpGet("Publicadas")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<List<HistoriaToListDTO>> Publicadas(int? categoriaid)
        {
            try
            {
                List<HistoriaToListDTO> lista = listarHistoriasPublicadasCU.Execute(categoriaid);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al intentar devolver las historias publicadas");
            }
        }

        [HttpGet("{historiaId}/finales-alcanzados")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult FinalesHistoria(int historiaId)
        {
            try
            {
                List<FinalesAlcanzadosDTO> finales =    obtenerFinalesCU.Execute(historiaId);
                return Ok(finales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener finales de historia.");
            }
        }

    }
}
