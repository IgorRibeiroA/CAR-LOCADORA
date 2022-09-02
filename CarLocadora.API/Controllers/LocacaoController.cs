
using CarLocadora.Modelo;
using CarLocadora.Negocio.LocacaoNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoNegocio _locacao;


        public LocacaoController(ILocacaoNegocio locacao)
        {
            _locacao = locacao;
        }

        [HttpGet()]
        public async Task<List<Locacao>> Get()
        {
            var locacao= _locacao.ObterLista();

            return locacao;
        }

        [HttpGet("ObterUmaLocacao")]
        public Locacao Get([FromQuery] int id)
        {

            return _locacao.ObterUmLocacao(id);
        }

        [HttpPost()]
        public void Post([FromBody] Locacao locacao)
        {
            locacao.DataInclusao = DateTime.Now;
            locacao.DataAlteracao = null;
            _locacao.Incluir(locacao);
        }
        [HttpPut()]
        public void Put([FromBody] Locacao locacao)
        {
            locacao.DataAlteracao = DateTime.Now;
            locacao.DataInclusao = null;
            _locacao.Alterar(locacao);
        }
    }
}
