using CarLocadora.Modelo;
using CarLocadora.Infra;
using Microsoft.AspNetCore.Mvc;
using CarLocadora.Negocio.ClienteNegocio;
namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _cliente;


        public ClienteController(IClienteNegocio cliente)
        {
            _cliente = cliente;
        }

        [HttpGet()]
        public async Task<List<Cliente>> Get()
        {
            var clientes = _cliente.ObterLista();

            return clientes;
        }
    
        [HttpGet("ObterUmCliente")]
        public Cliente Get([FromQuery] string cpf)
        {

            return _cliente.ObterUmCliente(cpf);
        }

        [HttpPost()]
        public void Post([FromBody] Cliente cliente)
        {
            cliente.DataInclusao = DateTime.Now;
            cliente.DataAlteracao = null;
            _cliente.Incluir(cliente);
        }
        [HttpPut()]
        public void Put([FromBody] Cliente cliente)
        {
            cliente.DataAlteracao = DateTime.Now;
            cliente.DataInclusao = null;
            _cliente.Alterar(cliente);
        } 
    }
}
