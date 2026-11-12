using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.TokenHandler;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        private ILoginAdmins loginAdminsCU;
        public AuthController(ILoginAdmins loginAdminsCu, IConfiguration configuration)
        {
            loginAdminsCU = loginAdminsCu;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<UsuarioDTO> Login([FromBody] LoginDTO dto)
        {
            try
            {
                UsuarioDTO usuariodto = loginAdminsCU.Execute(dto);
                string token = JWTHandler.GenerarToken(usuariodto, _configuration);
                return Ok(
                    new
                    {
                        Token = token,
                        Usuario = usuariodto
                    });
            }
            catch(UsuarioException uex)
            {
                return BadRequest(uex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error, vuelva a intentarlo luego.");
            }
        }

        
    }
}
