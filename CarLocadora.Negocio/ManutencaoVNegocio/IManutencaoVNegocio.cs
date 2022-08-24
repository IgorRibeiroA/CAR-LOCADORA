using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.ManutencaoVNegocio
{
    public interface IManutencaoVNegocio
    {
        List<ManutencaoVeiculo> ObterLista();
        ManutencaoVeiculo ObterUmManutencaoVeiculo(int id);
        void Incluir(ManutencaoVeiculo manutencaoVeiculo);
        void Alterar(ManutencaoVeiculo manutencaoVeiculo);
        void Excluir(int id);


    }
}
