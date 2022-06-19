using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoMaquiesse.API.ViewModels;
using GestaoMaquiesse.Domain.Entidades;
using GestaoMaquiesse.Infra.Contexto;
using GestaoMaquiesse.Infra.Interfaces;
using GestaoMaquiesse.Infra.Repositorios;
using GestaoMaquiesse.Services.DTO;
using GestaoMaquiesse.Services.Interfaces;
using GestaoMaquiesse.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GestaoMaquiesse.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>{
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            #region ConfiguracaoAutomapper

            var autoMapperConfig = new MapperConfiguration(cfg =>{
                cfg.CreateMap<Usuario, UsuarioDTO>().ReverseMap();
                cfg.CreateMap<ViewModelCriarUsuario, UsuarioDTO>().ReverseMap();
            });
            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion

            #region ID
            services.AddSingleton(d=> Configuration);
            services.AddDbContext<ContextoGestaoMaquiesse>(options => options.UseSqlServer(Configuration["ConnectionStrings:Default"]));
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestaoMaquiesse.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestaoMaquiesse.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
