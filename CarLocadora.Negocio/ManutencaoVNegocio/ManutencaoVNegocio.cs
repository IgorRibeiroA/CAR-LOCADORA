using CarLocadora.Infra;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.ManutencaoVNegocio
{
    public class ManutencaoVNegocio : IManutencaoVNegocio
    {
        private readonly ControleDBContext _context;


        public ManutencaoVNegocio(ControleDBContext context)
        {
            _context = context;
        }

        public void Alterar(ManutencaoVeiculo manutencaoVeiculo)
        {
            _context.ManutencaoVeiculos.Update(manutencaoVeiculo);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            ManutencaoVeiculo manutencaoVeiculo = _context.ManutencaoVeiculos.Single(x => x.Id == id);
            _context.ManutencaoVeiculos.Remove(manutencaoVeiculo);
            _context.SaveChanges();
        }

        public void Incluir(ManutencaoVeiculo manutencaoVeiculo)
        {
            _context.ManutencaoVeiculos.Add(manutencaoVeiculo);
            _context.SaveChanges();
        }

        public List<ManutencaoVeiculo> ObterLista()
        {
            return _context.ManutencaoVeiculos.ToList();
        }

        public ManutencaoVeiculo ObterUmManutencaoVeiculo(int id)
        {
            return _context.ManutencaoVeiculos.Single(x => x.Id == id);
        }

    }
}
