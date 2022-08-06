using CarLocadora.Modelo;
using CarLocadora.Negocio.CategoriaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaNegocio _categoria;

        public CategoriaController(ICategoriaNegocio categoria)
        {
            _categoria = categoria;
        }

        [HttpGet()]
        public async Task<List<Categoria>> Get()
        {
            var categorias = _categoria.ObterLista();

            return categorias;
        }
        [HttpGet("ObterUmaCategoria")]
        public Categoria Get([FromQuery] int id)
        {
            return _categoria.ObterUmaCategoria(id);
        }


        [HttpPost()]
        public void Post([FromBody] Categoria categoria)
        {
            _categoria.Incluir(categoria);
        }

        [HttpPut()]
        public void Put([FromBody] Categoria categoria)
        {
            _categoria.Alterar(categoria);
        }

        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            _categoria.Excluir(id);
        }

    }
}

