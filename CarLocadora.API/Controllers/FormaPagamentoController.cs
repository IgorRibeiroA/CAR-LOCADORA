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
        private readonly IFormaPagamentoNegocio _FormaPagamento;


        public FormaPagamentoController(IFormaPagamentoNegocio formapagamento)
        {
            _FormaPagamento = formapagamento;
        }

        [HttpGet()]
        public async Task<List<FormaPagamento>> Get()
        {
            var formapagamentos = _FormaPagamento.ObterLista();

            return formapagamentos;
        }

        [HttpGet("ObterUmaFormaPagamento")]
        public FormaPagamento Get([FromQuery] int id)
        {
            return _FormaPagamento.ObterFormaPagamento(id);
        }

        [HttpPost()]
        public void Post([FromBody] FormaPagamento formaPagamento)
        {
            formaPagamento.DataInclusao = DateTime.Now;
            _FormaPagamento.Incluir(formaPagamento);
        }
        [HttpPut()]
        public void Put([FromBody] FormaPagamento formaPagamento)
        {
            formaPagamento.DataAlteracao = DateTime.Now;
            _FormaPagamento.Alterar(formaPagamento);
        }

    }
}
