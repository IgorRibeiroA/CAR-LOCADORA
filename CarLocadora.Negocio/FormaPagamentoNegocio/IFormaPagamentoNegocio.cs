using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.FormaPagamentoNegocio
{
    public interface IFormaPagamentoNegocio
    {
        List<FormaPagamento> ObterLista();
        FormaPagamento ObterFormaPagamento(int id);

        void Incluir(FormaPagamento formaPagamento);

        void Alterar(FormaPagamento formaPagamento);
    }
}
