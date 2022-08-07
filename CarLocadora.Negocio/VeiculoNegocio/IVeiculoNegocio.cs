using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.VeiculoNegocio
{
    public interface IVeiculoNegocio
    {
        List<Veiculo> ObterLista();
        Veiculo ObterUmVeiculo(string placa);

        void Incluir(Veiculo veiculo);

        void Alterar(Veiculo veiculo);
    }
}
