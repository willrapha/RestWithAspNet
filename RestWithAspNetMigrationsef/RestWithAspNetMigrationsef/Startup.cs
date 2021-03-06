﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestWithAspNetMigrationsef.Business;
using RestWithAspNetMigrationsef.Business.Implementations;
using RestWithAspNetMigrationsef.Model.Context;
using RestWithAspNetMigrationsef.Repository;
using RestWithAspNetMigrationsef.Repository.Implementations;

namespace RestWithAspNetMigrationsef
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

            services.AddMvc();

            services.AddApiVersioning(); // Pacote de versionamento da nossa API

            // Injeções de dependencias
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
