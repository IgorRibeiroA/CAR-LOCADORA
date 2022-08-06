using CarLocadora.Infra;
using CarLocadora.Negocio.ClienteNegocio;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.API.Extensoes
{
    public static class ServicoExtensoes
    {

        public static void ConfigurarServicos(this IServiceCollection services)
        {
            string connectionString = "Data Source=localhost,1433;User ID=sa;Password=senha@1234xxxy;Initial Catalog=DBCarLocadora;";

            services.AddDbContext<ControleDBContext>(item => item.UseSqlServer(connectionString));

            services.AddScoped<IClienteNegocio, ClienteNegocio>();
        }

    }
}
