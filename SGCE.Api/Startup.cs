using SGCE.Domain.StoreContext.Handlers;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Domain.StoreContext.Services;
using SGCE.Infra.DataContexts;
using SGCE.Infra.StoreContext.Repositories;
using SGCE.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Elmah.Io.AspNetCore;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using SGCE.Shared;

namespace SGCE.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<SgceDataContext, SgceDataContext>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IVendaRepository, VendaRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ClienteHandler, ClienteHandler>();
            services.AddTransient<TurmaHandler, TurmaHandler>();
            services.AddTransient<CategoriaHandler, CategoriaHandler>();
            services.AddTransient<ProdutoHandler, ProdutoHandler>();
            services.AddTransient<VendaHandler, VendaHandler>();
            services.AddTransient<LoginHandler, LoginHandler>();



            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "SGCE", Version = "v1" });
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SGCE - V1");
            });

            app.UseElmahIo("923f4c946cc1435cb0ec665d6e7370b7", new Guid("e42a9995-df89-4d91-a625-ecc57d124004"));
        }
    }
}
