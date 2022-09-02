using CarLocadora.Modelo;
using CarLocadora.Negocio.VistoriaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VistoriaController : ControllerBase
    {
        private readonly IVistoriaNegocio _vistoria;


        public VistoriaController(IVistoriaNegocio vistoria)
        {
            _vistoria = vistoria;
        }

        [HttpGet()]
        public async Task<List<Vistoria>> Get()
        {
            var vistorias = _vistoria.ObterLista();

            return vistorias;
        }

        [HttpGet("ObterUmaVistoria")]
        public Vistoria Get([FromQuery] int id)
        {

            return _vistoria.ObterUmaVistoria(id);
        }

        [HttpPost()]
        public void Post([FromBody] Vistoria vistoria)
        {
            vistoria.DataInclusao = DateTime.Now;
            vistoria.DataAlteracao = null;
            _vistoria.Incluir(vistoria);
        }
        [HttpPut()]
        public void Put([FromBody] Vistoria vistoria)
        {
            vistoria.DataAlteracao = DateTime.Now;
            vistoria.DataInclusao = null;
            _vistoria.Alterar(vistoria);
        }
    }
}
