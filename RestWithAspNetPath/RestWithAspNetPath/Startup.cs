using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using RestWithAspNetPath.Business;
using RestWithAspNetPath.Business.Implementations;
using RestWithAspNetPath.HyperMedia;
using RestWithAspNetPath.Model.Context;
using RestWithAspNetPath.Repository;
using RestWithAspNetPath.Repository.Generic;
using RestWithAspNetPath.Repository.Implementations;
using RestWithAspNetPath.Security.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Tapioca.HATEOAS;

namespace RestWithAspNetPath
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

            //Adicionando Migrations
            ExecuteMigrations(connectionString);

            //Configurações de Login
            //AddSingleton - so existe uma instancia enquanto a aplicação estiver executando
            var signingConfigurations = new SigningConfigurations(); // Inicializando configurações
            services.AddSingleton(signingConfigurations); // Adicionando dependencia 

            var tokenConfigurations = new TokenConfiguration(); // Classe token criada na pasta security

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                _configuration.GetSection("TokenConfigurations")  // Busca la no nosso appsettings a sessão de configurações
            )
            .Configure(tokenConfigurations); // Confura o token que criamos

            services.AddSingleton(tokenConfigurations); // Injeta sua dependencia

            // Authenticacao
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            }); // Faz com que a aplicação requeira que o usuario sempre esteja authenticado
            //Finalizado configurações de Login

            services.AddMvc(options =>
            {
                // Adicionando suporte para xml e json ao projeto
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            //Define as opções do filtro HATEOAS
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions); //Injeta o serviço

            // Pacote de versionamento da nossa API
            services.AddApiVersioning(); 

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
            services.AddScoped<ILoginBusiness, LoginBusinessImpl>();
            services.AddScoped<IUserRepository, UserRepositoryImpl>();

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

        /// Metodos 
        private void ExecuteMigrations(string connectionString)
        {
            if (_environment.IsDevelopment()) // Base de desenvolvimento
            {
                try
                {
                    // Adicionando Migrations de forma Manual 'Evolve'
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
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
        }
    }
}
