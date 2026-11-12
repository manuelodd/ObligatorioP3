using Dominio.Entities;
using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using LogicaAplicacion.InterfacesCasosDeUso.Lecturas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LecturaController : ControllerBase
    {
        private IObtenerHistorialLecturasUsu obtenerHistorialLecUsuCU;
        private IObtenerRankingsHistorias obtenerRankingsHistoriasCU;
        private IEmpezarLectura empezarLecturaCU;
        private IObtenerCapituloLectura obtenerCapituloCU;
        private ISeguirLectura seguirLecturaCU;

        public LecturaController(   IEmpezarLectura empezarLec,
                                    IObtenerCapituloLectura obtenerCap,
                                    ISeguirLectura seguirLec,
                                    IObtenerHistorialLecturasUsu obtenerHistorialLecUsuCu,
                                    IObtenerRankingsHistorias obtenerRankingsHistoriasCu)
        {
            obtenerHistorialLecUsuCU = obtenerHistorialLecUsuCu;
            empezarLecturaCU = empezarLec;
            obtenerCapituloCU = obtenerCap;
            seguirLecturaCU = seguirLec;
            obtenerRankingsHistoriasCU = obtenerRankingsHistoriasCu;
        }

        [HttpPost("{historiaId}/empezar/{usuarioId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Empezar(int historiaId, int usuarioId)
        {
            try
            {
                Lectura lectura = empezarLecturaCU.Execute(usuarioId, historiaId);
                return Ok(lectura.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al empezar la lectura.");
            }
        }

        [HttpGet("{lecturaId}/capitulo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult ObtenerCapitulo(int lecturaId)
        {
            try
            {
                CapituloLecturaDTO dto = obtenerCapituloCU.Execute(lecturaId);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener capítulo.");
            }
        }

        [HttpPost("{lecturaId}/seguir/{opcionId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Seguir(int lecturaId, int opcionId)
        {
            try
            {
                Lectura lectura = seguirLecturaCU.Execute(lecturaId, opcionId);
                return Ok(lectura.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("historial/{usuarioId}/{mes}/{anio}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Historial(int usuarioId, int mes, int anio)
        {
            try
            {
                List<LecturaHistorialDTO> historial =   obtenerHistorialLecUsuCU.Execute(usuarioId, mes, anio);
                return Ok(historial);
            }
            catch (LecturaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener el historial.");
            }
        }

        [HttpGet("rankings/historias")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult RankingsHistorias()
        {
            try
            {
                List<HistoriaRankingsDTO> ranking = obtenerRankingsHistoriasCU.Execute();
                return Ok(ranking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener el ranking.");
            }
        }
    }
}
