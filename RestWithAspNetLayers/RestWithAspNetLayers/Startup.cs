using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithAspNetLayers.Model.Context;
using RestWithAspNetLayers.Services;
using RestWithAspNetLayers.Services.Implementations;

namespace RestWithAspNetLayers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Busca string de conexão ao banco
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];

            // Adicionando serviço ao banco MySql
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));

            services.AddMvc();

            services.AddApiVersioning(); // Pacote de versionamento da nossa API

            // Injeções de dependencias
            services.AddScoped<IPersonService, PersonServiceImpl>();
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
