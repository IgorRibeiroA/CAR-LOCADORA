﻿using CarLocadora.Modelo;
using CarLocadora.Negocio.VeiculoNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoNegocio _veiculo;


        public VeiculoController(IVeiculoNegocio veiculo)
        {
            _veiculo = veiculo;
        }

        [HttpGet()]
        public async Task<List<Veiculo>> Get()
        {
            var veiculos = _veiculo.ObterLista();

            return veiculos;
        }

        [HttpGet("ObterUmVeiculo")]
        public Veiculo Get([FromQuery] string placa)
        {
            return _veiculo.ObterUmVeiculo(placa);
        }

        [HttpPost()]
        public void Post([FromBody] Veiculo veiculo)
        {
            _veiculo.Incluir(veiculo);
        }
        [HttpPut()]
        public void Put([FromBody] Veiculo veiculo)
        {
            _veiculo.Alterar(veiculo);
        }
    }
}
