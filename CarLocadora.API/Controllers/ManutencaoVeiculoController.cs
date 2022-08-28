using CarLocadora.Modelo;
using CarLocadora.Negocio.ManutencaoVeiculoNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManutencaoVeiculoController : ControllerBase
    {
        private readonly IManutencaoVeiculoNegocio _manutencaoVeiculo;

        public ManutencaoVeiculoController(IManutencaoVeiculoNegocio manutencaoVeiculo)
        {
            _manutencaoVeiculo = manutencaoVeiculo;
        }

        [HttpGet()]
        public async Task<List<ManutencaoVeiculo>> Get()
        {
            var manutencao = _manutencaoVeiculo.ObterLista();

            return manutencao;
        }

        [HttpGet("ObterUmaManutencaoVeiculo")]
        public ManutencaoVeiculo Get([FromQuery] int id)
        {
            return _manutencaoVeiculo.ObterUmaManutencaoVeiculo(id);
        }

        [HttpPost()]
        public void Post([FromBody] ManutencaoVeiculo manutencaoVeiculo)
        {
            manutencaoVeiculo.DataInclusao = DateTime.Now;
            _manutencaoVeiculo.Incluir(manutencaoVeiculo);
        }

        [HttpPut()]
        public void Put([FromBody] ManutencaoVeiculo manutencaoVeiculo)
        {
            manutencaoVeiculo.DataAlteracao = DateTime.Now;
            _manutencaoVeiculo.Alterar(manutencaoVeiculo);
        }

        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            _manutencaoVeiculo.Excluir(id);
        }

    }
}
