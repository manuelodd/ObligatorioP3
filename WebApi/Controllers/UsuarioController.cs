using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IObtenerUsuarioHistoriasRankings obtenerRankingUsuariosCU;
        private IAltaUsuario altaUsuCU;

        public UsuarioController(   
                                    IAltaUsuario altaUsuCu,
                                    IObtenerUsuarioHistoriasRankings obtenerRankingUsuariosCu)
        {
            altaUsuCU = altaUsuCu;
            obtenerRankingUsuariosCU = obtenerRankingUsuariosCu;
        }

        [HttpGet("rankings/historias-completadas")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult RankingHistoriasCompletadas()
        {
            try
            {
                List<UsuarioHistoriasRankingsDTO> ranking = obtenerRankingUsuariosCU.Execute();
                return Ok(ranking);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener el ranking.");
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Post([FromBody] UsuarioDTO dto)
        {
            try
            {
                altaUsuCU.Execute(dto);
                return Created("api/Usuario", dto);
            }
            catch (UsuarioException uex) { 
            return BadRequest(uex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error, vuelva a intentar luego.");
            }
        }


    }
}
