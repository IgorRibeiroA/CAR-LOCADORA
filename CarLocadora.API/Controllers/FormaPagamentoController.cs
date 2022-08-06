using CarLocadora.Modelo;
using CarLocadora.Negocio.FormaPagamentoNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoNegocio _FP;


        public FormaPagamentoController(IFormaPagamentoNegocio fp)
        {
            _FP = fp;
        }

        [HttpGet()]
        public async Task<List<FormaPagamento>> Get()
        {
            var fps = _FP.ObterLista();

            return fps;
        }

        [HttpGet("ObterUmaFormaPagamento")]
        public FormaPagamento Get([FromQuery] int id)
        {
            return _FP.ObterFormaPagamento(id);
        }

        [HttpPost()]
        public void Post([FromBody] FormaPagamento formaPagamento)
        {
            _FP.Incluir(formaPagamento);
        }
        [HttpPut()]
        public void Put([FromBody] FormaPagamento formaPagamento)
        {
            _FP.Alterar(formaPagamento);
        }

    }
}
