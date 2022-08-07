using CarLocadora.Infra;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.VeiculoNegocio
{
    public class VeiculoNegocio : IVeiculoNegocio
    {

        private readonly ControleDBContext _context;

        public VeiculoNegocio(ControleDBContext context)
        {
            _context = context;
        }

        public void Alterar(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();   
        }

        public void Incluir(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }

        public List<Veiculo> ObterLista()
        {
            return _context.Veiculos.ToList();
        }

        public Veiculo ObterUmVeiculo(string placa)
        {
            return _context.Veiculos.Single(x => x.Placa == placa);
        }
    }
}
