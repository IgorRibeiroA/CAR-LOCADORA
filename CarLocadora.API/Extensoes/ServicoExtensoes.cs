using AspNetCoreRateLimit;
using CarLocadora.Infra;
using CarLocadora.Modelo;
using CarLocadora.Negocio.CategoriaNegocio;
using CarLocadora.Negocio.ClienteNegocio;
using CarLocadora.Negocio.FormaPagamentoNegocio;
using CarLocadora.Negocio.LocacaoNegocio;
using CarLocadora.Negocio.ManutencaoVeiculoNegocio;
using CarLocadora.Negocio.UsuarioNegocio;
using CarLocadora.Negocio.VeiculoNegocio;
using CarLocadora.Negocio.VistoriaNegocio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;

namespace CarLocadora.API.Extensoes
{
    public static class ServicoExtensoes
    {
        public static void ConfigurarSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - CarLocadora",
                    Version = "v1",
                    Description = "APIs para Locação de carros",
                }); 


                c.EnableAnnotations();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Autenticação JWT",
                    Description = "Informe o token JTW Bearer **_somente_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>()}
                });
            });

        public static void ConfigurarJWT(this IServiceCollection services)
        {
            Environment.SetEnvironmentVariable("JWT_SECRETO", Convert.ToBase64String(new HMACSHA256().Key),
                EnvironmentVariableTarget.Process);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(Options =>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = "EmitenteDoJWT",
                        ValidAudience = "DestinatarioDoJWT",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Convert.FromBase64String(Environment.GetEnvironmentVariable("JWT_SECRETO")))
                    };
                });

        }

        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "post:/api/Login",
                    Limit = 3,
                    Period = "10s",
                },
                //new RateLimitRule
                //{
                //    Endpoint = "*",
                //    Period = "10s",
                //    Limit = 2
                //}
            };

            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.EnableEndpointRateLimiting = true;
                opt.StackBlockedRequests = false;
                opt.GeneralRules = rateLimitRules;
            });

            services.AddInMemoryRateLimiting();

            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }


        public static void ConfigurarServicos(this IServiceCollection services)
        {
            string connectionString = "Data Source=localhost,1433;User ID=sa;Password=senha@1234xxxy;Initial Catalog=DBCarLocadora;";

            services.AddDbContext<ControleDBContext>(item => item.UseSqlServer(connectionString));

            services.AddScoped<IClienteNegocio, ClienteNegocio>();
            services.AddScoped<ICategoriaNegocio, CategoriaNegocio>();
            services.AddScoped<IVeiculoNegocio, VeiculoNegocio>();
            services.AddScoped<IFormaPagamentoNegocio, FormaPagamentoNegocio>();
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddScoped<IManutencaoVeiculoNegocio, ManutencaoVeiculoNegocio>();
            services.AddScoped<IVistoriaNegocio, VistoriaNegocio>();
            services.AddScoped<ILocacaoNegocio, LocacaoNegocio>();
        }

    }
}
