using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.VistoriaNegocio
{
    public interface IVistoriaNegocio
    {

        List<Vistoria> ObterLista();
        Vistoria ObterUmaVistoria(int id);

        void Incluir(Vistoria vistoria);

        void Alterar(Vistoria vistoria);

    }

}