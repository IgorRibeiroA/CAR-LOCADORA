using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.CategoriaNegocio
{
    public interface ICategoriaNegocio
    {
        List<Categoria> ObterLista();
        Categoria ObterUmaCategoria(int id);

        void Incluir(Categoria categoria);

        void Alterar(Categoria categoria);
        void Excluir(int id);
    }
}
