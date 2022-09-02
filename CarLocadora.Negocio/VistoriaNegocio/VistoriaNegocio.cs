using CarLocadora.Infra;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.VistoriaNegocio
{
    public class VistoriaNegocio : IVistoriaNegocio
    {
        private readonly ControleDBContext _context;

        public VistoriaNegocio(ControleDBContext context)
        {
            _context = context;
        }

        public void Alterar(Vistoria vistoria)
        {
            _context.Vistorias.Update(vistoria);
            _context.SaveChanges();
        }

        public void Incluir(Vistoria vistoria)
        {
            _context.Vistorias.Add(vistoria);
            _context.SaveChanges();
        }

        public List<Vistoria> ObterLista()
        {
            return _context.Vistorias.ToList();
        }

        public Vistoria ObterUmaVistoria(int id)
        {
            return _context.Vistorias.Single(x => x.Id == id);
        }
    }
}
