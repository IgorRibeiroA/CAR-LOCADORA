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

        public void Alterar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Incluir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> ObterLista()
        {
            return _context.Clientes.ToList();
        }

        public Cliente ObterUmCliente(string cpf)
        {
            return _context.Clientes.Single(x => x.CPF == cpf);
        }
    }
}
