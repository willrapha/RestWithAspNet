using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using RestWithAspNetSwagger.Business;
using RestWithAspNetSwagger.Business.Implementations;
using RestWithAspNetSwagger.HyperMedia;
using RestWithAspNetSwagger.Model.Context;
using RestWithAspNetSwagger.Repository.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Tapioca.HATEOAS;

namespace RestWithAspNetSwagger
{
    public class Startup
    {
        private readonly ILogger _logger; // Logs da aplicação
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Busca string de conexão ao banco
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];

            // Adicionando serviço ao banco MySql
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString));

            if (_environment.IsDevelopment()) // Base de desenvolvimento
            {
                try
                {
                    // Adicionando Migrations de forma Manual 'Evolve'
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> {"db/migrations"},
                        IsEraseDisabled = true
                    };

                    evolve.Migrate();
                }
                catch (Exception e)
                {
                    _logger.LogCritical("Database migration failed.", e);
                    throw;
                }
            }

            services.AddMvc(options =>
            {
                // Adicionando xml ao projeto
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            //Define as opções do filtro HATEOAS
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions); //Injeta o serviço

            services.AddApiVersioning(); // Pacote de versionamento da nossa API

            // Adicionando o Swagger ao projeto
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new Info
                    {
                        Title = "RESTful API With ASP.NET Core 2.0",
                        Version = "v1"
                    });
            });

            // Injeções de dependencias
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();

            // Não precisamos mais fazer dessa forma
            //services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>)); // Injeção de dependencia para genericos
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configuração do swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            // Alterações para inicializar diretamente na pagina do Swagger
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger"); // redireciona todas as requisições para a pagina do swagger
            app.UseRewriter(option);

            app.UseMvc(routes =>
            {
                //Routes necessario para o HyperMedia
                routes.MapRoute(
                    name: "DefaultApi", // Foi pego o nome que criamos dentro da Clase PersonEnricher
                    template: "{controller=Values}/{id?}");
            });
        }
    }
}
