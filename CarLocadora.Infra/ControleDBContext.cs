using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Infra
{
    public class ControleDBContext : DbContext
    {
        public ControleDBContext(DbContextOptions<ControleDBContext> options) : base(options)
        {

        }
        
        public DbSet<Cliente> Clientes { get; set; }

    }

}
