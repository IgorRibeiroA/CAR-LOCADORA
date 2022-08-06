using CarLocadora.Infra;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.UsuarioNegocio
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly ControleDBContext _context;

        public UsuarioNegocio(ControleDBContext context)
        {
            _context = context;
        }
        public void Alterar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Incluir(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public List<Usuario> ObterLista()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario ObterUmCliente(string cpf)
        {
            return _context.Usuarios.Single(x => x.CPF == cpf);
        }
    }
}
