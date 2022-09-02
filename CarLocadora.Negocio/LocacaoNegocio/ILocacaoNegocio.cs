using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.LocacaoNegocio
{
    public interface ILocacaoNegocio
    {
        List<Locacao> ObterLista();
        Locacao ObterUmLocacao(int id);

        void Incluir(Locacao locacao);

        void Alterar(Locacao locacao);
    }
}
