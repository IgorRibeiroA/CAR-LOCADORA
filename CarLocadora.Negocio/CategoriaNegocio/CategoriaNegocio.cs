using CarLocadora.Infra;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.CategoriaNegocio
{
    public class CategoriaNegocio : ICategoriaNegocio
    {
        private readonly ControleDBContext _context;
    

        public CategoriaNegocio(ControleDBContext context)
        {
            _context = context;
        }


        public void Alterar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            Categoria categoria = _context.Categorias.Single(x => x.Id == id);
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }

 

        public void Incluir(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public List<Categoria> ObterLista()
        {
            return _context.Categorias.ToList();
        }

        public Categoria ObterUmaCategoria(int id)
        {
            return _context.Categorias.Single(x => x.Id == id);
        }
    }
}
