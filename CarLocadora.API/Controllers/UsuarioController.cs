using CarLocadora.Modelo;
using CarLocadora.Negocio.UsuarioNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuario;


        public UsuarioController(IUsuarioNegocio usuario)
        {
            _usuario = usuario;
        }

        [HttpGet()]
        public async Task<List<Usuario>> Get()
        {
            var usuarios = _usuario.ObterLista();

            return usuarios;
        }

        [HttpGet("ObterUmUsuario")]
        public Usuario Get([FromQuery] string cpf)
        {
            return _usuario.ObterUmUsuario(cpf);
        }

        [HttpPost()]
        public void Post([FromBody] Usuario usuario)
        {
            _usuario.Incluir(usuario);
        }
        [HttpPut()]
        public void Put([FromBody] Usuario usuario)
        {
            _usuario.Alterar(usuario);
        }
    }
}
