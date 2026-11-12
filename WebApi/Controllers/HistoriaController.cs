using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaController : ControllerBase
    {
            private IObtenerRankingsHistorias obtenerRankingsHistoriasCU;
            public HistoriaController(IObtenerRankingsHistorias obtenerRankingsHistoriasCu)
            {
                obtenerRankingsHistoriasCU = obtenerRankingsHistoriasCu;
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
                    return StatusCode(500, "Error, vuelva a intentar mas tarde");
                }
            }



            // GET: api/<HistoriaController>
            [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HistoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HistoriaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HistoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HistoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
