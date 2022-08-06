using CarLocadora.Infra;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.FormaPagamentoNegocio
{
    public class FormaPagamentoNegocio : IFormaPagamentoNegocio
    {
        private readonly ControleDBContext _context;

        public FormaPagamentoNegocio(ControleDBContext context)
        {
            _context = context;
        }
        public void Alterar(FormaPagamento formaPagamento)
        {
            _context.FormaPagamentos.Update(formaPagamento);
            _context.SaveChanges();
        }

        public void Incluir(FormaPagamento formaPagamento)
        {
            _context.FormaPagamentos.Add(formaPagamento);
            _context.SaveChanges();
        }

        public FormaPagamento ObterFormaPagamento(int id)
        {
            return _context.FormaPagamentos.Single(x => x.Id == id);
        }

        public List<FormaPagamento> ObterLista()
        {
            return _context.FormaPagamentos.ToList();
        }
    }
}
