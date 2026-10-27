using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IListarUsuarios listarUsuariosCU;

        public UsuarioController(IListarUsuarios listarUsuariosCu)
        {
            this.listarUsuariosCU = listarUsuariosCu;
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<UsuarioDTO> Get()
        {
            return listarUsuariosCU.Execute();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
