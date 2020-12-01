using AutoMapper;
using Investimentos.Domain.Interfaces.Repositories;
using Investimentos.Domain.Interfaces.Services;
using Investimentos.Domain.Services;
using Investimentos.Infra.Data.Contexts;
using Investimentos.Infra.Data.Repositories;
using Investimentos.Service.Api.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Investimentos.Service.Api
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFContext>(options => options.UseMySql(connection)
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())));
            services.AddScoped<IAtivoRendaVariavelService, AtivoRendaVariavelService>();
            services.AddScoped<IAtivoRendaVariavelRepository, AtivoRendaVariavelRepository>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            string[] origins = new string[] { "http://localhost:4200" };
            app.UseCors(option => option.AllowAnyMethod().AllowAnyHeader().WithOrigins(origins));
            // app.UseCors(option => option.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
