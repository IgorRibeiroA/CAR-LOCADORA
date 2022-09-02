using CarLocadora.Infra;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.LocacaoNegocio
{
    public class LocacaoNegocio : ILocacaoNegocio
    {
        private readonly ControleDBContext _context;

        public LocacaoNegocio(ControleDBContext context)
        {
            _context = context;
        }


        public void Alterar(Locacao locacao)
        {
            _context.Locacoes.Update(locacao);
            _context.SaveChanges();
        }

        public void Incluir(Locacao locacao)
        {
            _context.Locacoes.Add(locacao);
            _context.SaveChanges();
        }

        public List<Locacao> ObterLista()
        {
            return _context.Locacoes.ToList();
        }

        public Locacao ObterUmLocacao(int id)
        {
            return _context.Locacoes.Single(x => x.Id == id);
        }
    }
}
