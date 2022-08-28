using CarLocadora.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.ManutencaoVeiculoNegocio
{
    public interface IManutencaoVeiculoNegocio
    {
        List<ManutencaoVeiculo> ObterLista();
        ManutencaoVeiculo ObterUmaManutencaoVeiculo(int id);
        void Incluir(ManutencaoVeiculo manutencaoVeiculo);
        void Alterar(ManutencaoVeiculo manutencaoVeiculo);
        void Excluir(int id);

    }
}
