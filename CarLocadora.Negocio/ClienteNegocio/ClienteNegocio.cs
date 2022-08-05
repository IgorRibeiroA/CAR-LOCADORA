using CarLocadora.Infra;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.ClienteNegocio
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly ControleDBContext _context;

        public ClienteNegocio(ControleDBContext context)
        {
            _context = context;
        }


        public void Incluir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObterLista()
        {
            throw new NotImplementedException();
        }
    }
}
