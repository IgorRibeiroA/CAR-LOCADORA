using CarLocadora.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet()]
        public List<Cliente> Get()
        {
            List<Cliente> list = new List<Cliente>();
            Cliente cliente = new();
            cliente.Nome = "Igor Ribeiro";
            cliente.CNH = "156549889999";

            list.Add(cliente);
            return list;
        }
    }
}
