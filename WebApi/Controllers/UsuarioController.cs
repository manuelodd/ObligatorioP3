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
        private IListarUsuarios listarUsuariosCU;
        private IObtenerUsuarioPorId obtenerUsuarioPorIdCU;
        private IAltaUsuario altaUsuCU;

        public UsuarioController(IListarUsuarios listarUsuariosCu,
                                    IObtenerUsuarioPorId obtCU,
                                    IAltaUsuario altaUsuCu)
        {
            this.listarUsuariosCU = listarUsuariosCu;
            obtenerUsuarioPorIdCU = obtCU;
            altaUsuCU = altaUsuCu;
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            try
            {
                return Ok(listarUsuariosCU.Execute());
            }
            catch(Exception ex)
            {
                // 500 = internal server error
                return StatusCode(500, ex.Message);
            }
            ;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<UsuarioDTO> Get(int id)
        {
            try
            {
                return Ok(obtenerUsuarioPorIdCU.Execute(id));
            }
            catch (UsuarioException uex)
            {
                return BadRequest(uex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /*
        [HttpPost("Login")]
        public ActionResult<UsuarioDTO> Login(LoginDTO dto)
        {
            try
            {
                UsuarioDTO usuario = loginCU.Execute(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */
        // POST api/<UsuarioController>
        [HttpPost]
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
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
